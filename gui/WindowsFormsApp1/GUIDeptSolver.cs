using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1
{
    public partial class GUIDeptSolver : Form
    {
        private IModel channel;
        private IMongoCollection<BsonDocument> collection;
        private JavaScriptSerializer serializer;

        public GUIDeptSolver()
        {
            connectToMongo();
            connectToRabbit();
            createSerializer();
            InitializeComponent();
            refresh_Button();
        }

        public void newSecondaryTicket(string id, string title, string state)
        {
            string[] row = { id , title, state };
            this.assignedTicketsList.Items.Add(new ListViewItem(row));
        }

        private void createSerializer()
        {
            this.serializer = new JavaScriptSerializer();
        }

        private void connectToMongo()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ttdb2");
            this.collection = database.GetCollection<BsonDocument>("secondaryQuestions");
        }

        public void connectToRabbit()
        {
            //Create connection 
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };

            //Trying to connect
            IConnection connection = null;
            try
            {
                connection = factory.CreateConnection();
            }
            catch(RabbitMQ.Client.Exceptions.BrokerUnreachableException e)
            {
                MessageBox.Show(
                    "Failed to Connect to RabbitMQ",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
       
            //Creating Channel
            this.channel = connection.CreateModel();
            {
                //making sure both queues exist
                this.channel.QueueDeclare(queue: "nodeQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                this.channel.QueueDeclare(queue: "guiQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                //Declaring a consumer event and creating receive function
                var consumer = new EventingBasicConsumer(this.channel);
                consumer.Received += receive;

                //Registering event and function in channel
                this.channel.BasicConsume(queue: "nodeQueue",
                                 autoAck: true,
                                 consumer: consumer);
            }
        }

        public void send(string msg)
        {
            byte[] body = Encoding.UTF8.GetBytes(msg);

            this.channel.BasicPublish(exchange: "",
                                 routingKey: "guiQueue",
                                 basicProperties: null,
                                 body: body);
        }
        
        public void receive(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body);

            try
            {
                SecondaryTroubleTicket secondary = this.serializer.Deserialize<SecondaryTroubleTicket>(message);

                var document = new BsonDocument
                {
                    {"email",secondary.email },
                    {"name",secondary.name },
                    {"title",secondary.title },
                    {"description",secondary.description },
                    {"troubleTicketId" , secondary.troubleTicketId},
                    {"date", secondary.date },
                    {"state",secondary.state },
                    {"id",secondary.id }
                };

                this.collection.InsertOne(document);
                BeginInvoke(new Action(() =>
                {
                    refresh_Button();
                }));

            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
        }

        private void GUIDeptSolver_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void refresh_Button()
        {
            var documents = this.collection.Find(new BsonDocument()).ToList();
            this.assignedTicketsList.Items.Clear();

            foreach (BsonDocument doc in documents)
            {
                if(doc["id"] != null && doc["title"] != null && doc["state"] != null)
                    this.newSecondaryTicket(doc["id"].ToString(), doc["title"].ToString(), doc["state"].ToString());
            }
        }

        private void assignedTicketsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var document = this.collection.Find(filter).First();

            showAssignedTicket ticket = new showAssignedTicket();
            ticket.secondaryQuestionID = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;
            ticket.changeStateText(document["state"].ToString());
            ticket.changeTitleText(document["title"].ToString());
            ticket.changeDescriptionText(document["description"].ToString());
            bool justWatchingTicket = false;
            try
            {
                ticket.changeAnswerText(document["answer"].ToString());
                justWatchingTicket = true;
                ticket.solved = true;
                ticket.deactivateSubmitButton();
                ticket.unableAnswerText();
                ticket.unableDescriptionText();
                ticket.unableStateText();
                ticket.unableTitleText();
            }
            catch {
                justWatchingTicket = false;
                ticket.solved = false;
            }
            ticket.ShowDialog();

            //TODO ESPERAR PORR SOLVED

            if(ticket.solved && !justWatchingTicket)
            {
                var update = Builders<BsonDocument>.Update.Set("state", "solved").Set("answer", ticket.answerText);
                this.collection.UpdateOne(filter, update);

                string secondaryTicket = "{\"id\":\""+ id +"\",\"answer\":\""+ ticket.answerText + "\",\"state\":\"solved\"}";
                this.send(secondaryTicket);
            }
            refresh_Button();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh_Button();
        }

    }
}

