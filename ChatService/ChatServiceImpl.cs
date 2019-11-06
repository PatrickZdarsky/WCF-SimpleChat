using ChatLib;

namespace ChatService
{
    public class ChatServiceImpl : IChatService
    {
        public int SendMessage(ChatMessage chatMessage)
        {
            //Send message to all other clients and set message ID
            ChatManager.SendMessage(chatMessage);
            //Return chatMessage with proper ID
            return chatMessage.ID;
        }

        public void Register(string address, string userName)
        {
            ChatManager.RegisterNew(address, userName);
        }
    }
}