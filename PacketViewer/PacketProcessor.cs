using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Crypt;

namespace PacketViewer
{
    public class PacketProcessor
    {
        public Session SecSession;
        public int State;

        public byte[] ServerBuffer;
        public byte[] ClientBuffer;

        public List<Packet> Packets;
        public bool OpenFileMode = false;

        protected MainWindow MainWindow;

        public PacketProcessor(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }


        public void Init()
        {
            SecSession = new Session();
            State = -1;

            ServerBuffer = new byte[0];
            ClientBuffer = new byte[0];
            Packets = new List<Packet>();  
        }

        public void AppendServerData(byte[] data)
        {
            if (State == 2)
                SecSession.Encrypt(ref data);

            Array.Resize(ref ServerBuffer, ServerBuffer.Length + data.Length);
            Array.Copy(data, 0, ServerBuffer, ServerBuffer.Length - data.Length, data.Length);
        }

        public byte[] GetServerData(int length)
        {
            byte[] result = new byte[length];
            Array.Copy(ServerBuffer, result, length);

            byte[] reserve = (byte[]) ServerBuffer.Clone();
            ServerBuffer = new byte[ServerBuffer.Length - length];
            Array.Copy(reserve, length, ServerBuffer, 0, ServerBuffer.Length);

            return result;
        }

        public void AppendClientData(byte[] data)
        {
            if (State == 2)
                SecSession.Decrypt(ref data);

            Array.Resize(ref ClientBuffer, ClientBuffer.Length + data.Length);
            Array.Copy(data, 0, ClientBuffer, ClientBuffer.Length - data.Length, data.Length);
        }

        public byte[] GetClientData(int length)
        {
            byte[] result = new byte[length];
            Array.Copy(ClientBuffer, result, length);

            byte[] reserve = (byte[]) ClientBuffer.Clone();
            ClientBuffer = new byte[ClientBuffer.Length - length];
            Array.Copy(reserve, length, ClientBuffer, 0, ClientBuffer.Length);

            return result;
        }

        public bool ProcessServerData()
        {
            switch (State)
            {
                case -1:
                    //Garbage. Drop it.
                    GetServerData(ServerBuffer.Length);
                    return false;
                case 0:
                    if (ServerBuffer.Length < 128)
                    {
                        //First Dword 1 Options Packet. Ignore it.
                        if (OpenFileMode == false)
                        {
                             GetServerData(ServerBuffer.Length);
                        }
                       
                        return false;
                    }

                    SecSession.ServerKey1 = GetServerData(128);
                    State++;
                    return true;
                case 1:
                    if (ServerBuffer.Length < 128)
                        return false;
                    SecSession.ServerKey2 = GetServerData(128);
                    SecSession.Init();
                    State++;
                    return true;
            }

            if (ServerBuffer.Length < 4)
                return false;

            int length = BitConverter.ToUInt16(ServerBuffer, 0);

            if (ServerBuffer.Length < length)
                return false;

            ushort opCode = BitConverter.ToUInt16(ServerBuffer, 2);

            Packets.Add(new Packet(true, opCode, GetServerData(length)));

            string itemText = string.Format("[S] {0} [{1}]"
                                            , Packets[Packets.Count - 1].Name
                                            , Packets[Packets.Count - 1].Data.Length
                );

            MainWindow.AppendPacket(Colors.LightBlue, itemText);

           return false;
        }

        public bool ProcessClientData()
        {
            switch (State)
            {
                case -1:
                    //Garbage. Drop it.
                    GetClientData(ClientBuffer.Length);
                    return false;

                case 0:
                    if (ClientBuffer.Length < 128)
                    {
                        // garbage from a running game session. we ignore it.
                        //If we open a hex File we handle it diffrent ;)
                        if (OpenFileMode == false)
                        {
                            GetClientData(ClientBuffer.Length);
                        }
                        return false;
                    }

                    SecSession.ClientKey1 = GetClientData(128);
                    return true;
                case 1:
                    if (ClientBuffer.Length < 128)
                        return false;

                    SecSession.ClientKey2 = GetClientData(128); 
                    return true;
            }

            if (ClientBuffer.Length < 4)
                return false;

            int length = BitConverter.ToUInt16(ClientBuffer, 0);

            if (ClientBuffer.Length < length)
                return false;

            ushort opCode = BitConverter.ToUInt16(ClientBuffer, 2);

            Packets.Add(new Packet(false, opCode, GetClientData(length)));

            string itemText = string.Format("[C] {0} [{1}]"
                                            , Packets[Packets.Count - 1].Name
                                            , Packets[Packets.Count - 1].Data.Length
                );

            MainWindow.AppendPacket(Colors.WhiteSmoke, itemText);
            
            return false;
        }
    }
}
