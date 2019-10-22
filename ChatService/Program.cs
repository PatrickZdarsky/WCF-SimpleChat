using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ChatLib;

namespace ChatService
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatManager.Init();
            
            Console.WriteLine(" == Chat-Service by Patrick Zdarsky 2019 ==");
            Console.WriteLine("Starting Polling-Service...");
            var pollingService = new ServiceHost(typeof(PollingChat));
            pollingService.Open();
            Console.WriteLine("Starting Two-Way ChatService...");
            var chatService = new ServiceHost(typeof(ChatService));
            chatService.Open();
            Console.WriteLine("Chat Service started! Press any key to stop service...");

            Console.ReadLine();

            pollingService.Close();
            chatService.Close();
        }
    }
}
