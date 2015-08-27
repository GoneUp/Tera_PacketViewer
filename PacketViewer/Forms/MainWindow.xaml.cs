using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;
using PacketViewer.Classes;
using PacketViewer.Network;

//Base by Cerium Unity. Edit by GoneUp. 21.02.2014

namespace PacketViewer.Forms
{
    public partial class MainWindow
    {

        public Capture.Capture cap;
        public bool CaptureRunning = false;

        public PacketProcessor pp;

        public int MaxPackets = 3000;

        #region main
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                //Opcode Section
                PacketTranslator.Init(this);

                IEnumerable<string> sortDescendingQuery =
                    from w in PacketTranslator.PacketNames.Values
                    orderby w ascending
                    select w;

                foreach (var packetName in sortDescendingQuery)
                    PacketNamesList.Items.Add(packetName);

                PacketNamesList.SelectedIndex = 0;

                //Serverlist
                List<ServerInfo> servers = MiscFuncs.LoadServerlistFile(Directory.GetCurrentDirectory() + "\\serverlist.xml");

                if (servers != null && servers.Count > 0)
                {
                    //We got a custom serverlist.xml loaded....
                    BoxServers.Items.Clear();

                    foreach (var server in servers)
                    {
                        int index = BoxServers.Items.Add(server.GetDisplayString());
                        if (server.Focus) BoxServers.SelectedIndex = index;
                    }
                }

                //Capture 
                pp = new PacketProcessor(this);
                cap = new Capture.Capture(this);

                var list = cap.GetDevices();

                foreach (var nic in list)
                {
                    BoxNic.Items.Add(nic);
                }

                pp.Init();


