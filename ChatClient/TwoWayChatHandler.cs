using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using ChatClient.Chat;
using ChatLib;

namespace ChatClient
{
    public class TwoWayChatHandler : ChatServiceHandler
    {
        public static TwoWayChatHandler ChatHandler;

        private ChatServiceClient apiClient;

        public TwoWayChatHandler(string address, string userName) : base(address, userName)
        {
            ChatHandler = this;
            try
            {
                var service = new ServiceHost(typeof(ChatClientImpl));
                service.Opening += (sender, args) =>
                {
                    Console.WriteLine("Service Opening!");
                };
                service.Opened += (sender, args) =>
                {
                    Console.WriteLine("Service Opened!");
                };
                service.Open();

               // Thread.Sleep(6000000);
               // apiClient = new ChatServiceClient(new BasicHttpsBinding(), new EndpointAddress(address));
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void Open()
        {
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