using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PacketViewer.Network;
using Tera.PacketLog;

namespace PacketViewer.Classes
{
    class TeraLogReader : IPacketInput
    {
        private FileStream fs;
        private BinaryReader reader;
        private PacketProcessor processor;

        public TeraLogReader(string file)
        {
            if (!File.Exists(file)) throw new Exception("File not found!");

            fs = new FileStream(file, FileMode.Open);
            reader = new BinaryReader(fs);
        }

        public void SetProcessor(PacketProcessor pp)
        {
            processor = pp;
        }

        public void Process()
        {
            fs.Seek(0, SeekOrigin.Begin);
            while (fs.Position < fs.Length)
            {
                Packet_old tmpPacket;
                BlockType type = (BlockType)reader.ReadByte();
                ushort len = reader.ReadUInt16();
                fs.Seek(-2, SeekOrigin.Current); ; //turn it back, our packet_old class expects a length in the packet
                byte[] payload = reader.ReadBytes(len);

                switch (type)
                {
                    case BlockType.MagicBytes:
                        string magic = ASCIIEncoding.ASCII.GetString(payload, 2, payload.Length - 2);
                        if (magic != "TeraConnectionLog") throw new Exception("Invalid Magic Block.");
                        Debug.Print("found magic");
                        break;
                    case BlockType.Region:
                        string region = ASCIIEncoding.ASCII.GetString(payload, 2, payload.Length - 2);
                        Debug.Print("region " + region);
                        break;
                    case BlockType.Start:
                        Debug.Print("start");
                        break;
                    case BlockType.Timestamp:
                        //var date = LogHelper.BytesToTimeSpan(payload);
                        //Debug.Print("time " + date.ToShortTimeString());
                        break;
                    case BlockType.Client:
                        tmpPacket = new Packet_old(Direction.CS, BitConverter.ToUInt16(payload, 2), payload, false);
                        processor.AppendPacket(tmpPacket);
                        break;
                    case BlockType.Server:
                        tmpPacket = new Packet_old(Direction.SC, BitConverter.ToUInt16(payload, 2), payload, false);
                        processor.AppendPacket(tmpPacket);
                        break;
                }
            }

            reader.Close();
        }
    }
}
