using System;

namespace Network.PubSub
{
    /// <summary>
    /// События брокера
    /// </summary>
    public interface IBrokerEvents
    {
        /// <summary>
        /// Вызывается при изменении темы
        /// </summary>
        public event Action OnTopicChange;
    }
}