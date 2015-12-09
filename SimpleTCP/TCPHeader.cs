using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;

namespace SimpleTCP
{
    class TCPHeader
    { // get,set member variables
        // Everything should be a BitArray
        private BitArray _version = new BitArray(4);
        private BitArray _IHL = new BitArray(4);
        private BitArray _TypeOfService = new BitArray(8);
        private BitArray _TotalLength { get; set; }
        //Int16 Identification { get; set; }
        private BitArray _Flags = new BitArray(9); //3
        //BitArray FragmentOffset = new BitArray(13); //13
        //BitArray Protocol = new BitArray(16);
        private BitArray _HeaderChecksum = new BitArray(16);
        private BitArray _SrcAddress = new BitArray(32);
        private BitArray _DestAddress = new BitArray(32);
        private BitArray _Options = new BitArray(320);
        //BitArray Padding = new BitArray();
        private BitArray _SrcPort = new BitArray(16);
        private BitArray _DestPort = new BitArray(16);
        private BitArray _SeqNumber = new BitArray(16);
        private BitArray _AckNumber = new BitArray(32);
        private BitArray _DataOffset = new BitArray(4);
        private BitArray _WindowSize = new BitArray(16); //maximum amount of received data, in bytes, that can be buffered at one time on the receiving side of a connection
        private BitArray _Checksum = new BitArray(16);
        private BitArray _UrgentPointer = new BitArray(16); //pointer tell how many bytes of the data is urgent in the segment that has arrived. 

        public BitArray SrcAddress { get { return _SrcAddress;} set{ _SrcAddress = value; } }
        public BitArray DestAddress { get { return _DestAddress; } set { _DestAddress = value; } }
        public BitArray SrcPort { get { return _SrcPort; } set { _SrcPort = value; } }
        public BitArray DestPort { get { return _SrcPort; } set { _SrcPort = value; } }
        public TCPHeader(int sourcePort, int destinationPort, string sourceAddress, string destAddress)
        {

            this.SrcPort = new BitArray(convertIntToByte(sourcePort));
            this.DestPort = new BitArray(convertIntToByte(destinationPort));
            this.SrcAddress = new BitArray(convertIPAddrToBytes(sourceAddress));
            this.DestAddress = new BitArray(convertIPAddrToBytes(destAddress));
               
        }
    
    public byte[] convertIPAddrToBytes(string address)
        {
            IPAddress ip = IPAddress.Parse(address);
            byte[] ipByteArray = ip.GetAddressBytes();
            return ipByteArray;  
        }
    public byte convertIntToByte(int num)
        {
            byte intByte = Convert.ToByte(num);
            return intByte;
        }
    }
}






//BitArray version
//{ get; set; } //4
//BitArray IHL
//{ get; set; } //4
//BitArray TypeOfService
//{ get; set; } //8
//byte[] TotalLength
//{ get; set; }
//Int16 Identification
//{ get; set; }
//BitArray Flags
//{ get; set; } //3
//BitArray FragmentOffset
//{ get; set; } //13
//int TimeToLive
//{ get; set; }
//string Protocol
//{ get; set; } //will end up as an 16 int?
//Int16 HeaderChecksum
//{ get; set; }
//BitArray SrcAddress
//{ get; set; } //will be int32
//BitArray DestAddress
//{ get; set; }//will be int32
//BitArray Options
//{ get; set; }
//BitArray Padding
//{ get; set; }
//Int16 SrcPort
//{ get; set; }
//Int16 DestPort
//{ get; set; }
//int SeqNumber
//{ get; set; }
//int AckNumber
//{ get; set; }
//List<int> DataOffset
//{ get; set; }
//Int16 Window
//{ get; set; } //maximum amount of received data, in bytes, that can be buffered at one time on the receiving side of a connection
//Int16 Checksum
//{ get; set; }
//Int16 UrgentPointer
//{ get; set; } //pointer tell how many bytes of the data is urgent in the segment that has arrived. 
//BitArray tcpOptions
//{ get; set; }
//Int16 tcpData
