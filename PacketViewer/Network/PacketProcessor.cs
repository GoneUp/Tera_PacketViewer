using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media;
using Crypt;
using PacketViewer.Forms;
using PacketViewer.Network.Lists;

namespace PacketViewer.Network
{
    public class PacketProcessor
    {
        public Session SecSession;
        public bool Initialized;

        public IPacketList ServerPackets;
        public IPacketList ClientPackets;

        public List<Packet_old> Packets;

        protected MainWindow MainWindow;

        public PacketProcessor(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }


        public void Init()
        {
            SecSession = new Session();
            Initialized = false;

            ServerPackets = new PacketStream("S");
            ClientPackets = new PacketList("C");

            Packets = new List<Packet_old>();
        }

        public void AppendServerData(byte[] data)
        {
            if (Initialized)
                SecSession.Encrypt(ref data);

            ServerPackets.Enqueue(data);

        }

        public void AppendClientData(byte[] data)
        {

            if (Initialized)
                SecSession.Decrypt(ref data);

            ClientPackets.Enqueue(data);

        }

        public void ProcessAllServerData()
        {
            if (!Initialized) return;
            if (ServerPackets.GetLength() > (0xFFFF)) 
                Debug.Print("S BACKLOG " + ServerPackets.GetLength());
            while (ServerPackets.PacketAvailable())
            {
                ProcessServerData(); //aka one packet
            }
        }

        public void ProcessServerData()
        {
            int length = ServerPackets.NextPacketLength();
            if (length == 0) throw new Exception("Server data reader is broken....");

            byte[] data = ServerPackets.GetBytes(length);
            ushort opCode = BitConverter.ToUInt16(data, 2);
            Packet_old tmpPacket = new Packet_old(Direction.SC, opCode, data, false);
            Debug.Print(DateTime.Now.ToLongTimeString() + " " + tmpPacket.OpName);

            MainWindow.AppendPacket(tmpPacket);
        }

        public void ProcessAllClientData()
        {
            if (!Initialized) return;
            if (ClientPackets.GetLength() > (0xFFFF)) Debug.Print("C BACKLOG " + ClientPackets.GetLength());
            while (ClientPackets.PacketAvailable())
            {
                ProcessClientData(); //aka one packet
            }
        }

        public void ProcessClientData()
        {
            int length = ClientPackets.NextPacketLength();
            if (length == 0) throw new Exception("Client data reader is broken....");

            byte[] data = ClientPackets.GetBytes(length);
            ushort opCode = BitConverter.ToUInt16(data, 2);
            Packet_old tmpPacket = new Packet_old(Direction.CS, opCode, data, false);
           
            AppendPacket(tmpPacket);
        }

        //Just needed a general function that also can be accessed from TeraLogReader
        public void AppendPacket(Packet_old tmpPacket)
        { 
            //Task.Factory.StartNew(() => MainWindow.AppendPacket(Colors.WhiteSmoke, tmpPacket.ToString(), tmpPacket));
            MainWindow.AppendPacket(tmpPacket);
        }

        public void TryInit()
        {
            if (Initialized) return;

            if (ClientPackets.GetLength() >= 256 && ServerPackets.GetLength() >= (256 + 4))
            {
                Debug.Print("--------------Init");
                ServerPackets.GetBytes(4); //first dword
                SecSession.ServerKey1 = ServerPackets.GetBytes(128);
                SecSession.ServerKey2 = ServerPackets.GetBytes(128);
                SecSession.ClientKey1 = ClientPackets.GetBytes(128);
                SecSession.ClientKey2 = ClientPackets.GetBytes(128);
                SecSession.Init();

                Debug.Print("-----------Init2");
                lock (MainWindow.cap.EventLock)
                {
                    //Lock tcp sniffer, we dont want any new packets while we are processing the backlog

                    Initialized = true;
                    byte[] tmp;
                    if (ServerPackets.GetLength() > 0)
                    {
                        tmp = ServerPackets.GetBytes(ServerPackets.GetLength());
                        SecSession.Encrypt(ref tmp);
                        ServerPackets.Enqueue(tmp);
                        Debug.Print("#########NEXT S LEN " + ServerPackets.NextPacketLength());
                    }

                    if (ClientPackets.GetLength() > 0)
                    {
                        tmp = ClientPackets.GetBytes(ClientPackets.GetLength());
                        SecSession.Decrypt(ref tmp);
                        ClientPackets.Enqueue(tmp);
                        Debug.Print("#########NEXT C LEN " + ServerPackets.NextPacketLength());
                    }
                }
                Debug.Print("------------Init done");
            }
        }
    }
}
