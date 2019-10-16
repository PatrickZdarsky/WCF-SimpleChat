using System.Linq;
using ChatLib;

namespace ChatService
{
    class PollingChat : IPollingChat
    {
        public int GetLastMessageID()
        {
            return ChatManager.ChatMessages.Count == 0 ? 0 : ChatManager.ChatMessages.Last().ID;
        }

        public ChatMessage GetMessage(int id)
        {
            return ChatManager.ChatMessages.FindLast(message => message.ID == id);
        }

        public ChatMessage SendMessage(ChatMessage chatMessage)
        {
            ChatManager.ChatMessages.Add(chatMessage);
            chatMessage.ID = ChatManager.ChatMessages.IndexOf(chatMessage);
            return chatMessage;
        }
    }
}
