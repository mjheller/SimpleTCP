using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleTcp
{
    //public class PacketGroup<T>
    //{
    //    public byte[] payload;
    //    public int length = 0;
    //    public int counter = 0;
    //    public int sequence;
    //    public int sourceip;
    //    public int destinationip;
    //    public ushort sourcePort;
    //    public ushort destinationPort;
    //    public Random random = new Random();
    //    public List<Packet> packets = new List<Packet>();
    //    public PacketGroup(T thing, int sourceip, int destinationip, ushort sourcePort, ushort destinationPort)
    //    {
    //        this.sourceip = sourceip;
    //        this.destinationip = destinationip;
    //        this.sourcePort = sourcePort;
    //        this.destinationPort = destinationPort;
    //        initialPackets();
    //        contentPackets(thing);
    //        lastPacket();
    //    }
    //    public void initialPackets()
    //    {
    //        firstPacket();
    //        secondPacket();
    //    }
    //    public void firstPacket()
    //    {
    //        Packet p = new Packet(null);
    //        p.iheader.totalLength = 40;
    //        p.iheader.checksum = 10;
    //        p.iheader.sourceAdress = sourceip;
    //        p.iheader.destinationAdress = destinationip;
    //        p.header.sourcePort = sourcePort;
    //        p.header.destinationPort = destinationPort;
    //        p.header.setOffset(5);
    //        p.header.SYN.Set(0, true);
    //        p.header.sequenceNumber = sequence = random.Next(0, 2000000);
    //        p.execute();
    //        packets.Add(p);


    //    }
    //    public void secondPacket()
    //    {
    //        Packet p = new Packet(null);
    //        p.iheader.totalLength = 40;
    //        p.iheader.checksum = 10;
    //        p.iheader.sourceAdress = sourceip;
    //        p.iheader.destinationAdress = destinationip;
    //        p.header.sourcePort = sourcePort;
    //        p.header.destinationPort = destinationPort;
    //        p.header.setOffset(5);
    //        p.header.ACK.Set(0, true);
    //        sequence += 1;
    //        p.header.sequenceNumber = sequence;
    //        p.header.ackNumber = sequence;
    //        p.execute();
    //        packets.Add(p);
    //    }
    //    public void lastPacket()
    //    {
    //        Packet p = new Packet(null);
    //        p.iheader.totalLength = 40;
    //        p.iheader.checksum = 10;
    //        p.iheader.sourceAdress = sourceip;
    //        p.iheader.destinationAdress = destinationip;
    //        p.header.sourcePort = sourcePort;
    //        p.header.destinationPort = destinationPort;
    //        p.header.setOffset(5);
    //        p.header.FIN.Set(0, true);
    //        p.header.sequenceNumber = sequence;
    //        p.execute();
    //        packets.Add(p);
    //    }
    //    public void contentPackets(T thing)
    //    {
    //        TcpOrWhat<T> tcpOrWhat = new TcpOrWhat<T>();
    //        payload = tcpOrWhat.byteSerial(thing);
    //        length = payload.Length;
    //        while (length > 0)
    //        {
    //            if (length > 1452)
    //            {
    //                byte[] splitPayload = new byte[1452];
    //                Array.Copy(payload, 0, splitPayload, 0, 1452);
    //                Packet p = new Packet(splitPayload);
    //                p.iheader.totalLength = 1452;
    //                p.iheader.checksum = 10;
    //                p.iheader.sourceAdress = sourceip;
    //                p.iheader.destinationAdress = destinationip;
    //                p.header.sourcePort = sourcePort;
    //                p.header.destinationPort = destinationPort;
    //                p.header.setOffset(5);
    //                sequence += 1;
    //                p.header.sequenceNumber = sequence;
    //                p.execute();
    //                packets.Add(p);
    //                byte[] trimmedPayLoad = new byte[payload.Length - 1452];
    //                Array.Copy(payload, 1451, trimmedPayLoad, 0, payload.Length - 1452);
    //                payload = trimmedPayLoad;
    //                length -= 1452;
    //            } else
    //            {
    //                Packet p = new Packet(payload);
    //                p.iheader.totalLength = (ushort)(payload.Length);
    //                p.iheader.checksum = 10;
    //                p.iheader.sourceAdress = sourceip;
    //                p.iheader.destinationAdress = destinationip;
    //                p.header.sourcePort = sourcePort;
    //                p.header.destinationPort = destinationPort;
    //                p.header.setOffset(5);
    //                sequence += 1;
    //                p.header.sequenceNumber = sequence;
    //                p.execute();
    //                packets.Add(p);
    //                length -= payload.Length;
    //            }
    //        }
    //    }
    //}
}
