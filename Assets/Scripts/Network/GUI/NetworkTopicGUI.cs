using System;
using System.Text;
using Network.PubSub;
using UnityEngine;
using TMPro;
using Zenject;

namespace Network.GUI
{
    public class NetworkTopicGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        
        private IBrokerEvents _brokerEvents;
        private IBroker _broker;
        
        [Inject]
        private void Construct(IBrokerEvents  brokerEvents, IBroker broker)
        {
            _brokerEvents = brokerEvents;
            _broker = broker;
            
            _brokerEvents.OnTopicChange += BrokerEventsOnOnTopicChange;
        }
        
        private void BrokerEventsOnOnTopicChange()
        {
            StringBuilder lableText = new StringBuilder();

            foreach (var topic in _broker.Subscriptions)
            {
                lableText.AppendLine($"Topic: {topic.Key}");
                foreach (var id in topic.Value)
                {
                    lableText.AppendLine($"     id: {id}");
                }
            }
            
            _label.text = lableText.ToString();
        }
    }
}