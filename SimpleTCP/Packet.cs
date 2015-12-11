using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    public class Packet<T>
    {
        public byte[] _IPPacketHeader { get; private set; }
        public byte[] _TCPpacketHeader{ get; private set; }
        public byte[] _packetData{ get; private set; }
        //public BitArray _bits{ get; private set; }
        public byte[] _bytes{ get; private set; }
        public T _data{ get; private set; }

        //public Packet(T Data)
        //{
        //    this._data = Data;
        //}

        public Packet(IPPacketHeader IPHeader, TCPPacketHeader TCPHeader, PacketData<T> Data)
        {
            this._IPPacketHeader = IPHeader.headerBytes;
            this._TCPpacketHeader = TCPHeader.headerBytes;
            
            this._packetData = Data.packetBytes;
        }

        public void SetPacketHeaderIP(int version, bool[] TOSFlags, BitArray bodyData, ushort idNumber, bool[] flags, BitArray fragOffset, string sourceAddress, string destinationAddress)
        {
            IPPacketHeader ipHeader = new IPPacketHeader(version, TOSFlags, bodyData, idNumber, flags, fragOffset, sourceAddress, destinationAddress);
            _IPPacketHeader = ipHeader.headerBytes;
            ;
        }

        public void SetPacketHeaderTCP(ushort sourcePort, ushort destinationPort, int sequenceNumber, int ackNumber, bool[] flagArgs, ushort windowSize, BitArray bodyData, ushort urgentPointerMarker)
        {
            TCPPacketHeader tcpHeader = new TCPPacketHeader(sourcePort, destinationPort, sequenceNumber, ackNumber, flagArgs, windowSize, bodyData, urgentPointerMarker);
            _TCPpacketHeader = tcpHeader.headerBytes;
        }

        public void SetPacketBody(T _data)
        {
            PacketData<T> packetData = new PacketData<T>(_data);
            _packetData = packetData.packetBytes;
        }

        public void SetFinalPacket()
        {
            bool[] finalBitArr = _IPPacketHeader.Cast<bool>().Concat(_TCPpacketHeader.Cast<bool>()).Concat(_packetData.Cast<bool>()).ToArray();
            BitArray finalBits = new BitArray(finalBitArr);
            _bytes = BitArrayToByteArray(finalBits);
        }

        private byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] bytes = new byte[Math.Max(1, bits.Length / 8)];
            bits.CopyTo(bytes, 0);
            return bytes;
        }
    }
}
