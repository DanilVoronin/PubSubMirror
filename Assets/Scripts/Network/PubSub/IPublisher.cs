using Mirror;

namespace Network.PubSub
{
    /// <summary>
    /// Договор публикации
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// Публикация темы
        /// </summary>
        public void Publish<Message>(string topic, Message message) where Message : struct, NetworkMessage;
    }
}