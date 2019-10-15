using System.Linq;
using ChatService;

namespace ChatLib
{
    class SimpleChat : ISimpleChat
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
