using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PacketViewer.Network.Lists
{
    class PacketStream : IPacketList
    {
        private MemoryStream ms;
   //     private BinaryReader reader;
        private int pointer = 0;
        private string tag;
        private static bool dbg;
        private object dataLock;

        public PacketStream(string value)
        {
            dataLock = new object();
            tag = value;
            ms = new MemoryStream();
            //reader = new BinaryReader(ms);
            //if (tag == "S") dbg = true;
        }

        public void Clear()
        {
            lock (dataLock)
            {
                ms = new MemoryStream();
                pointer = 0;
            }

            if (dbg) Debug.Print("{0} Clear", tag);
        }

        public void Enqueue(byte[] data)
        {
            lock (dataLock)
            {
                ms.Seek(0, SeekOrigin.End);
                ms.Write(data, 0, data.Length);
            }
            if (dbg) Debug.Print("Enq {0} len {1}, ges {2}", tag, data.Length, ms.Length);
        }

        public byte[] GetBytes(int count)
        {
            byte[] buffer;
            if (count > 10000) Debug.Print("{3} Get_10k {0} count {1}, length_gesamt {2}", tag, count, ToString(), DateTime.Now.ToLongTimeString());
            if (dbg) Debug.Print("Get {0} count {1}, length_gesamt {2}, pointer {3}", tag, count, ms.Length, pointer);


            if (count > ms.Length)
            {
                throw new Exception("DATA MISSING " + string.Format("Get {0} count {1}, length_gesamt {2}", tag, count, ms.Length));
            }

            lock (dataLock)
            {
                buffer = new byte[count];
                ms.Seek(pointer, SeekOrigin.Begin);
                ms.Read(buffer, 0, count);
                pointer += count;

                if (pointer == ms.Length)
                {
                    //fully read, cleanup
                    ms = new MemoryStream();
                    pointer = 0;
                }

                if (pointer > 0xFFFF) //64kb
                {
                    
                }
            }

            return buffer;
        }

        public int GetLength()
        {
            return (int)ms.Length - pointer;
        }

        public bool PacketAvailable()
        {
            //peek length from buffer, check with buffer len
            int packetLen;
            lock (dataLock)
            {
                if (pointer + 2 > ms.Length) return false;
                packetLen = NextPacketLength();
            }
            return (GetLength() >= packetLen);
        }

        public int NextPacketLength()
        {
            int val = BitConverter.ToUInt16(ms.GetBuffer(), pointer);
            return val;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[PacketStream] ").AppendLine(tag);
            builder.AppendLine("MS Pos" + ms.Position);
            builder.AppendLine("MS Cap" + ms.Capacity);
            builder.AppendLine("GetLength " + GetLength());
            builder.AppendLine("PacketAvailable " + PacketAvailable());
            if (PacketAvailable()) builder.AppendLine("NextPacketLength " + NextPacketLength());
            return builder.ToString();
        }
    }
}
