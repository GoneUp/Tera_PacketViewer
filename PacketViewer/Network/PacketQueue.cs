using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketDotNet;

namespace PacketViewer.Network
{
    class PacketQueue : IPacketList
    {
        private Queue<byte[]> queue;
        private byte[] leftover;
        private int length;

        public PacketQueue()
        {
            queue = new Queue<byte[]>();
        }

        public void Clear()
        {
            queue.Clear();
        }

        public void Enqueue(byte[] data)
        {
            length += data.Length;
            queue.Enqueue(data);
        }

        public byte[] GetBytes(int count)
        {
            int read = 0;
            byte[] buffer = null;

            //Option A: Single complete packet in one buffer
            //Option B: Multiple packets in one buffer --> keep the leftover that is not requested
            //Option C: Packet that is in muliple Buffers --> keep leftover
            //Option D: Got a leftover, copy that before --> ABC

            
            if (leftover != null)
            {
                //D
                buffer = new byte[count];

                if (leftover.Length <= count)  {
                    Array.Copy(leftover, buffer, leftover.Length);
                    read += leftover.Length;
                    leftover = null;
                }
                else
                {
                    Array.Copy(leftover, buffer, count);
                    byte[] newleftover = new byte[leftover.Length - count];
                    Array.Copy(leftover, count, newleftover, 0, leftover.Length - count);
                    leftover = newleftover;

                    read += count;
                }  
            }

            while (read < count && queue.Count > 0)
            {
                byte[] dequeued = queue.Dequeue();

                if (dequeued.Length + read == count)
                {
                    //A
                    buffer = dequeued;
                    read = count;
                }
                else if (dequeued.Length + read < count)
                {
                    //B
                    buffer = new byte[count];
                    Array.Copy(dequeued, 0, buffer, read, dequeued.Length);
                    read += dequeued.Length;
                }
                else if (dequeued.Length + read > count)
                {
                    //C
                    buffer = new byte[count];
                    Array.Copy(dequeued, 0, buffer, read, count - read);

                    leftover = new byte[(dequeued.Length + read) - count];
                    Array.Copy(dequeued, count - read, leftover, 0, leftover.Length); 

                    read = count;
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
            if (queue.Count == 0 && leftover == null) return false;
            int packetLen = NextPacketLength();
            return (GetLength() >= packetLen);
        }

        public int NextPacketLength()
        {
            if (leftover != null) return BitConverter.ToInt16(leftover, 0);
            return BitConverter.ToInt16(queue.Peek(), 0);
        }
    }
}
