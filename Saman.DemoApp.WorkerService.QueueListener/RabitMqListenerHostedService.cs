using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.DemoApp.WorkerService.QueueListener
{
    public class RabitMqListenerHostedService : IHostedService, IDisposable
    {
        IConfiguration _configuration;

        public RabitMqListenerHostedService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Dispose()
        {
            
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var configSection = _configuration.GetSection("Messaging");
            var factory = new ConnectionFactory() { HostName = configSection.GetSection("HostName").Value };
            factory.UserName =  "wnfychpa";
            factory.Password = "OhcutkFCADDWcuEMZLyxC1SdJWYbM-mH";
            factory.VirtualHost = "wnfychpa";
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "SalesFiles",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "SalesFiles",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new ApplicationException("Message listener service terminated");
        }
    }
}