                //Print Info
                string info = String.Format("Loaded {0} Opcodes. \n" +
                                            "Loaded {1} servers.\n" +
                                            "{2} network devices available.\n" +
                                            "Github of this Project: https://github.com/GoneUp/Tera_PacketViewer\n" +
                                            "Released at Ragezone: http://forum.ragezone.com/f797/release-tera-live-packet-sniffer-1052922/\n" +
                                            "Have Fun ;)", PacketNamesList.Items.Count, BoxServers.Items.Count,
                    BoxNic.Items.Count);
                SetText(info);
            }
            catch (Exception ex)
            {

                string info = "Startup FAIL! Is WinPcap installed? \n " + ex;
                SetText(info);
            }
        }



        public void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "*.hex|*.hex" };

            if (openFileDialog.ShowDialog() == false)
                return;

            pp.Init();
            pp.OpenFileMode = true;

            PacketsList.Items.Clear();

            using (FileStream fileStream = File.OpenRead(openFileDialog.FileName))
            {
                using (TextReader stream = new StreamReader(fileStream))
                {
                    while (true)
                    {
                        string line = stream.ReadLine();
                        if (line == null)
                            break;
                        if (line.Length == 0)
                            continue;
                        if (pp.State == -1)
                        {
                            pp.State = 0;
                            continue;
                        }

                        bool isServer = line[0] == ' ';

                        string hex = line.Substring(isServer ? 14 : 10, 49).Replace(" ", "");
                        byte[] data = hex.ToBytes();

                        if (isServer)
                        {
                            pp.AppendServerData(data);
                            // ReSharper disable CSharpWarnings::CS0642
                            while (pp.ProcessServerData()) ;
                            // ReSharper restore CSharpWarnings::CS0642
                        }
                        else
                        {
                            pp.AppendClientData(data);
                            // ReSharper disable CSharpWarnings::CS0642
                            while (pp.ProcessClientData()) ;
                            // ReSharper restore CSharpWarnings::CS0642
                        }
                    }
                }
            }

            SetText("Loaded " + pp.Packets.Count + " packets...");
        }
        #endregion

        #region invokes
        public void ClearPackets()
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                        PacketsList.Items.Clear();
                    }));
        }

        public void AppendPacket(Color col, string itemText, Packet_old tmpPacket)
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                        ListBoxItem item = new ListBoxItem
                        {
                            Content = itemText,
                            Background = new SolidColorBrush(col)
                        };

                        if (PacketsList.Items.Count == MaxPackets)
                        {
                            PacketsList.Items.RemoveAt(0);
                            pp.Packets.RemoveAt(0);
                        }

                        if (boxCapture.IsChecked.Value)
                        {
                            PacketsList.Items.Add(item);

                            if (boxAutoScroll.IsChecked.Value)
                            {
                                PacketsList.ScrollIntoView(item);
                            }

                            pp.Packets.Add(tmpPacket);
                        }
                    }));
        }

        public void SetHex(string text)
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                        HexTextBox.Document.Blocks.Clear();
                        HexTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
                    }));
        }


        public void SetText(string text)
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                        TextBox.Document.Blocks.Clear();
                        TextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
                    }));
        }
        #endregion

        #region formfuncs
        private void OnPacketSelect(object sender, SelectionChangedEventArgs e)
        {
            if (PacketsList.SelectedIndex == -1)
                return;

            SetHex(pp.Packets[PacketsList.SelectedIndex].Hex);
            SetText(pp.Packets[PacketsList.SelectedIndex].Text);

            OpCodeBox.Text = pp.Packets[PacketsList.SelectedIndex].Hex.Substring(0, 4);
        }

        private void BoxNic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string nic_des = (string)BoxNic.SelectedValue;
                string senderIp = (BoxServers.Text).Split(';')[0];

                if (CaptureRunning)
                {
                    cap.StopCapture();

                }

                pp.Init();
                PacketsList.Items.Clear();
                cap.StartCapture(nic_des, senderIp);

                SetText(String.Format("Listening for packets of {0}.", (BoxServers.Text).Split(';')[1]));
            }
            catch (Exception ex)
            {

                SetText("Start Capture failure. \n Message:" + ex);
            }


        }

        private void btnClearCapture_Click(object sender, RoutedEventArgs e)
        {
            PacketsList.Items.Clear();
            if (pp != null)
            {
                pp.Packets.Clear();
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void boxMaxPackets_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = boxMaxPackets.Text.Replace(" ", "");
            int tmpMax;
            if (input != "" && int.TryParse(input, out tmpMax))
            {
                if (tmpMax > 0)
                {
                    MaxPackets = tmpMax;
                }
            }
        }
        #endregion

        #region search
        private void FindByName(object sender, RoutedEventArgs e)
        {
            if (pp.Packets == null)
                return;

            string name = PacketNamesList.SelectedItem.ToString();

            for (int i = PacketsList.SelectedIndex + 1; i < pp.Packets.Count; i++)
            {
                if (pp.Packets[i].Name == name)
                {
                    PacketsList.SelectedIndex = i;
                    PacketsList.ScrollIntoView(PacketsList.SelectedItem);
                    return;
                }
            }

            if (MessageBox.Show("Find from start?", "Not found", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            for (int i = 0; i < PacketsList.SelectedIndex; i++)
            {
                if (pp.Packets[i].Name == name)
                {
                    PacketsList.SelectedIndex = i;
                    PacketsList.ScrollIntoView(PacketsList.SelectedItem);
                    return;
                }
            }
        }

        private void FindByHex(object sender, RoutedEventArgs e)
        {
            if (pp.Packets == null)
                return;

            string hex = HexBox.Text.Replace(" ", "");

            for (int i = PacketsList.SelectedIndex + 1; i < pp.Packets.Count; i++)
            {
                if (pp.Packets[i].Hex.IndexOf(hex, 4, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    PacketsList.SelectedIndex = i;
                    PacketsList.ScrollIntoView(PacketsList.SelectedItem);
                    return;
                }
            }

            if (MessageBox.Show("Find from start?", "Not found", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            for (int i = 0; i < PacketsList.SelectedIndex; i++)
            {
                if (pp.Packets[i].Hex.IndexOf(hex, 4, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    PacketsList.SelectedIndex = i;
                    PacketsList.ScrollIntoView(PacketsList.SelectedItem);
                    return;
                }
            }
        }

        private void FindByOpCode(object sender, RoutedEventArgs e)
        {
            if (pp.Packets == null)
                return;

            string hex = OpCodeBox.Text.Replace(" ", "");

            for (int i = PacketsList.SelectedIndex + 1; i < pp.Packets.Count; i++)
            {
                if (pp.Packets[i].Hex.IndexOf(hex, 0, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    PacketsList.SelectedIndex = i;
                    PacketsList.ScrollIntoView(PacketsList.SelectedItem);
                    return;
                }
            }

            if (MessageBox.Show("Find from start?", "Not found", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            for (int i = 0; i < PacketsList.SelectedIndex; i++)
            {
                if (pp.Packets[i].Hex.IndexOf(hex, 0, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    PacketsList.SelectedIndex = i;
                    PacketsList.ScrollIntoView(PacketsList.SelectedItem);
                    return;
                }
            }
        }
        #endregion


    }
}
