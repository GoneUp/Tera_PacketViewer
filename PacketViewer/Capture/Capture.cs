using System.Collections;
using System.Collections.Generic;
using System.Windows;
using PacketDotNet;
using PacketDotNet.Utils;
using PacketViewer.Forms;
using SharpPcap;

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
            CaptureDeviceList deviceList = CaptureDeviceList.Instance;

            foreach (ICaptureDevice device in deviceList)
            {
                tmpList.Add(device.Description);
            }

            return tmpList ;
        }

        public void StartCapture(string deviceName, string ip)
        {
            if (deviceName == "" || ip == "")
            {
                return;
            }
        
            CaptureDeviceList deviceList = CaptureDeviceList.Instance;
            

            foreach (var dev in deviceList)
            {
                if (dev.Description == deviceName)
                {
                    device = dev;
                }
            }

            if (device == null)
            {
                MessageBox.Show("Device Fail");
            }
   
            // Register our handler function to the
            // 'packet arrival' event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);
            
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
                    byte[] test = {0x01, 0x00, 0x00, 0x00};
                    if (StructuralComparisons.StructuralEqualityComparer.Equals(test, tcp.PayloadData))
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
    }
}
