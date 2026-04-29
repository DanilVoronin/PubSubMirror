using Mirror;

namespace Net.Messages
{
    public struct TestMessage : NetworkMessage
    {
        public string Message { get; set; }
    }
}