using System.ServiceModel;

namespace ChatLib
{
    /// <summary>
    /// The WCF Interface which is implemented on the ChatClient for a Two-Way chat.
    /// </summary>
    [ServiceContract]
    public interface IChatClient
    {
        /// <summary>
        /// A new message should be displayed on the client
        /// </summary>
        /// <param name="chatMessage">The new Message</param>
        [OperationContract]
        void NewMessage(ChatMessage chatMessage);
    }
}