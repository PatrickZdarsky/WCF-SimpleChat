using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using ChatClient.Chat;
using ChatLib;

namespace ChatClient
{
    public class TwoWayChatHandler : ChatServiceHandler
    {
        public static TwoWayChatHandler ChatHandler;
        private ServiceHost serviceHost;
        private string localAdress;

        private ChatServiceClient apiClient;

        public TwoWayChatHandler(string address, string userName) : base(address, userName)
        {
            ChatHandler = this;
            try
            {
                localAdress = "http://localhost:" + Utils.GetAvailablePort() + "/ChatClient";
                serviceHost = new ServiceHost(typeof(ChatClientImpl), new Uri(localAdress));
                serviceHost.Open();

               // Thread.Sleep(6000000)
               apiClient = new ChatServiceClient(new BasicHttpBinding(), new EndpointAddress(address));
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void Open()
        {
            apiClient.Register(localAdress, UserName);
            //Register user
            SendMessage(new ChatMessage
            {
                UserName = UserName,
                Message = null,
                DateTime = DateTime.Now
            });
        }

        public override void SendMessage(ChatMessage chatMessage)
        {
            apiClient.SendMessage(chatMessage);
        }

        public void NewMessage(ChatMessage chatMessage)
        {
            AddMessage(chatMessage);
        }
    }

    [ServiceBehavior(UseSynchronizationContext=false)]
    public class ChatClientImpl : IChatClient
    {
        public void NewMessage(ChatMessage chatMessage)
        {
            TwoWayChatHandler.ChatHandler.NewMessage(chatMessage);
        }
    }
}