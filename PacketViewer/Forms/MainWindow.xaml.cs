using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Schema;
using Microsoft.Win32;
using PacketViewer.Classes;
using PacketViewer.Network;

//Base by Cerium Unity. Edit by GoneUp. 21.02.2014
using PacketViewer.Network.Lists;
using Tera.Game;

namespace PacketViewer.Forms
{
    public partial class MainWindow
    {

        public Capture cap;
        public PacketProcessor pp;
        private PacketFilter filter;
        private int maxPackets;

        #region main
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                //Opcode Section
                PacketTranslator.Init();
                pp = new PacketProcessor(this);
                cap = new Capture(this);
                filter = new PacketFilter();

                pp.Init();
               
                //Serverlist
                List<ServerInfo> servers = MiscFuncs.LoadServerlistFile(Directory.GetCurrentDirectory() + "\\serverlist.xml");

                if (servers != null && servers.Count > 0)
                {
                    //We got a custom serverlist.xml loaded....
                    boxServers.Items.Clear();

                    foreach (var server in servers)
                    {
                        ComboBoxItem item = new ComboBoxItem {Tag = server, Content = server.ToString()};
                        int index = boxServers.Items.Add(item);
                        if (server.Focus) boxServers.SelectedIndex = index;
                        if (server.AutoStart) btnStartStop_Click(null, null);
                    }
                }


                //Print Info
                string info = String.Format("Loaded {0} Opcodes. \n" +
                                            "Loaded {1} servers.\n" +
                                            "Github of this Project: https://github.com/GoneUp/Tera_PacketViewer\n" +
                                            "Released at Ragezone: http://forum.ragezone.com/f797/release-tera-live-packet-sniffer-1052922/\n" +
                                            "Uses code of the TeraDamageMeter by gothos-folly: https://github.com/gothos-folly/TeraDamageMeter\n" +
                                            "Have Fun ;)", PacketTranslator.PacketNames.Count, boxServers.Items.Count);
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
                        boxPackets.Items.Clear();
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

                        while (boxPackets.Items.Count >= maxPackets)
                        {
                            boxPackets.Items.RemoveAt(0);
                            pp.Packets.RemoveAt(0);
                        }

                        if (filter.ShowPacket(tmpPacket))
                        {
                            boxPackets.Items.Add(item);

                            if (boxAutoScroll.IsChecked.Value)
                            {
                                boxPackets.ScrollIntoView(item);
                            }

                            pp.Packets.Add(tmpPacket);
                        }
                    }));
        }

        public void SetText(string text)
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                        boxPacketInfo.Document.Blocks.Clear();
                        boxPacketInfo.Document.Blocks.Add(new Paragraph(new Run(text)));
                    }));
        }
        #endregion

        #region formfuncs
        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (cap.isRunning())
            {
                cap.Stop();

                btnStartStop.Content = "Start";
            }
            else
            {
                ServerInfo info = (ServerInfo)((ComboBoxItem)boxServers.SelectedItem).Tag;

                pp.Init();
                cap.Start(info);

                //SetText(String.Format("Listening for packets of {0}.", (boxServers.Text).Split(';')[1]));
                btnStartStop.Content = "Stop";
            }

        }

        private void OnPacketSelect(object sender, SelectionChangedEventArgs e)
        {
            if (boxPackets.SelectedIndex == -1)
                return;

            Packet_old p = pp.Packets[boxPackets.SelectedIndex];
            SetText(p.HexLongText);
            boxShowOpcode.Text = String.Format("0x{0:x4}", p.OpCode);
            boxIgnoreOpcode.Text = String.Format("0x{0:x4}", p.OpCode);
        }


        private void btnClearCapture_Click(object sender, RoutedEventArgs e)
        {
            //Test();
            boxPackets.Items.Clear();
            if (pp != null)
            {
                pp.Packets.Clear();
            }

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

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region filter
        private void boxSC_Checked(object sender, RoutedEventArgs e)
        {
            if (filter != null && boxSC.IsChecked != null)
                filter.showSC = (bool)boxSC.IsChecked;
        }

        private void boxCS_Checked(object sender, RoutedEventArgs e)
        {
            if (filter != null && boxCS.IsChecked != null)
                filter.showCS = (bool)boxCS.IsChecked;
        }

        private void boxCapture_Checked(object sender, RoutedEventArgs e)
        {
            if (filter != null && boxCapture.IsChecked != null)
                filter.showAny = (bool)boxCapture.IsChecked;
        }

        private void btnShowAdd_Click(object sender, RoutedEventArgs e)
        {
            ushort opcode = 0;
            String input = boxShowOpcode.Text;

            if (input.StartsWith("0x")) input = input.Substring(2);

            try
            {
                opcode = Convert.ToUInt16(input, 16);
                if (!filter.showOnlyOpcodes.Contains(opcode))
                {
                    filter.showOnlyOpcodes.Add(opcode);
                    boxShowOpcodes.Items.Add(String.Format("{0:x4}", opcode));
                }
            }
            catch (Exception ex) { }//handle convert errors
        }

        private void btnShowRemove_Click(object sender, RoutedEventArgs e)
        {
            if (boxShowOpcodes.SelectedIndex != -1)
            {
                ushort opcode = Convert.ToUInt16((String)boxShowOpcodes.SelectedItem, 16);

                filter.showOnlyOpcodes.Remove(opcode);
                boxShowOpcodes.Items.RemoveAt(boxShowOpcodes.SelectedIndex);
            }
        }

        private void btnShowRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            filter.showOnlyOpcodes.Clear();
            boxShowOpcodes.Items.Clear();
        }

        private void btnIgnoreAdd_Click(object sender, RoutedEventArgs e)
        {
            ushort opcode = 0;
            String input = boxIgnoreOpcode.Text;

            if (input.StartsWith("0x")) input = input.Substring(2);

            try
            {
                opcode = Convert.ToUInt16(input, 16);
                if (!filter.ignoreOpcodes.Contains(opcode))
                {
                    filter.ignoreOpcodes.Add(opcode);
                    boxIgnoreOpcodes.Items.Add(String.Format("{0:x4}", opcode));
                }
            }
            catch (Exception ex) { }//handle convert errors
        }

        private void btnIgnoreRemove_Click(object sender, RoutedEventArgs e)
        {
            if (boxIgnoreOpcodes.SelectedIndex != -1)
            {
                ushort opcode = Convert.ToUInt16((String)boxIgnoreOpcodes.SelectedItem, 16);

                filter.ignoreOpcodes.Remove(opcode);
                boxIgnoreOpcodes.Items.RemoveAt(boxShowOpcodes.SelectedIndex);
            }
        }

        private void btnIgnoreRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            filter.ignoreOpcodes.Clear();
            boxIgnoreOpcodes.Items.Clear();
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

        #region open log
        private void openTeraLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IPacketInput reader;
                OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Supported Formats (*.TeraLog,*.hex)|*.TeraLog;*.hex" };

                if (openFileDialog.ShowDialog() == false)
                    return;

                pp.Init();
                ClearPackets();
                boxAutoScroll.IsChecked = false; //huge performance boost
                maxPackets = int.MaxValue; //???????????? give the user a choice? maybe a really big packet log makes problems

                string ext = Path.GetExtension(openFileDialog.FileName);
                if (ext == ".TeraLog")
                {
                    reader = new TeraLogReader(openFileDialog.FileName);
                }
                else if (ext == ".hex")
                {
                    reader = new WireshackReader(openFileDialog.FileName);
                }
                else
                {
                    throw new Exception("Unknown File Format");
                }

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
