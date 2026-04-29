using System.Collections.Generic;
using Mirror;

namespace Net.PubSub
{
    /// <summary>
    /// Тема подписки
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Подключенные клиенты
        /// </summary>
        public List<NetworkConnectionToClient> Connections { get; private set; } = new();
    }
}