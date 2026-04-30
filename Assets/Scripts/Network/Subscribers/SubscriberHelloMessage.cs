using Network.Messages;

namespace Network.PubSub
{
    /// <summary>
    /// Сетевая подписка, располагается на клиенте
    /// </summary>
    public class SubscriberHelloMessage : Subscriber<HelloMessage>
    {
        protected override void OnMessageReceived(HelloMessage msg)
        {
            print(msg.Message);
        }
    }
}