using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Reciever
{
    internal class RecieverService
    {
        private const string QueueName = "greet";

        public void RecieverMessage()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();
            channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            Console.WriteLine("Waiting for messages.");

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                Console.WriteLine("Received message: {0}", this.GetMessageBodyText(ea));
            };
            channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private string GetMessageBodyText(BasicDeliverEventArgs basicDeliverEventArgs)
        {
            byte[] body = basicDeliverEventArgs.Body.ToArray();
            return Encoding.UTF8.GetString(body);
        }
    }
}