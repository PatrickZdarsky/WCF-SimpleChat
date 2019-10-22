using System;
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
        /// <returns>The ID of the sent message</returns>
        [OperationContract]
        int SendMessage(ChatMessage chatMessage);

        /// <summary>
        /// Register a client on the server
        /// </summary>
        /// <param name="address">The address of the client TwoWay WCF Service Endpoint</param>
        /// <param name="userName">The name of the user</param>
        [OperationContract]
        void Register(string address, string userName);
    }
}