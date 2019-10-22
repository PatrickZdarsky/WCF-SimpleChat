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

        public static ChatUser GetUserOrRegisterNew(string address)
        {
            var chatUser = ChatUsers.Find(user => user.IpAddress == address);
            if (chatUser == null)
            {
                chatUser = new ChatUser(address);
                chatUser.Connect();
                ChatUsers.Add(chatUser);
            }

            return chatUser;
        }
    }
}