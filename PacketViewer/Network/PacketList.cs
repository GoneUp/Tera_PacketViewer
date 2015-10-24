using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketViewer.Network
{
    class PacketList : IPacketList
    {
        private List<byte[]> list;
        private int length;

        public PacketList()
        {
            list = new List<byte[]>();
        }

        public void Clear()
        {
            length = 0;
            list.Clear();
        }

        public void Enqueue(byte[] data)
        {
            length += data.Length;
            list.Add(data);
            Debug.Print("Enq S len {0}, ges {1}", data.Length, length );
        }

        public byte[] GetBytes(int count)
        {
            int read = 0;
            byte[] buffer = null;

            //Option A: Single complete packet in one buffer
            //Option B: Multiple packets in one buffer
            //Option C: Packet that is in muliple Buffers --> keep leftover
            //Option D: Got a leftover, copy that before --> ABC

            Debug.Print("Get S count {0}, length_gesamt {1}", count, length);
            while (read < count && list.Count > 0)
            {
                byte[] dequeued = list[0];
                list.RemoveAt(0);
                Debug.Print("Get S deq count {0}, read {1}", dequeued.Length, read);

                if (dequeued.Length + read == count) {
                    //A
                    buffer = dequeued;
                    read = count;
                    Debug.Print("A");
                } else if (dequeued.Length + read < count) {
                    //B
                    buffer = new byte[count];
                    Array.Copy(dequeued, 0, buffer, read, dequeued.Length);
                    read += dequeued.Length;
                    Debug.Print("B read now " + read);
                } else if (dequeued.Length + read > count) {
                    //C
                    if (buffer == null) buffer = new byte[count];
                    Array.Copy(dequeued, 0, buffer, read, count - read);

                    //copy leftover back into first postition, next run will just get is as a normal part
                    byte[] leftover = new byte[(dequeued.Length + read) - count];
                    Array.Copy(dequeued, count - read, leftover, 0, leftover.Length);
                    list.Insert(0, leftover); 
                    
                    read = count;
                    Debug.Print("C buffer size {0}, leftover size {1}, next packet len {2}", buffer.Length, leftover.Length, NextPacketLength());
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
            return BitConverter.ToUInt16(list[0], 0);
        }
    }
}
