using System.ServiceModel;
using System.ServiceModel.Channels;
using ChatLib;

namespace ChatService
{
    public class ChatService : IChatService
    {
        public int SendMessage(ChatMessage chatMessage)
        {
            //Get Client IP-Address
            var context = OperationContext.Current;
            var messageProperties = context.IncomingMessageProperties;
            var messageProperty = (RemoteEndpointMessageProperty)messageProperties[RemoteEndpointMessageProperty.Name];

            //Create ChatUser if the user is new
            ChatManager.GetUserOrRegisterNew(messageProperty.Address);
            //Send message to all other clients and set message ID
            ChatManager.SendMessage(chatMessage);
            //Return chatMessage with proper ID
            return chatMessage.ID;
        }
    }
}