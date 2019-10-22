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
        ///
        /// The first message that the client sends is also used to register the client.
        /// A NULL message is typically sent as the first message in order to register the client
        /// </summary>
        /// <param name="chatMessage">The message to send</param>
        /// <returns>The ID of the sent message</returns>
        [OperationContract]
        int SendMessage(ChatMessage chatMessage);

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
