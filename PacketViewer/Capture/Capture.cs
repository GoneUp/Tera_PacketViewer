using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using PacketDotNet;
using PacketDotNet.Utils;
using PacketViewer.Forms;
using SharpPcap;
using SharpPcap.WinPcap;

namespace PacketViewer.Capture
{
    public class Capture
    {

        private ICaptureDevice device;
        private string captureIp;
        private CancellationTokenSource cancelationTokenSource;
        private bool running;
        public object EventLock = new object();

        protected MainWindow MainWindow;

        public Capture(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        public bool Running
        {
            get { return running; }
        }


        public List<string> GetDevices()
        {
            List<string> tmpList = new List<string>();
            WinPcapDeviceList deviceList = WinPcapDeviceList.Instance;

            for (int i = 0; i < deviceList.Count; i++)
            {
                tmpList.Add(GetDeviceString(deviceList[i], i));
            }

            return tmpList;
        }

        private string GetDeviceString(WinPcapDevice dev, int index)
        {
            return string.Format("({0}) {1} ## {2} ", index, dev.Interface.FriendlyName , dev.Interface.Description);
        }
        public void StartCapture(string deviceName, string ip)
        {

            if (deviceName == "" || ip == "")
            {
                throw new Exception("Device Input Fail");
            }

            //Get our index back. (0) blabla
            int index = Convert.ToInt32(deviceName.Split(')')[0].Replace("(", ""));

            if (WinPcapDeviceList.Instance.Count <= index)
            {
                throw new Exception("Device Fail");
            }

            device = WinPcapDeviceList.Instance[index];
            

            // Register our handler function to the
            // 'packet arrival' event
            device.OnPacketArrival += device_OnPacketArrival;

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            //Filter
            string filter = "host " + ip;
            device.Filter = filter;
            captureIp = ip;

            // Start the capturing process
            device.StartCapture();

            cancelationTokenSource = new CancellationTokenSource();
            new Task(Process, cancelationTokenSource.Token, TaskCreationOptions.LongRunning).Start();
            running = true;
        }

        public void StopCapture()
        {
            running = false;
            EventLock = new object();
            device.StopCapture();
            device.Close();
            cancelationTokenSource.Cancel();
            captureIp = "";
        }

        public void device_OnPacketArrival(object sender, CaptureEventArgs eCap)
        {
            try
            {
                lock (EventLock)
                {
                    ByteArraySegment raw = new ByteArraySegment(eCap.Packet.Data);
                    EthernetPacket ethernetPacket = new EthernetPacket(raw);
                    IpPacket ipPacket = (IpPacket) ethernetPacket.PayloadPacket;
                    TcpPacket tcp = (TcpPacket) ipPacket.PayloadPacket;


                    if (ipPacket != null && tcp != null && tcp.PayloadData != null && tcp.PayloadData.Length > 0)
                    {
                        string destIp = ipPacket.DestinationAddress.ToString();

                        if (destIp == captureIp)
                        {
                            //Client -> Server
                            MainWindow.pp.AppendClientData(tcp.PayloadData);

                        }
                        else
                        {
                            //Do a check for a new game Connection. Each handshake starts with a dword 1 packet from the server.
                            byte[] handshakeSig = {0x01, 0x00, 0x00, 0x00};
                            if (StructuralComparisons.StructuralEqualityComparer.Equals(handshakeSig, tcp.PayloadData))
                            {
                                //New Connection detected. 
                                //We should reset State and Security Info
                                MainWindow.pp.Init();
                                MainWindow.ClearPackets();
                            }

                            //Sever -> Client
                            MainWindow.pp.AppendServerData(tcp.PayloadData);
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MainWindow.SetText("device_OnPacketArrival failure. \n Message:" + ex);
            }

        }

        private void Process()
        {
            while (!cancelationTokenSource.IsCancellationRequested)
            {
                if (!MainWindow.pp.Initialized) MainWindow.pp.TryInit();
                MainWindow.pp.ProcessAllServerData();
                MainWindow.pp.ProcessAllClientData();

                Thread.Sleep(10);
            }
        }
    }
}
