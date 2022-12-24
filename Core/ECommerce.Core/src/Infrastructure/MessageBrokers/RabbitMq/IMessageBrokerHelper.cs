namespace ECommerce.Core.Infrastructure.MessageBrokers
{
    public interface IMessageBrokerHelper
    {
        void QueueMessage(string messageText);
    }
}