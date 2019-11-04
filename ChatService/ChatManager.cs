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
                    user.SendMessage(chatMessage);
            });
        }

        public static ChatUser getUser(string userName)
        {
            return ChatUsers.Find(user => user.UserName == userName);
        }

        public static void RegisterNew(string address, string userName)
        {
            var chatUser = new ChatUser(address) {UserName = userName};
            chatUser.Connect();
            ChatUsers.Add(chatUser);
        }
    }
}