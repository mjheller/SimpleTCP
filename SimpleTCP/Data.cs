using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    class Data
    {
        private string senderIP;
        private string recipientIP;
        private string protocol;
        private object message;
        public string SenderIP { get {return senderIP;} set{ senderIP = value;}}
        public string RecipientIP { get { return SenderIP; } set { SenderIP = value; } }
        public string Protocol { get { return protocol; } set { protocol = value; } }
        public Object Message { get { return message; } set { message = value; } }

    
        public Data(string SenderIP, string RecipientIp, string Protocol, string message)
        {
            this.senderIP = SenderIP;
            this.recipientIP = RecipientIP;
            this.protocol = Protocol;
            this.message = Message;
        }

    }
}
