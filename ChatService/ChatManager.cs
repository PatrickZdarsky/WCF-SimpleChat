using System;
using System.Collections.Generic;
using ChatLib;

namespace ChatService
{
    public class ChatManager
    {
        public static List<ChatMessage> ChatMessages { get; private set; }
        
        public static List<ChatUser> ChatUsers { get; private set; }

        public static void Init()
        {
            ChatMessages = new List<ChatMessage>();
            ChatUsers = new List<ChatUser>();
        }

        public static void SendMessage(ChatMessage chatMessage)
        {
            ChatMessages.Add(chatMessage);
            chatMessage.ID = ChatMessages.IndexOf(chatMessage);

            ChatUsers.ForEach(user =>
            {
                if (user.UserName != chatMessage.UserName)
                    try
                    {
                        user.SendMessage(chatMessage);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
            });
            Console.WriteLine(chatMessage.DateTime + " | "+chatMessage.UserName + " > " + chatMessage.Message);
        }

        public static void RemoveUser(ChatUser chatUser)
        {
            ChatUsers.Remove(chatUser);
        }

        public static void RegisterNew(string address, string userName)
        {
            var chatUser = new ChatUser(address) {UserName = userName};
            chatUser.Connect();
            ChatUsers.Add(chatUser);
            Console.WriteLine(userName + " with service at" + address +" connected as TwoWay!");
        }
    }
}