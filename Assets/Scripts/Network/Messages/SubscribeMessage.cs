using Mirror;

namespace Network.Messages
{
    public struct SubscribeMessage : NetworkMessage
    {
        /// <summary>
        /// Тема на которую
        /// </summary>
        public string Topic;

        /// <summary>
        /// Действие, True - подписываемся False - отписываемся
        /// </summary>
        public bool IsSubscribe;
    }
}