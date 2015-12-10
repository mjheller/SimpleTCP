using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;

namespace Test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Data<string> data = new Data<string>("Hello World!");
            PacketData<Data<string>> packetData = new PacketData<Data<string>>(data);
            
            foreach (byte b in packetData.byteArray)
            {
                var bit = Convert.ToString(b, 2);
                Console.Write(bit);
                //Console.Write(b.GetTypeCode());
            }

           // Data nonbytes = (Data)packetData.ByteArrayToObject(packetData.byteArray);
            //Console.WriteLine(nonbytes.Message);
            //string wait = Console.ReadLine();
        }
    }
}
