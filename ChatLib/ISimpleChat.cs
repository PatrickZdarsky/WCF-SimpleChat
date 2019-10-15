using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    /// <summary>
    /// Simple Chat using Polling
    /// </summary>
    [ServiceContract]
    public interface ISimpleChat
    {
        [OperationContract]
        ChatMessage SendMessage(ChatMessage chatMessage);

        [OperationContract]
        int GetLastMessageID();

        [OperationContract]
        ChatMessage GetMessage(int id);
    }
}
