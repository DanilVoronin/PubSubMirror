using System;
using System.Collections.Generic;
using Mirror;

namespace Net.PubSub
{
    /// <summary>
    /// Посредник между pub и sub
    /// 1. Предоставляет информацию о доступных подписках (опционально)
    /// 2. Подписывает/отписывает клиента на сообщение (Topic)
    /// 3. Рассылает сообщения по клиентам 
    /// </summary>
    public class Broker : NetworkBehaviour
    { 
        /// <summary>
        /// Темы на которые подписываются клиенты
        /// </summary>
        private Dictionary<Type, Topic>  _topics = new();

        
        public void Construct()
        {
            //NetworkServer.RegisterHandler();
        }
    }
}