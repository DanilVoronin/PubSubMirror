using Mirror;
using Net.Messages;
using UnityEngine;

namespace Net
{
    public class NetManager : NetworkManager
    {
        public override void OnClientConnect()
        {
            base.OnClientConnect();
            NetworkClient.RegisterHandler<HelloMessage>(OnHelloMessage);
        }

        public void OnHelloMessage(
            HelloMessage message)
        {
            print($"Message: {message.Message}");
        }
    
        [ContextMenu("SendHelloMessage")]
        public void SendHelloMessage()
        {
            NetworkServer.SendToAll(new  HelloMessage()
            {
                Message = "Hello Net Network Server!"
            });
        }
        
        [ContextMenu("SendTestMessage")]
        public void SendTestMessage()
        {
            NetworkServer.SendToAll(new  TestMessage()
            {
                Message = "Test Network Server!"
            });
        }
    }
}