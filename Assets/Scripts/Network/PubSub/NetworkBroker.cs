using System;
using System.Collections.Generic;
using Mirror;
using Network.Messages;
using Utils.Services;

namespace Network.PubSub
{
    /// <summary>
    /// Сетевой брокер Mirror
    /// </summary>
    public class NetworkBroker : IBroker , IBrokerEvents , IService
    {
        public IReadOnlyDictionary<string, HashSet<int>> Subscriptions => _subscriptions;
        public event Action OnTopicChange;
        
        /// <summary>
        /// TODO не потокобезопасный, работаем синхронно
        /// </summary>
        private readonly Dictionary<string, HashSet<int>> _subscriptions = new();

        public void InitService()
        {
            NetworkServer.RegisterHandler<SubscribeMessage>(OnSubscribeMessage);
        }


        public bool Subscribe(string topic, int id)
        {
            if (!_subscriptions.TryGetValue(topic, out var subscription)) return false;
            subscription.Add(id);
            OnTopicChange?.Invoke();
            return true;
        }

        public bool Unsubscribe(string topic, int id)
        {
            if (!_subscriptions.TryGetValue(topic, out var subscription)) return false;
            subscription.Remove(id);
            OnTopicChange?.Invoke();
            return true;
        }

        public List<int> SubscribersByTopic(string topic)
        {
            if (_subscriptions.TryGetValue(topic, out var ids)) return new List<int>(ids);
            return null;
        }

        public void AddTopic(string topic)
        {
            if (_subscriptions.ContainsKey(topic)) return;
            _subscriptions.Add(topic, new HashSet<int>());
            OnTopicChange?.Invoke();
        }

        public void RemoveTopic(string topic)
        {
            if (!_subscriptions.Remove(topic)) return;
            OnTopicChange?.Invoke();
        }

        private void OnSubscribeMessage(NetworkConnectionToClient connectionToClient, SubscribeMessage  message)
        {
            if(message.IsSubscribe) Subscribe(message.Topic, connectionToClient.connectionId);
            else Unsubscribe(message.Topic, connectionToClient.connectionId);
        }

    }
}