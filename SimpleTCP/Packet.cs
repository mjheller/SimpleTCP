using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    public class Packet
    {
        public byte[] _IPPacketHeader { get; private set; }
        public byte[] _TCPpacketHeader{ get; private set; }
        public byte[] _payload{ get; private set; }
        
        public byte[] _bytes{ get; private set; }
        //public T _data{ get; private set; }

        
        public Packet(int sourcePort, int destinationPort, int sequenceNumber, int ackNumber, bool[] flagArgs, int window,int urgentPointerMarker, byte[] Data)
        {
            SetPacketHeaderTCP(sourcePort, destinationPort, sequenceNumber, ackNumber, flagArgs, window, urgentPointerMarker, Data);
            this._payload = Data; 
        }
        

        //public Packet(IPPacketHeader IPHeader, TCPPacketHeader TCPHeader, Payload<T> Data)
        //{
        //    this._IPPacketHeader = IPHeader.headerBytes;
        //    this._TCPpacketHeader = TCPHeader.headerBytes;

        //    this._payload = Data.packetBytes;
        //}

        public void SetPacketHeaderIP(int version, bool[] TOSFlags, BitArray bodyData, ushort idNumber, bool[] flags, BitArray fragOffset, string sourceAddress, string destinationAddress)
        {
            IPPacketHeader ipHeader = new IPPacketHeader(version, TOSFlags, bodyData, idNumber, flags, fragOffset, sourceAddress, destinationAddress);
            _IPPacketHeader = ipHeader.headerBytes;
            ;
        }

        public void SetPacketHeaderTCP(int sourcePort, int destinationPort, int sequenceNumber, int ackNumber, bool[] flagArgs, int window, int urgentPointerMarker, byte[] packetBody)
        {
            TCPPacketHeader tcpHeader = new TCPPacketHeader(sourcePort, destinationPort, sequenceNumber, ackNumber, flagArgs, window, urgentPointerMarker, packetBody);
            this._TCPpacketHeader = tcpHeader.headerBytes;
        }

        

        private byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] bytes = new byte[Math.Max(1, bits.Length / 8)];
            bits.CopyTo(bytes, 0);
            return bytes;
        }
    }
}
