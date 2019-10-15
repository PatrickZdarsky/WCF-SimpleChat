using System.ServiceModel;

namespace ChatLib
{
    [ServiceContract]
    public interface IChatClient
    {
        [OperationContract]
        void NewMessage(ChatMessage chatMessage);
    }
}