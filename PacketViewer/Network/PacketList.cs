using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketViewer.Network
{
    class PacketList : IPacketList
    {
        private List<byte[]> list;
        private int length;
        private string tag;

        public PacketList(string tag)
        {
            this.tag = tag;
            list = new List<byte[]>();
        }

        public void Clear()
        {
            length = 0;
            list.Clear();
            Debug.Print("{0} Clear", tag);
        }

        public void Enqueue(byte[] data)
        {
            list.Add(data);
            length += data.Length;
            Debug.Print("Enq {0} len {1}, ges {2}", tag, data.Length, length);
        }

        public byte[] GetBytes(int count)
        {
            int read = 0;
            byte[] buffer = null;

            //Option A: Single complete packet in one buffer
            //Option B: Multiple packets in one buffer
            //Option C: Packet that is in muliple Buffers --> keep leftover
            //Option D: Got a leftover, copy that before --> ABC

            Debug.Print("Get {0} count {1}, length_gesamt {2}", tag, count, length);
            while (read < count && list.Count > 0)
            {
                byte[] dequeued = list[0];
                list.RemoveAt(0);

                if (dequeued == null) continue;
                Debug.Print("Get {0} deq count {1}, read {2}", tag, dequeued.Length, read);

                if (dequeued.Length + read == count)
                {
                    //A
                    if (read == 0) //complete packet in one
                    {
                        buffer = dequeued;
                    }
                    else //alrdy smth in buffer
                    {
                        Array.Copy(dequeued, 0, buffer, read, count - read);
                    }
                    read = count;
                    Debug.Print(tag + "_A");
                }
                else if (dequeued.Length + read < count)
                {
                    //B
                    if (buffer == null) buffer = new byte[count];
                    Array.Copy(dequeued, 0, buffer, read, dequeued.Length);
                    read += dequeued.Length;
                    Debug.Print(tag + "_B read now " + read);
                }
                else if (dequeued.Length + read > count)
                {
                    //C
                    if (buffer == null) buffer = new byte[count];
                    Array.Copy(dequeued, 0, buffer, read, count - read);

                    //copy leftover back into first postition, next run will just get is as a normal part
                    byte[] leftover = new byte[(dequeued.Length + read) - count];
                    Array.Copy(dequeued, count - read, leftover, 0, leftover.Length);
                    list.Insert(0, leftover);

                    read = count;
                    Debug.Print(tag + "_C buffer size {0}, leftover size {1}, next packet len {2}", buffer.Length, leftover.Length, NextPacketLength());
                }

            }

            if (read < count)
            {
                throw new Exception("DATA MISSING");
            }

            length -= count;
            return buffer;
        }

        public int GetLength()
        {
            return length;
        }

        public bool PacketAvailable()
        {
            //peek length from buffer, check with buffer len
            if (list.Count == 0 || length < 2) return false;
            int packetLen = NextPacketLength();
            return (GetLength() >= packetLen);
        }

        public int NextPacketLength()
        {
            var tmp = new MemoryStream();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null) continue;
                if (tmp.Length >= 2) break;
                tmp.Write(list[i], 0, list[i].Count());
            }

            return BitConverter.ToUInt16(tmp.GetBuffer(), 0);
        }
    }
}
