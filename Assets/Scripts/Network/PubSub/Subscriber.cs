using Mirror;
using Network.Messages;
using UnityEngine;

namespace Network.PubSub
{
    /// <summary>
    /// Подписчик
    /// Для подписки на сообщения нужно унаследоваться от этого класса
    /// TODO надо бы еще добавить подтверждение отписки 
    /// </summary>
    public abstract class Subscriber<Topic> : MonoBehaviour where Topic : struct, NetworkMessage
    {
        public void Subscribe()
        {
            if (NetworkClient.active)
            {
                NetworkClient.RegisterHandler<Topic>(OnMessageReceived);
                NetworkClient.Send(new SubscribeMessage(){Topic = typeof(Topic).ToString(), IsSubscribe =  true});
            }
        }
        
        public void Unsubscribe()
        {
            if (NetworkClient.active)
            {
                NetworkClient.Send(new SubscribeMessage(){Topic = typeof(Topic).ToString(), IsSubscribe =  false});
                NetworkClient.UnregisterHandler<Topic>();
            }
        }

        protected virtual void OnMessageReceived(Topic msg)
        {
        }
    }
}