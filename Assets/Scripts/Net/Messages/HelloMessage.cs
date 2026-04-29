using Mirror;

namespace Net.Messages
{
    public struct HelloMessage : NetworkMessage
    {
        public string Message { get; set; }
    }
}