using System.ServiceModel;

namespace ChatLib
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        ChatMessage SendMessage(ChatMessage chatMessage);
    }
}