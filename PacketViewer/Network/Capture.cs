using System;
using System.Collections.Generic;
using System.Threading;
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
                if (message.Direction == MessageDirection.ClientToServer)
                {

                    Packet_old tmpPacket = new Packet_old(Direction.CS, message.OpCode, message.Payload.Array, false);
                    mainWindow.pp.AppendPacket(tmpPacket);
                }
                else
                {
                    Packet_old tmpPacket = new Packet_old(Direction.SC, message.OpCode, message.Payload.Array, false);
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