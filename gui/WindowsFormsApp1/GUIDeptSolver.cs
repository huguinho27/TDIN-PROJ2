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

namespace WindowsFormsApp1
{
    public partial class GUIDeptSolver : Form
    {
        public GUIDeptSolver()
        {
            new System.Threading.Thread(new
                 System.Threading.ThreadStart(listen)).Start();
            InitializeComponent();
        }

        public void newSecondaryTicket(string message)
        {
            string[] row = { "bla", "bla", "bla" };
            this.assignedTicketsList.Items.Add(new ListViewItem(row));
        }

        public void listen()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection()) 
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "nodeQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    newSecondaryTicket(message);
                };
                channel.BasicConsume(queue: "nodeQueue", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

    }
}

