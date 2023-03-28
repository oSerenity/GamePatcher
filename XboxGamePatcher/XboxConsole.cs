using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace XboxGamePatcher
{
    internal class XboxConsole
    {
        public static TcpClient XboxName;
        public static StreamReader Reader;

        public static string IPAddress { get; set; }

        public static bool Connected { get; private set; }

        internal bool Connect(string IPAddress)
        {
            XboxName = new TcpClient();
            XboxName.Connect(IPAddress, 730);
            byte[] buffer = new byte[1026];
            XboxName.Client.Receive(buffer);
            XboxName.SendTimeout = 100;
            Reader = new StreamReader(XboxName.GetStream());
            return Connected = true;
        }

        public void WriteByte(uint Address, byte Value) => SetMemory(Address, new byte[1] { Value });

        public void SetMemory(uint Address, byte[] Data)
        {
            if (Connected != true)
            {
                throw new Exception("Connection Not Established - Must Connect To Console");
            }
            else
            {
                XboxName.Client.Send(Encoding.ASCII.GetBytes(string.Format("SETMEM ADDR=0x{0} DATA={1}\r\n", Address.ToString("X2"), BitConverter.ToString(Data).Replace("-", ""))));
                byte[] numArray = new byte[1026];
                XboxName.Client.Receive(numArray);
                if (Encoding.ASCII.GetString(numArray).Replace("\0", "").Substring(0, 11) == "0 bytes set")
                    throw new Exception("A problem occurred while writing bytes. 0 bytes set");
            }
        }
        public void WriteString(uint Address, string String)
        {
            byte[] bValue = new byte[0];
            foreach (byte b in String)
            {
                Push(bValue, out bValue, b);

            }

            Push(bValue, out bValue, 0);
            SetMemory(Address, bValue);
        }

        private void Push(byte[] InArray, out byte[] OutArray, byte Value)
        {
            OutArray = new byte[InArray.Length + 1];
            InArray.CopyTo(OutArray, 0);
            OutArray[InArray.Length] = Value;
        }

        public void WriteFloat(uint Address, float Value)
        {
            byte[] Buff = BitConverter.GetBytes(Value);
            Array.Reverse(Buff);
            SetMemory(Address, Buff);
        }
        public void WriteBool( uint Address, bool Value)
        {
            SetMemory(Address, new byte[1] { (byte)(Value ? 1 : 0) });
        }
        private int UIntToInt(uint Value)
        {
            byte[] array = BitConverter.GetBytes(Value);
            return BitConverter.ToInt32(array, 0);
        }

        private byte[] IntArrayToByte(int[] iArray)
        {
            byte[] Bytes = new byte[iArray.Length * 4];
            for (int i = 0, q = 0; i < iArray.Length; i++, q += 4)
                for (int w = 0; w < 4; w++)
                    Bytes[q + w] = BitConverter.GetBytes(iArray[i])[w];
            return Bytes;
        }
    }
}
