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
        /// Send a Message to the server, the returned message is the same one but with an ID
        ///
        /// The first message that the client sends is also used to register the client.
        /// A NULL message is typically sent as the first message in order to register the client
        /// </summary>
        /// <param name="chatMessage">The message to send</param>
        /// <returns>The same ChatMessage but with an ID</returns>
        [OperationContract]
        ChatMessage SendMessage(ChatMessage chatMessage);
    }
}