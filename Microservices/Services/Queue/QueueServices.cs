using Domain.Models;
using Hangfire;
using Microservices.Models.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Microservices.Services.Queue
{
    public class QueueServices : IQueueServices
    {
        public CriminalCode Consume()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "admin" };
            CriminalCode? criminalCode = null;
            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "CriminalCodeQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Received: " + message);
                criminalCode = Newtonsoft.Json.JsonConvert.DeserializeObject<CriminalCode>(message);

                if (ea.DeliveryTag == 1)
                    channel.BasicAck(ea.DeliveryTag, false);
                else
                    channel.BasicNack(ea.DeliveryTag, false, true);


            };
            consumer.ConsumerCancelled += OnConsumerCancelled;


            channel.BasicConsume(queue: "CriminalCodeQueue",
                                     autoAck: false,
                                     consumer: consumer);
            return criminalCode;
        }

        public bool Dequeue()
        {
            throw new NotImplementedException();
        }

        private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
            //TODO
        }
        private void OnShutdown(object sender, ConsumerEventArgs e)
        {
            //TODO
        }
    }
}
