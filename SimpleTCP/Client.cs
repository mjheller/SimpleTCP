using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    public class Client
    {
        
        //public Client(string clientIP, int clientPort)
        //{
        //    this.IP = clientIP;
        //    this.port = clientPort;
        //    Server server = new Server("127.0.0.1", 12345); // might not need to instantiate, rather server ip/port be client member variables
        //    Data<string> helloWorld = new Data<string>("Hello World"); // should set data to static class that recognizes type of data in input and automatically sets it up to send
        //    Payload<Data<string>> packetData = new Payload<Data<string>>(helloWorld);
        //    //TCPPacketHeader TCPHeader = new TCPPacketHeader(this.IP, this.port, server.IP, server.port);
        //}
        //public void send(Data<object> message)
        //{
            //socket.send(server.IP, server.Port)
        //}
        //public Data<object> receive()
        //{
        //    message = socket.recv(Server.IP, Server.port)
        //    return message;
        //}
    }
}
