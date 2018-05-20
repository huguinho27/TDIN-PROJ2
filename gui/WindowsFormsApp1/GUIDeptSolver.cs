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
                    {"troubleTicketId" , secondary.troubleTicket_id},
                    {"date", secondary.date },
                    {"state",secondary.state },
                    {"id",secondary.id }
                };

                this.collection.InsertOne(document);
                refresh_Button();
            }
            catch{}
        }

        private void GUIDeptSolver_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void secondary_ticketsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TODO SABER ID DO SECONDARY TROUBLETICKET
            var id = "1124241241";
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var document = this.collection.Find(filter).First();

            var answer = document["answer"];
            //TODO CRIAR JANELA
            //ESPERAR QUE FECHE
            // VERIFICAR SE CARREGOU NO SUBMIT E SE ANSWER E DIFERENTE
            var newAnswer = "";

            //SE DE FACTO FOR DIFERENTE

            //atualalizer na db local...
            var update = Builders<BsonDocument>.Update.Set("state", "solved");
            this.collection.UpdateOne(filter, update);

            //enviar por mensagem
            string secondaryTicket = "{{'answer':'" + newAnswer + "'},{'state':'solved'}}";
            this.send(secondaryTicket);
            refresh_Button();
        }

        private void refresh_Button()
        {
            var documents = this.collection.Find(new BsonDocument()).ToList();

            foreach (BsonDocument doc in documents)
            {
                //TODO: MASTER HUGO INSERT IN ROWS
                //this.newSecondaryTicket(doc["id"].ToString(), doc["title"].ToString(), doc["state"].ToString());
                Console.WriteLine(doc["state"]);
            }
        }

        private void assignedTicketsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RequestSingleSecondaryQuestion request = new RequestSingleSecondaryQuestion();
            request.id = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;

            ResponseSingleSecondaryQuestion response = (ResponseSingleSecondaryQuestion)WebRequestPost.makeRequest<ResponseSingleSecondaryQuestion>("/secondaryquestions/get", request);
            if (response.error.Equals("1"))
                MessageBox.Show(
                    response.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);

            showAssignedTicket ticket = new showAssignedTicket();
            ticket.secondaryQuestionID = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;
            ticket.changeStateText(response.state);
            ticket.changeTitleText(response.title);
            ticket.changeDescriptionText(response.description);
            ticket.ShowDialog();
            //TODO:refresh?
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

    }
}

