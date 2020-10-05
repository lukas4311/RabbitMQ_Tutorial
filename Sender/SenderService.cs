using RabbitMQ.Client;
using System;
using System.Text;

namespace Sender
{
    internal class SenderService
    {
        private const string QueueName = "greet";

        internal void SendMessage()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            string message = "Ahoj ja jsem Lukas!";
            byte[] body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);

            Console.WriteLine(" Message send {0}", message);
            Console.WriteLine(" Press any key to exit.");
            Console.ReadLine();
        }
    }
}
