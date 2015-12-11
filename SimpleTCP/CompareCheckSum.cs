using System;
using System.Security.Cryptography;
using System.Text;

namespace SimpleTCP
{
   
    class CompareCheckSum
    {
        
        public CompareCheckSum()
        {
        }

        public ushort computeHash(byte[] headerBytes)
        {
            byte[] headerHash = new MD5CryptoServiceProvider().ComputeHash(headerBytes);
            ushort checkSum =  BitConverter.ToUInt16(headerHash,0);
            return checkSum;
        }
        public bool compareHash(ushort checkSum, byte[] byteArray)
        {

            byte[] byteArrayHash;
            byteArrayHash = new MD5CryptoServiceProvider().ComputeHash(byteArray);
            ushort byteArrayShort = BitConverter.ToUInt16(byteArrayHash, 0);
            if (byteArrayShort == checkSum)
            {
                return true;
            } else
            {
                return false;
            }
        }
            //need to calculate hash on sender side, save value as 16 bit byteArray, then on receiver side take that 16 byte array, compute new byte array and compare
        //    tmpNewHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        //    bool bEqual = false;
        //    if (tmpNewHash.Length == tmpHash.Length)
        //    {
        //        int i = 0;
        //        while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpHash[i]))
        //        {
        //            i += 1;
        //        }
        //        if (i == tmpNewHash.Length)
        //        {
        //            bEqual = true;
                    
        //        }
        //    }

        //    if (bEqual)
        //        return true;
        //    else
        //        return false;
        //    Console.ReadLine();
        //}
    

        //static string ByteArrayToString(byte[] arrInput)
        //{
        //    int i;
        //    StringBuilder sOutput = new StringBuilder(arrInput.Length);
        //    for (i = 0; i < arrInput.Length - 1; i++)
        //    {
        //        sOutput.Append(arrInput[i].ToString("X2"));
        //    }
        //    return sOutput.ToString();
        //}
    }
}