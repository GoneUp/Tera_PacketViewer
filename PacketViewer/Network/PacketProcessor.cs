using System;
using System.Collections.Generic;
using System.Windows.Media;
using Crypt;
using PacketViewer.Forms;

namespace PacketViewer.Network
{
    public class PacketProcessor
    {
        public Session SecSession;
        public int State;

        public byte[] ServerBuffer;
        public byte[] ClientBuffer;

        public List<Packet_old> Packets;
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
            Packets = new List<Packet_old>();  
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
            string opcodename = PacketTranslator.GetPacketOpcodeName(MainWindow, opCode);

            Packet_old tmpPacket = new Packet_old(true, opCode, opcodename, GetServerData(length), false);
            ;

            string itemText = string.Format("[S] {0} [{1}]"
                                            , tmpPacket.Name
                                            , tmpPacket.Data.Length
                );

            MainWindow.AppendPacket(Colors.LightBlue, itemText, tmpPacket);

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
            string opcodename = PacketTranslator.GetPacketOpcodeName(MainWindow, opCode);

             Packet_old tmpPacket = new Packet_old(false, opCode, opcodename, GetClientData(length), false);

            string itemText = string.Format("[C] {0} [{1}]"
                                            , tmpPacket.Name
                                            , tmpPacket.Data.Length
                );

            MainWindow.AppendPacket(Colors.WhiteSmoke, itemText, tmpPacket);
            
            return false;
        }
    }
}
