using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Timers;
using ChatClient.PollingChat;
using ChatLib;

namespace ChatClient
{
    class PollingChatHandler : ChatServiceHandler
    {
        //Initial value => We received no message
        private int lastMessageID = -1;

        private PollingChatClient apiClient;


        public PollingChatHandler(string address, string userName, TimeSpan interval) : base(address, userName)
        {
            var timer = new Timer(interval.TotalMilliseconds);
            timer.Elapsed += Update;
            timer.Start();

            try
            {
                apiClient = new PollingChatClient(new BasicHttpBinding(),
                    new EndpointAddress(address));
//                    apiClient = new PollingChatClient("BasicHttpBinding_IPollingChat");
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void Open()
        {
            //Get initial messageID
            lastMessageID = apiClient.GetLastMessageID();
            //Register user
            SendMessage(new ChatMessage
            {
                UserName = UserName,
                Message = null,
                DateTime = DateTime.Now
            });
        }

        private void Update(object sender, ElapsedEventArgs e)
        {
            //If we still aren't connected cancel update
            if (!loaded)
                return;

            var lastServerMessage = apiClient.GetLastMessageID();
            //Checking if there are new Messages on the server
            if (lastServerMessage > lastMessageID)
            {
                //Get all new messages
                for (var i = lastMessageID + 1; i <= lastServerMessage; i++)
                {
                    var message = apiClient.GetMessage(i);
                    if (message != null)
                        AddMessage(message);
                }
            }

            lastMessageID = lastServerMessage;
        }

        public override void SendMessage(ChatMessage chatMessage)
        {
            var updatedMessage = apiClient.SendMessage(chatMessage);
            lastMessageID = updatedMessage;
            AddMessage(chatMessage);
        }
    }
}
