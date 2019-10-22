using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    [DataContract]
    [Serializable]
    public class ChatMessage
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
