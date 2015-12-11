using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;

namespace SimpleTCP
{
    public class IPPacketHeader
    {
        private byte[] _SrcAddress;
        private byte[] _DestAddress;


        public BitArray Version { get; private set; } // 4 Bits
        public bool[] IHL { get; private set; } // 4 Bits
        public BitArray TypeOfService  { get; private set; } // 8 Bits
        public BitArray TotalLength    { get; private set; } // 16 Bits
        public byte[] Identification { get; private set; } // 16 Bits
        public BitArray Flags  { get; private set; } // 3 Bits
        public BitArray FragmentOffset { get; private set; } // 13 Bits
        public byte TimeToLive { get; private set; } // 8 Bits
        public byte Protocol   { get; private set; } // 8 Bits
        public byte[] CheckSum   { get; private set; } // 16 Bits
        public byte[] SourceAddress  { get; private set; } // 32 Bits
        public byte[] DestinationAddress { get; private set; } // 32 Bits
        public BitArray Options    { get; private set; } // Fuck Options. Includes Padding
        public byte[] headerBytes   { get; private set; }

        // Total Bits Without Options: 160
        
        public IPPacketHeader(int version, bool[] TOSFlags, BitArray bodyData, ushort idNumber, bool[] flags, BitArray fragOffset, string sourceAddress, string destinationAddress)
        {
            this.Version = SetVersion(version); // 4
            this.IHL = new bool[] { false, true, false, true }; // 4 (0101 = 5) field is 5 when no options present
            this.TypeOfService = new BitArray(TOSFlags); // 8 
            this.TotalLength = SetTotalLength(bodyData); // 16 should be both data and header, total packet size
            this.Identification = BitConverter.GetBytes(idNumber); // 16
            this.Flags = new BitArray(flags); // 3
            this.FragmentOffset = fragOffset; // 13
            this.TimeToLive =  Convert.ToByte(20); // 8
            this.Protocol = Convert.ToByte(6); // 8
            this.SourceAddress = convertIPAddrToBytes(sourceAddress);
            this.DestinationAddress = convertIPAddrToBytes(destinationAddress); // 32
            this.CheckSum = SetCheckSum();
            this.headerBytes = setIPHeaderBytes().ToArray();
        }


        private List<byte> setIPHeaderBytes()
        {
            List<byte> header = new List<byte>(); 
            bool[] boolArray = Version.Cast<bool>().Concat(IHL.Cast<bool>()).Concat(TypeOfService.Cast<bool>()).ToArray();
            BitArray bits = new BitArray(boolArray); // Version, IHL, TypeOfService
            byte[] VersionIHLService = BitArrayToByteArray(bits);
            foreach(byte b in VersionIHLService){ header.Add(b);}
            byte[] totalLength = BitArrayToByteArray(this.TotalLength); //TotalLength
            foreach(byte totallength in totalLength) { header.Add(totallength); }
            bool[] combine16 = Flags.Cast<bool>().Concat(FragmentOffset.Cast<bool>()).ToArray();
            bits = new BitArray(combine16);
            byte[] toBytes = BitArrayToByteArray(bits); // Flags, FragmentOffset;
            foreach(byte b in toBytes){ header.Add(b);}
            header.Add(TimeToLive); //TimeToLive
            header.Add(Protocol); //Protocol
            foreach(byte ipaddress in SourceAddress){ header.Add(ipaddress);}
            foreach(byte ipaddress in DestinationAddress){header.Add(ipaddress);}
            return header;
        }

        public byte[] convertIPAddrToBytes(string address)
        {
            IPAddress ip = IPAddress.Parse(address);
            byte[] ipByteArray = ip.GetAddressBytes();
            return ipByteArray;
        }
        private BitArray SetVersion(int version)
        {
            BitArray bits = new BitArray(4);
            switch (version)
            {
                case 4:
                    bits.Set(1, true);
                    break;
                case 6:
                    bits.Set(1, true);
                    bits.Set(2, true);
                    break;
                default:
                    break;
            }
            
            return bits;
        }

        private BitArray SetTotalLength(BitArray bodyData)
        {
            byte[] body = BitArrayToByteArray(bodyData);
            int length = (160 * 2) + body.Length;
            return new BitArray(BitConverter.GetBytes((ushort)length));
        }

        private byte[] SetCheckSum()
        {
            if (headerBytes == null)
            {
                setIPHeaderBytes();
            }
            byte[] byteArray = headerBytes.ToArray();
            ;
            ushort crc = CRC16.ComputeCheckSum(byteArray);
            return BitConverter.GetBytes(crc);
        }

        private byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] bytes = new byte[Math.Max(1, bits.Length / 8)];
            bits.CopyTo(bytes, 0);
            return bytes;
        }
    }
}