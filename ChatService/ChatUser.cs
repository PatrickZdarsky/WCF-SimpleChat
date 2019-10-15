using System;
using ChatLib;

namespace ChatService
{
    public class ChatUser
    {
        public String IpAddress { get; set; }
        
        public string UserName { get; set; }

        public ChatUser(string ipAddress)
        {
            IpAddress = ipAddress;
        }


        public void Connect()
        {
            
        }

        public void SendMessage(ChatMessage chatMessage)
        {
            
        }
    }
}