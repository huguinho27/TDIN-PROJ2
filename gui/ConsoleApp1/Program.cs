using System;
using System.IO;
using System.Net;
using System.Text;
using WindowsFormsApp1;
using System.Windows.Forms;
using System.Messaging;

namespace ConsoleProgram
{
    public class Order
    {
        public int orderId;
        public string subject;
        public string text;
        public DateTime orderTime;
    };

    public class WebRequestPost
    {
        /*[STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try { Application.Run(new Register()); }
            catch (Exception) { }*/


            /*WebRequest request = WebRequest.Create("http://localhost:3000");
            request.Method = "POST";

            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                String responseString = reader.ReadToEnd();
                Console.WriteLine(responseString);
            }
            response.Close();
            Console.ReadLine();
        }*/
            
        public class MyNewQueue
        {
            public static void Main()
            {
                // Create a new instance of the class.
                MyNewQueue myNewQueue = new MyNewQueue();

                // Send a message to a queue.
                myNewQueue.SendMessage();

                // Receive a message from a queue.
                myNewQueue.ReceiveMessage();

                return;
            }

            public void SendMessage()
            {
                Order sentOrder = new Order();
                sentOrder.orderId = 3;
                sentOrder.orderTime = DateTime.Now;
                sentOrder.subject = "como apagar um ficheiro?";
                sentOrder.text = "como e que eu apago um ficheiro, pah?";

                // Connect to a queue on the local computer.
                MessageQueue myQueue = new MessageQueue(@".\private$\myQueue");

                // Send the Order to the queue.
                myQueue.Send(sentOrder);
                return;
            }

            public void ReceiveMessage()
            {
                // Connect to the a queue on the local computer.
                MessageQueue myQueue = new MessageQueue(@".\private$\myQueue");

                // Set the formatter to indicate body contains an Order.
                myQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(Order)});

                try
                {
                    // Receive and format the message. 
                    System.Messaging.Message myMessage = myQueue.Receive();
                    Order myOrder = (Order)myMessage.Body;

                    // Display message information.
                    Console.WriteLine("Order ID: " +
                        myOrder.orderId.ToString());
                    Console.WriteLine("Subject: " +
                        myOrder.subject);
                    Console.WriteLine("Text: " +
                        myOrder.text);
                    Console.WriteLine("Sent: " +
                        myOrder.orderTime.ToString());
                }

                catch (MessageQueueException)
                {
                    // Handle Message Queuing exceptions.
                }

                // Handle invalid serialization format.
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
                return;
            }
        }
    }
}