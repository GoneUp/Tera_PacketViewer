using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;
using PacketViewer.Classes;
using PacketViewer.Network;

//Base by Cerium Unity. Edit by GoneUp. 21.02.2014
using PacketViewer.Network.Lists;

namespace PacketViewer.Forms
{
    public partial class MainWindow
    {

        public Capture.Capture cap;
        public PacketProcessor pp;
        private int maxPackets;

        #region main
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                //Opcode Section
                PacketTranslator.Init();

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
        #endregion

        #region invokes
        public void ClearPackets()
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                        pp.Packets.Clear();
                        PacketsList.Items.Clear();
                    }));
        }

        public void AppendPacket(Packet_old tmpPacket)
        {
            string itemText = tmpPacket.ToString();
            Color col;
            if (tmpPacket.Dir == Direction.SC)
            {
                col = Colors.LightBlue;
            }
            else
            {
                col = Colors.WhiteSmoke;
            }

            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                        ListBoxItem item = new ListBoxItem
                        {
                            Content = itemText,
                            Background = new SolidColorBrush(col)
                        };

                        while (PacketsList.Items.Count >= maxPackets)
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

            SetHex(pp.Packets[PacketsList.SelectedIndex].HexShortText);
            SetText(pp.Packets[PacketsList.SelectedIndex].HexLongText);

            OpCodeBox.Text = pp.Packets[PacketsList.SelectedIndex].HexShortText.Substring(0, 4);
        }

        private void BoxNic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string nic_des = (string)BoxNic.SelectedValue;
                string senderIp = (BoxServers.Text).Split(';')[0];

                if (cap.Running)
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
            //Test();
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
                    maxPackets = tmpMax;
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
                if (pp.Packets[i].OpName == name)
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
                if (pp.Packets[i].OpName == name)
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
                if (pp.Packets[i].HexShortText.IndexOf(hex, 4, StringComparison.OrdinalIgnoreCase) != -1)
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
                if (pp.Packets[i].HexShortText.IndexOf(hex, 4, StringComparison.OrdinalIgnoreCase) != -1)
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
                if (pp.Packets[i].HexShortText.IndexOf(hex, 0, StringComparison.OrdinalIgnoreCase) == 0)
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
                if (pp.Packets[i].HexShortText.IndexOf(hex, 0, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    PacketsList.SelectedIndex = i;
                    PacketsList.ScrollIntoView(PacketsList.SelectedItem);
                    return;
                }
            }
        }
        #endregion

        #region perf_test

        public void Test()
        {
            /*
             * Conclusion: Both got a equal overall performance on these tests. Peronally I perfer the List. Less copys, cleander code.
             * Test for PacketViewer.Network.PacketList 
            Enqueue for 10000! took 265 ms 
            Dequeue for 10000! took 597 ms 
            Test for PacketViewer.Network.PacketQueue 
            Enqueue for 10000! took 598 ms 
            Dequeue for 10000! took 301 ms 
             */

            IPacketList[] lists = { new PacketStream(""), new PacketQueue() };
            StringBuilder builder = new StringBuilder();
            Stopwatch watch = new Stopwatch();

            for (int j = 0; j < 4; j++)
            {


                Random r = new Random();
                int n = 10000;
                int[] rnd = new int[n];
                byte[][] rndB = new byte[n][];
                for (int i = 0; i < n; i++)
                {
                    rnd[i] = r.Next(1, 1000);
                    rndB[i] = new byte[rnd[i]];
                    r.NextBytes(rndB[i]);
                }

                foreach (IPacketList list in lists)
                {
                    builder.AppendFormat("Test for {0} \n", list);
                    watch.Start();
                    list.Clear();

                    for (int i = 0; i < n; i++)
                    {
                        list.Enqueue(rndB[i]);
                    }
                    watch.Stop();
                    builder.AppendFormat("Enqueue for {0}! took {1} ms \n", n, watch.ElapsedMilliseconds);

                    watch.Restart();
                    for (int i = n - 1; i >= 0; i--)
                    {
                        list.GetBytes(rnd[i]);
                    }
                    watch.Stop();
                    builder.AppendFormat("Dequeue for {0}! took {1} ms \n", n, watch.ElapsedMilliseconds);
                }
            }
            SetText(builder.ToString());
        }
        #endregion

        #region "open log"
        private void openTeraLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "TeraLogs|*.TeraLog" };

                if (openFileDialog.ShowDialog() == false)
                    return;

                pp.Init();
                ClearPackets();
                boxAutoScroll.IsChecked = false; //huge performance boost
                maxPackets = int.MaxValue; //???????????? give the user a choice? maybe a really big packet log makes problems

                TeraLogReader reader = new TeraLogReader(openFileDialog.FileName);
                reader.SetProcessor(pp);
                Task.Factory.StartNew(reader.Process); //dont block ui thread 

                SetText(String.Format("Loading the File {0}...", Path.GetFileName(openFileDialog.FileName)));
            }
            catch (Exception ex)
            {
                SetText("Open TeraLog failure. \n Message:" + ex);
            }

        }
        #endregion



    }
}
