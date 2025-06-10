using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Application.DTOs;
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
    public class LoggerService : ILoggerService
    {
        private readonly IConfiguration _configuration;

        public LoggerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string _queueName = "log_rabbit";
        public async Task AddLog(LoggerDTO logDTO)
        {

            ConnectionFactory fact = new ConnectionFactory { HostName = _configuration["Host_Rabbit"] };

            using (var connection = fact.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string jsonMessage = JsonConvert.SerializeObject(logDTO);
                var body = Encoding.UTF8.GetBytes(jsonMessage);

                channel.BasicPublish(exchange: "",
                                    routingKey: _queueName,
                                    basicProperties: null,
                                    body: body);
            }
        }
    }
}
