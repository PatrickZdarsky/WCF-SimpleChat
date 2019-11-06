using System;
using System.Linq;
using ChatLib;

namespace ChatService
{
    class PollingChat : IPollingChat
    {
        public int GetLastMessageID()
        {
            try
            {
                //If no message has been saved, return 0 as the last ID,
                //otherwise return the ID of the latest Message
                return ChatManager.ChatMessages.Count == 0 ? 0 : ChatManager.ChatMessages.Last().ID;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public ChatMessage GetMessage(int id)
        {
            try
            {
                //Find the message with the given ID
                return ChatManager.ChatMessages.FindLast(message => message.ID == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public int SendMessage(ChatMessage chatMessage)
        {
            try
            {
                //Save Message and send the message to other connected clients
                ChatManager.SendMessage(chatMessage);
                return chatMessage.ID;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
