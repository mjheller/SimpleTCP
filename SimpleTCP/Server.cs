using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    public class Server
    {
        private string _IP;
        private int _port;
        public string IP { get { return _IP; } set { _IP = value; } }
        public int port { get { return port; } set { _port = value; } }
        public Server(string serverIP, int serverPort)
        {
            this.IP = serverIP;
            this.port = serverPort;
        }

    }
}
