using System.ServiceModel;

namespace ChatLib
{
    /// <summary>
    /// Simple Chat using Polling
    /// </summary>
    [ServiceContract]
    public interface IPollingChat
    {
        /// <summary>
        /// Send a Message to the server, the returned message ist the same one but with an ID
        /// </summary>
        /// <param name="chatMessage">The message to send</param>
        /// <returns>The same ChatMessage but with an ID</returns>
        [OperationContract]
        ChatMessage SendMessage(ChatMessage chatMessage);

        /// <summary>
        /// Query the server for the last message id
        /// </summary>
        /// <returns>The message ID of the last message</returns>
        [OperationContract]
        int GetLastMessageID();

        /// <summary>
        /// Query a message by ID
        /// </summary>
        /// <param name="id">The ID of the message</param>
        /// <returns>The message with the given ID or NULL if no message was found</returns>
        [OperationContract]
        ChatMessage GetMessage(int id);
    }
}
