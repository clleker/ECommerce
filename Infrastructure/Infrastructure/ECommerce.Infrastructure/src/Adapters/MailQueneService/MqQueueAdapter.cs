using ECommerce.Core.Infrastructure.MessageBrokers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ETicaretAPI.Infrastructure.Adapters.MailQueneService
{
    public class MqQueueAdapter : IMessageBrokerHelper
    {
        private readonly MessageBrokerOptions _brokerOptions;

        public MqQueueAdapter(IConfiguration configuration)
        {
            Configuration = configuration;
            _brokerOptions = Configuration.GetSection("MessageBrokerOptions").Get<MessageBrokerOptions>();
        }

        public IConfiguration Configuration { get; }

        public void QueueMessage(string messageText)
        {
            var factory = new ConnectionFactory
            {
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password
            };
    
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("mail.exchange", ExchangeType.Direct);

                channel.QueueDeclare(
                    queue: "mail.queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var message = JsonConvert.SerializeObject(messageText);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "mail.exchange", routingKey: "mail.queue", basicProperties: null, body: body);
            }
        }
    }
}