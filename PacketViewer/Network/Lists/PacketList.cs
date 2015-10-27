using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PacketViewer.Network.Lists
{
    class PacketList : IPacketList
    {
        private List<byte[]> list;
        private int length;
        private string tag;
        private static bool dbg;
        private object dataLock;

        public PacketList(string value)
        {
            dataLock = new object();
            tag = value;
            list = new List<byte[]>();
            if (tag == "S") dbg = true;
        }

        public void Clear()
        {
            lock (dataLock)
            {
                list.Clear();
                length = 0;
            }

            if (dbg) Debug.Print("{0} Clear", tag);
        }

        public void Enqueue(byte[] data)
        {
            lock (dataLock)
            {
                list.Add(data);
                length += data.Length;
            }
            if (dbg) Debug.Print("Enq {0} len {1}, ges {2}", tag, data.Length, length);
        }

        public byte[] GetBytes(int count)
        {
            int read = 0;
            byte[] buffer = null;

            //Option A: Single complete packet in one buffer
            //Option B: Multiple packets in one buffer
            //Option C: Packet that is in muliple Buffers --> keep leftover
            //Option D: Got a leftover, copy that before --> ABC

            if (count > 10000) Debug.Print("Get_10k {0} count {1}, length_gesamt {2}", tag, count, ToString());
            if (dbg) Debug.Print("Get {0} count {1}, length_gesamt {2}", tag, count, length);

            lock (dataLock)
            {
                while (read < count && list.Count > 0)
                {
                    byte[] dequeued;

                    dequeued = list[0];
                    list.RemoveAt(0);


                    if (dequeued == null) continue;
                    if (dbg) Debug.Print("Get {0} deq count {1}, read {2}", tag, dequeued.Length, read);

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
                        if (dbg) Debug.Print(tag + "_A");
                    }
                    else if (dequeued.Length + read < count)
                    {
                        //B
                        if (buffer == null) buffer = new byte[count];
                        Array.Copy(dequeued, 0, buffer, read, dequeued.Length);
                        read += dequeued.Length;
                        if (dbg) Debug.Print(tag + "_B read now " + read);
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
                        if (dbg) Debug.Print(tag + "_C buffer size {0}, leftover size {1}, next packet len {2}", buffer.Length, leftover.Length, NextPacketLength());
                    }

                }

                if (read < count)
                {
                    throw new Exception("DATA MISSING " + string.Format("Get {0} count {1}, length_gesamt {2} read {3}", tag, count, length, read));
                }

                length -= count;
            }
            return buffer;
        }

        public int GetLength()
        {
            return length;
        }

        public bool PacketAvailable()
        {
            //peek length from buffer, check with buffer len
            int packetLen;
            lock (dataLock)
            {
                if (list.Count == 0 || length < 2) return false;
                packetLen = NextPacketLength();
            }
            return (GetLength() >= packetLen);
        }

        public int NextPacketLength()
        {
            var tmp = new MemoryStream();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null) continue;
                if (tmp.Length >= 2)
                {
                    /*
                    if (BitConverter.ToUInt16(tmp.GetBuffer(), 0) == 0)
                    {
                        i = 0; //bugged packet, drop it and hope that the next is readable again
                        tmp = new MemoryStream();
                        list.RemoveAt(0);
                        continue;
                    }
                     */
                    break;
                }
                tmp.Write(list[i], 0, list[i].Count());
            }
            return BitConverter.ToUInt16(tmp.GetBuffer(), 0);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[PacketList] ").AppendLine(tag);
            builder.AppendLine("List.Count " + list.Count);
            builder.AppendLine("GetLength " + GetLength());
            builder.AppendLine("PacketAvailable " + PacketAvailable());
            if (PacketAvailable()) builder.AppendLine("NextPacketLength " + NextPacketLength());
            return builder.ToString();
        }
    }
}
