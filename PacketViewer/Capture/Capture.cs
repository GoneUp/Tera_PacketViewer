using System;
using System.Collections;
using System.Collections.Generic;
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

        protected MainWindow MainWindow;

        public Capture(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
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
        }

        public void StopCapture()
        {
            device.StopCapture();
            device.Close();
            captureIp = "";
        }

        public void device_OnPacketArrival(object sender, CaptureEventArgs eCap)
        {
            try
            {
                ByteArraySegment raw = new ByteArraySegment(eCap.Packet.Data);
                EthernetPacket ethernetPacket = new EthernetPacket(raw);
                IpPacket ipPacket = (IpPacket)ethernetPacket.PayloadPacket;
                TcpPacket tcp = (TcpPacket)ipPacket.PayloadPacket;


                if (ipPacket != null && tcp != null)
                {
                    string destIp = ipPacket.DestinationAddress.ToString();


                    if (destIp == captureIp)
                    {
                        //Client -> Server
                        MainWindow.pp.AppendClientData(tcp.PayloadData);

                        // ReSharper disable CSharpWarnings::CS0642
                        while (MainWindow.pp.ProcessClientData()) ;
                        // ReSharper restore CSharpWarnings::CS0642

                    }
                    else
                    {
                        //Do a check for a new game Connection. Each handshake starts with a dword 1 packet from the server.
                        byte[] handshakeSig = { 0x01, 0x00, 0x00, 0x00 };
                        if (StructuralComparisons.StructuralEqualityComparer.Equals(handshakeSig, tcp.PayloadData))
                        {
                            //New Connection detected. 
                            //We should reset State and Security Info
                            MainWindow.pp.Init();
                            MainWindow.pp.State = 0;
                            MainWindow.ClearPackets();
                        }


                        //Sever -> Client
                        MainWindow.pp.AppendServerData(tcp.PayloadData);
                        // ReSharper disable CSharpWarnings::CS0642
                        while (MainWindow.pp.ProcessServerData()) ;
                        // ReSharper restore CSharpWarnings::CS0642
                    }

                }
            }
            catch (Exception ex)
            {

                MainWindow.SetText("device_OnPacketArrival failure. \n Message:" + ex);
            }

        }
    }
}
