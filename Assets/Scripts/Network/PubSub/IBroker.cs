using System.Collections.Generic;
using Mirror;

namespace Network.PubSub
{
    /// <summary>
    /// Договор брокера
    /// Посредник между pub и sub
    /// 1. Предоставляет информацию о доступных подписках (опционально)
    /// 2. Подписывает/отписывает клиента на сообщение (Topic)
    /// 3. Рассылает сообщения по клиентам 
    /// </summary>
    public interface IBroker
    {
        /// <summary>
        /// Список тем
        /// </summary>
        public IReadOnlyDictionary<string, HashSet<int>> Subscriptions { get; }

        /// <summary>
        /// Добавляет подписку
        /// </summary>
        /// <param name="id">Id подписчика</param>
        /// <param name="topic">Название темы</param>
        /// <returns>True если успешно подписался, иначе False</returns>>
        public bool Subscribe(string topic, int id);

        /// <summary>
        /// Удаляет подписку
        /// </summary>
        /// <param name="id">Id подписчика</param>
        /// <param name="topic">Название темы</param>
        /// <returns>True если успешно подписался, иначе False</returns>>
        public bool Unsubscribe(string topic, int id);

        /// <summary>
        /// Возвращает список подписчиков по теме
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public List<int> SubscribersByTopic(string topic);
        
        /// <summary>
        /// Добавляет тему
        /// </summary>
        /// <param name="topic"></param>
        public void AddTopic(string topic);
        
        /// <summary>
        /// Удаляет тему
        /// </summary>
        /// <param name="topic"></param>
        public void RemoveTopic(string topic);
    }
}