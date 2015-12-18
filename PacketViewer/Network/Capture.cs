using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Documents;
using PacketViewer.Classes;
using PacketViewer.Forms;
using SharpPcap;
using Tera;
using Tera.Game;
using Tera.Sniffing;

namespace PacketViewer.Network
{
    public class Capture
    {
        private TeraSniffer sniffer;
        private readonly MainWindow mainWindow;

        public Capture(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Start(ServerInfo server)
        {
            Stop();

            sniffer = new TeraSniffer(new List<ServerInfo> {server}); //dont want to change the external code ;)
            sniffer.MessageReceived += messageReceived;
            sniffer.NewConnection += newConnection;

            sniffer.Enabled = true;
        }

        public void Stop()
        {
            if (sniffer != null)
            {
                sniffer.Enabled = false;
                sniffer = null;
            }
        }

        private void newConnection(Server server)
        {
            mainWindow.SetText("New connection to " + server.Name);
        }

        private void messageReceived(Message message)
        {
            try
            {
                //Message does not contain our length, add it to see the full packet
                byte[] data = new byte[message.Data.Count];
                Array.Copy(message.Data.Array, 0, data, 2, message.Data.Count - 2);
                data[0] = (byte) (((short) message.Data.Count) & 255);
                data[1] = (byte)(((short)message.Data.Count) >> 8);
                if (message.Direction == MessageDirection.ClientToServer)
                {
                    Packet_old tmpPacket = new Packet_old(Direction.CS, message.OpCode, data, false);
                    mainWindow.pp.AppendPacket(tmpPacket);
                }
                else
                {
                    Packet_old tmpPacket = new Packet_old(Direction.SC, message.OpCode, data, false);
                    mainWindow.pp.AppendPacket(tmpPacket);
                }
            }
            catch (Exception ex)
            {

                mainWindow.SetText("device_OnPacketArrival failure. \n Message:" + ex);
            }
        }

        public bool isRunning()
        {
            if (sniffer == null) return false;
            return sniffer.Enabled;
        }
    }
}