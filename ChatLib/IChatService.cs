using System.ServiceModel;

namespace ChatLib
{
    /// <summary>
    /// WCF Interface for Two-Way Chat
    /// </summary>
    [ServiceContract]
    public interface IChatService
    {
        /// <summary>
        /// Send a Message to the server, the returned message ist the same one but with an ID
        /// </summary>
        /// <param name="chatMessage">The message to send</param>
        /// <returns>The same ChatMessage but with an ID</returns>
        [OperationContract]
        ChatMessage SendMessage(ChatMessage chatMessage);
    }
}