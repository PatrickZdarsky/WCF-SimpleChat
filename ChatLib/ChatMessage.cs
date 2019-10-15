using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    class ChatMessage
    {
        [DataMember]
        public DateTime dateTime { get; set; }
        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string message { get; set; }
    }
}
