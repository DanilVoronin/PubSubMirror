using System;
using Network.Messages;
using Network.PubSub;
using UnityEngine;
using Zenject;

namespace Sources
{
    /// <summary>
    /// Источник сообщения HelloMessage
    /// </summary>
    public class SourcesHelloMessage : MonoBehaviour
    {
        private IPublisher _publisher;
        private IBroker _broker;
        
        [Inject]
        private void Construict(IPublisher  publisher, IBroker broker)
        {
            _publisher =  publisher;
            _broker =  broker;
        }

        public void Send()
        {
            _publisher.Publish(typeof(HelloMessage).ToString(), new HelloMessage(){Message = "Hello Client!"});
        }

        private void OnEnable()
        {
            _broker.AddTopic(typeof(HelloMessage).ToString());
        }
        
        private void OnDisable()
        {
            _broker.RemoveTopic(typeof(HelloMessage).ToString());
        }
    }
}