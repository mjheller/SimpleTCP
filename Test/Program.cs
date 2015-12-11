using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleTCP;
using System.Net;
using System.Net.Sockets;

namespace Test
{

    public class Program
    {

    

        static void Main(string[] args)
        {

            Payload<string> payload = new Payload<string>("Hello World!");
            Packet packet = new Packet(12345, 5000, 1, 1, new bool[9] { false, false, false, false, false, false, false, false, false }, 8000, 1, payload.packetBytes);
            
            
            Console.WriteLine(payload.ByteArrayToObject(payload.packetBytes));

            string wait = Console.ReadLine();
        }



        //Socket _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Tcp);
        //_Socket.Connect(IPAddress.Parse("10.2.20.46"));
        //if (_Socket.Connected)
        //{
        //    _Socket.Send(packet._bytes);
        //    _Socket.Receive(LoginReceiveByte1);
        //}

    }
}
