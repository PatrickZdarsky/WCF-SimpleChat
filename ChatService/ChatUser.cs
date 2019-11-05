using System.ServiceModel;
using ChatLib;
using ChatService.ChatUserService;

namespace ChatService
{
    public class ChatUser
    {
        public string IpAddress { get; set; }
        
        public string UserName { get; set; }

        private ChatClientClient _chatClientClient;

        public ChatUser(string ipAddress)
        {
            IpAddress = ipAddress;
        }


        public void Connect()
        {
            _chatClientClient = new ChatClientClient(new BasicHttpBinding(), new EndpointAddress(IpAddress));
        }

        public void SendMessage(ChatMessage chatMessage)
        {
            _chatClientClient.NewMessage(chatMessage);
        }
    }
}