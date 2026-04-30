using Logging;
using Mirror;

namespace Network.PubSub
{
    /// <summary>
    /// Mirror перенаправление сообщения
    /// </summary>
    public class NetworkPublisher : IPublisher
    {
        private readonly IBroker _broker;
        private readonly Ilog _logger;

        public NetworkPublisher(IBroker broker, Ilog logger)
        {
            _broker = broker;
            _logger =  logger;
        }
        
        public void Publish<Message>(string topic, Message message) where Message : struct, NetworkMessage
        {
            _logger.SendMessage($"Publish: {topic}");
            
            var subscribers = _broker.SubscribersByTopic(topic);
            if (subscribers is not { Count: > 0 }) return;
            foreach (var sub in subscribers)
            {
                NetworkServer.connections.TryGetValue(sub, out var connection);
                connection?.Send(message);
            }
        }
    }
}