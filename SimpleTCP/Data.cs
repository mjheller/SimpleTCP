using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    [Serializable]
    public class Data
    {
        
        public string SenderIP { get; set; } 
        public string RecipientIP{ get; set; }
        public string Protocol{ get; set; }
        public string Message { get; set; }


        public Data(string senderIP, string recipientIP, string protocol, string message)
        {
            this.SenderIP = senderIP;
            this.RecipientIP = recipientIP;
            this.Protocol = protocol;
            this.Message = message;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
