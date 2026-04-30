namespace Logging
{
    public class Logger : Ilog
    {
        public void SendMessage(string message)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}