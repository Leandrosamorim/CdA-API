using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Models;
using RabbitMQ.Client;

namespace Domain.Services
{
    public class QueueServices : IQueueServices
    {
        public void EnqueueCriminalCode(CriminalCode criminalCode)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "admin" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CriminalCodeQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = System.Text.Json.JsonSerializer.Serialize(criminalCode);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "CriminalCodeQueue",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }

            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
