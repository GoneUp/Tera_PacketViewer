using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;
using Crypt;
using PacketViewer.Forms;

namespace PacketViewer.Network
{
    public class PacketProcessor
    {
        public Session SecSession;
        public int State;

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
            State = -1;

            ServerPackets = new PacketList();
            ClientPackets = new PacketList();

            Packets = new List<Packet_old>();
        }

        public void AppendServerData(byte[] data)
        {
            if (State == 2)
                SecSession.Encrypt(ref data);

            ServerPackets.Enqueue(data);
        }

        public void AppendClientData(byte[] data)
        {
            if (State == 2)
                SecSession.Decrypt(ref data);

            ClientPackets.Enqueue(data);
        }

        public bool ProcessServerData()
        {
            switch (State)
            {
                case -1:
                    //Garbage. Drop it.
                    ServerPackets.Clear();
                    return false;
                case 0:
                    if (ServerPackets.GetLength() < 128)
                    {
                        //First Dword 1 Options Packet. Ignore it.
                        ServerPackets.Clear();
                        return false;
                    }

                    SecSession.ServerKey1 = ServerPackets.GetBytes(128);
                    State++;
                    return true;
                case 1:
                    if (ServerPackets.GetLength() < 128) return false;
                    SecSession.ServerKey2 = ServerPackets.GetBytes(128);
                    SecSession.Init();
                    State++;
                    return true;
            }

            if (!ServerPackets.PacketAvailable()) return false;

            int length = ServerPackets.NextPacketLength();
            byte[] data = ServerPackets.GetBytes(length);

            ushort opCode = BitConverter.ToUInt16(data, 2);
            string opcodename = PacketTranslator.GetOpcodeName(opCode);
            Packet_old tmpPacket = new Packet_old(true, opCode, opcodename, data, false);
            Task.Factory.StartNew(() => MainWindow.AppendPacket(Colors.LightBlue, tmpPacket.ToString(), tmpPacket));
            
            return true;
        }

        public bool ProcessClientData()
        {
            switch (State)
            {
                case -1:
                    //Garbage. Drop it.
                    ClientPackets.Clear();
                    return false;

                case 0:
                    if (ClientPackets.GetLength() < 128) return false;
                    SecSession.ClientKey1 = ClientPackets.GetBytes(128);
                    return true;
                case 1:
                    if (ClientPackets.GetLength() < 128) return false;
                    SecSession.ClientKey2 = ClientPackets.GetBytes(128);
                    return true;
            }

            if (!ClientPackets.PacketAvailable()) return false;

            int length = ClientPackets.NextPacketLength();
            byte[] data = ClientPackets.GetBytes(length);
            ushort opCode = BitConverter.ToUInt16(data, 2);
            string opcodename = PacketTranslator.GetOpcodeName(opCode);
            Packet_old tmpPacket = new Packet_old(false, opCode, opcodename, data, false);
            Task.Factory.StartNew(() => MainWindow.AppendPacket(Colors.WhiteSmoke, tmpPacket.ToString(), tmpPacket));

            return true;
        }
    }
}
