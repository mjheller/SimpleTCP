using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;

namespace SimpleTCP
{
    public class TCPPacketHeader
    {
        private byte[] _SrcAddress;
        private byte[] _DestAddress;
        private ushort _SrcPort;
        //private BitArray _TotalLength = new BitArray() { get; set; } //packet header + packet data
        private ushort _DestPort;
        private uint _SeqNumber;
        private uint _AckNumber;
        private BitArray _Reserved = new BitArray(3);
        private BitArray _DataOffset = new BitArray(4);
        private BitArray _FlagAssign = new BitArray(9);
        private byte[] _FlagBytes;
        private ushort _WindowSize;
        private BitArray _Checksum = new BitArray(16);
        private BitArray _UrgentPointer = new BitArray(16);
        private BitArray _Options = new BitArray(320);
        private BitArray _Version = new BitArray(4);
        private BitArray _TypeOfService = new BitArray(8);
        //BitArray Padding = new BitArray();
        private byte[] _PseudoHeader;


        public byte[] SrcAddress { get { return _SrcAddress;} set{ _SrcAddress = value; } }
        public byte[] DestAddress { get { return _DestAddress; } set { _DestAddress = value; } }
        public ushort SrcPort { get { return _SrcPort; } set { _SrcPort = value; } }
        public ushort DestPort { get { return _SrcPort; } set { _SrcPort = value; } }
        public uint SeqNumber{ get { return _SeqNumber; } set { _SeqNumber = value; } }
        public uint AckNumber{ get { return _AckNumber; } set { _AckNumber = value; } }
        public BitArray Reserved { get { return _Reserved; } set { _Reserved = value; } } //
        public BitArray DataOffset { get { return _DataOffset; } set { _DataOffset = value; } } //
        public BitArray FlagAssign { get { return _FlagAssign; } set { _FlagAssign = value; } }
        public byte[] FlagBytes { get { return _FlagBytes; } set { _FlagBytes = value; } }
        public ushort WindowSize { get { return _WindowSize; } set { _WindowSize = value; } } //
        
        public byte[] CheckSum{ get { return _Checksum; } set { _Checksum = value; } }
        public byte[] UrgentPointer { get { return _UrgentPointer; } set { _UrgentPointer = value; } }
        public byte[] Options { get { return _Options; } set { _Options = value; } }
        
        
        public byte[] PseudoHeader { get { return _PseudoHeader; } set { _PseudoHeader = value; } }
        
        public byte[] headerBytes { get; set; }
        
        

        //set individual flags as member variables, and then set property to change the individual bits in the _Flags byte[] that corresponds to the flag changed

        public TCPPacketHeader(int sourcePort, int destinationPort, int sequenceNumber, int ackNumber, bool[] flagArgs, int window, BitArray packetData, int urgentPointerMarker)
        {
            this.SrcPort = convertIntToUshort(sourcePort);
            this.DestPort = convertIntToUshort(destinationPort);
            this.SeqNumber = Convert.ToUInt32(sequenceNumber);
            this.AckNumber = Convert.ToUInt32(ackNumber);
            this.DataOffset = SetNoOptionDataOffset();
            this.Reserved = new BitArray(3, false);
            this.WindowSize = convertIntToUshort(window);
            this.CheckSum = SetCheckSum(packetData);
            this.FlagBytes = this.setFlags(flagArgs);
            // this.DataOffset = // data + header = packetData.Length
            this.UrgentPointer = BitConverter.GetBytes(convertIntToUshort(urgentPointerMarker));
            this.headerBytes = this.collectAllHeader().ToArray();
            ;

            

        }
        private BitArray SetNoOptionDataOffset()
        {
            BitArray five = new BitArray(4);
            five.Set(1, true);
            five.Set(3, true);
            return five;
        }
        private List<byte> collectAllHeader()
        {
            List<byte> header = new List<byte>();
            byte[] SrcPort = BitConverter.GetBytes(this.SrcPort); //SourcePort
            foreach(byte srcport in SrcPort){ header.Add(srcport);}
            byte[] DestPort = BitConverter.GetBytes(this.DestPort);
            foreach(byte destport in DestPort){ header.Add(destport);}
            byte[] SeqNumber = BitConverter.GetBytes(this.SeqNumber); //Sequence Number
            foreach (byte seqnumber in DestPort){ header.Add(seqnumber); }
            byte[] AckNumber = BitConverter.GetBytes(this.AckNumber); //Acknoledgement Number
            foreach (byte acknumber in DestPort){ header.Add(acknumber); }
            List<byte> combine16 = new List<byte>(); //DataOffset, Reserved, and Flags 16bits
            bool[] boolArray = this.DataOffset.Cast<bool>().Concat(this.Reserved.Cast<bool>()).Concat(this.FlagAssign.Cast<bool>()).ToArray();
            BitArray bits = new BitArray(boolArray);
            byte[] dataOffsetReservedFlags = BitArrayToByteArray(bits);
            foreach (byte b in dataOffsetReservedFlags){ header.Add(b);}
            byte[] windowSize = BitConverter.GetBytes(this.WindowSize); //WindowSize
            foreach (byte windowsize in DestPort){ header.Add(windowsize); }
            byte[] checkSum = this.CheckSum; // CheckSum
            foreach (byte checksum in checkSum){ header.Add(checksum);}
            foreach(byte urgentpointer in this.UrgentPointer){ header.Add(urgentpointer);} //UrgentPointer

            return header;
        }

        private byte[] setFlags(bool[] flags)
        {
            FlagAssign[0] = flags[0]; //NS
            FlagAssign[1] = flags[1]; //CWR
            FlagAssign[2] = flags[2]; //ECE
            FlagAssign[3] = flags[3]; //URG
            FlagAssign[4] = flags[4]; //ACK
            FlagAssign[5] = flags[5]; //PSH
            FlagAssign[6] = flags[6]; //RST
            FlagAssign[7] = flags[7]; //SYN
            FlagAssign[8] = flags[8]; //FIN
            byte[] flagArray = this.BitArrayToByteArray(FlagAssign);
            return flagArray;
        }
        private byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] bytes = new byte[Math.Max(1, bits.Length / 8)];
            bits.CopyTo(bytes, 0);
            return bytes;
        }

        public byte[] convertIPAddrToBytes(string address)
        {
            IPAddress ip = IPAddress.Parse(address);
            byte[] ipByteArray = ip.GetAddressBytes();
            return ipByteArray;  
        }
        public ushort convertIntToUshort(int num)
        {
            ushort intByte = Convert.ToUInt16(num);
            return intByte;
        }
   
       
        private byte[] SetCheckSum(BitArray packetData)
        {

            byte[] checkSum = BitArrayToByteArray(packetData.Length);
            return checkSum;
        }

        private void SetOptions(List<string> options)
        {
            foreach (string item in options)
            {
                string hexValue = item.Substring(2);

            }
        }
    }
}
