using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;
using PacketViewer.Network;

//Base by Cerium Unity. Edit by GoneUp. 21.02.2014

namespace PacketViewer.Forms
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            PacketTranslator.Init(this);

            IEnumerable<string> sortDescendingQuery =
                          from w in PacketTranslator.PacketNames.Values
                          orderby w ascending
                          select w;

            foreach (var packetName in sortDescendingQuery)
                PacketNamesList.Items.Add(packetName);

            PacketNamesList.SelectedIndex = 0;


            pp = new PacketProcessor(this);
            cap = new Capture.Capture(this);

            var list = cap.GetDevices();

            foreach (var nic in list)
            {
                BoxNic.Items.Add(nic);
            }
       
            pp.Init();
        }

        public Capture.Capture cap;
        public bool CaptureRunning = false;

        public PacketProcessor pp;

        public void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {Filter = "*.hex|*.hex"};

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
        
        

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void ClearPackets()
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
                       PacketsList.Items.Clear();
                    }));
        }

        public void AppendPacket(Color col, string itemText)
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

                        PacketsList.Items.Add(item);

                        PacketsList.ScrollIntoView(item);
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

        public void AppendHex(string text)
        {
            Dispatcher.BeginInvoke(
                new Action(
                    delegate
                    {
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

        private void OnPacketSelect(object sender, SelectionChangedEventArgs e)
        {
            if (PacketsList.SelectedIndex == -1)
                return;
            
            SetHex(pp.Packets[PacketsList.SelectedIndex].Hex);
            SetText(pp.Packets[PacketsList.SelectedIndex].Text);

            OpCodeBox.Text = pp.Packets[PacketsList.SelectedIndex].Hex.Substring(0, 4);
        }

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

        private void BoxNic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nic_des = (string)BoxNic.SelectedValue;
            string senderIp = ((string) BoxServers.Text).Split(';')[0];

            if (CaptureRunning)
            {
                cap.StopCapture();
              
            }

            pp.Init();
            PacketsList.Items.Clear();
            cap.StartCapture(nic_des, senderIp);

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
