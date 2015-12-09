using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace SimpleTCP
{
    public class PacketData<T>
    {
        T _data;
        TCPHeader TCPHeader;
        public byte[] byteArray;
        public PacketData(T data)
        {
            
            this._data = data;
            //TCPHeader = new TCPHeader();
            this.byteArray = ObjectToByteArray(_data);
        }

        

        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }
        //public static byte[] Serialize<T>(this T m)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        new BinaryFormatter().Serialize(ms, m);
        //        return ms.ToArray();
        //    }
        //}

        //public static T Deserialize<T>(this byte[] byteArray)
        //{
        //    using (var ms = new MemoryStream(byteArray))
        //    {
        //        return (T)new BinaryFormatter().Deserialize(ms);
        //    }
        //}
    }
}
