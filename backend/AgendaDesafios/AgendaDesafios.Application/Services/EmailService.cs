using AgendaDesafios.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Services
{
    public class EmailService : IEmailService
    {

        private IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        private string _queueName = "email_rabbit";
        public async Task SendEmail(string email, string Title, string Body, IEnumerable<string>? Cc = null)
        {

            var obj = new { Email = email, Title = Title, Body = Body };
            ConnectionFactory fact = new ConnectionFactory { HostName = _configuration["Host_Rabbit"] };

            using (var connection = fact.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declara a fila se ela não existir
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Serializa o objeto para JSON
                string jsonMessage = JsonConvert.SerializeObject(obj);
                var body = Encoding.UTF8.GetBytes(jsonMessage);

                // Publica a mensagem na fila
                channel.BasicPublish(exchange: "",
                                    routingKey: _queueName,
                                    basicProperties: null,
                                    body: body);
            }
        }
    }
}
