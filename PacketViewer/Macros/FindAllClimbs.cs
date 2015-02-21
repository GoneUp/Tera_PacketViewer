using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Utils;

namespace PacketViewer.Macros
{
    class FindAllClimbs
    {
        protected MainWindow MainWindow;

        public FindAllClimbs(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            MenuItem menuItem = new MenuItem {Header = "Find all climbs"};
            menuItem.Click += Run;

            MainWindow.MacrosMenuItem.Items.Add(menuItem);
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            short spClimb = Packet.GetPacketOpcode(MainWindow, "SpClimb");
            short spBindOpCode = Packet.GetPacketOpcode(MainWindow, "SpCharacterBind");

            int mapId = 0;

            List<string> climbs = new List<string>();

            if (File.Exists("data/climbs.dat"))
            {
                using (FileStream fs = new FileStream("data/climbs.dat", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        int num = reader.ReadInt32();

                        for (int i = 0; i < num; i++)
                            climbs.Add(reader.ReadBytes(4 + 4*3 + 2 + 4*3).ToHex());
                    }
                }
            }

            int finded = 0;
            int added = 0;

            foreach (Packet packet in MainWindow.pp.Packets)
            {
                if (packet.OpCode == spBindOpCode)
                {
                    mapId = BitConverter.ToInt32(packet.Data, 4);
                    continue;
                }

                if (packet.OpCode != spClimb)
                    continue;
                
                byte[] data = new byte[4 + 4 * 3 + 2 + 4 * 3];
                Array.Copy(BitConverter.GetBytes(mapId), data, 4);
                Array.Copy(packet.Data, 12, data, 4, 4 * 3 + 2 + 4 * 3);

                finded++;

                string stringData = data.ToHex();

                if (!climbs.Contains(stringData))
                {
                    climbs.Add(stringData);
                    added++;
                }
            }

            using (FileStream fs = new FileStream("data/climbs.dat", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(climbs.Count);

                    for (int i = 0; i < climbs.Count; i++)
                        writer.Write(climbs[i].ToBytes());
                }
            }

            MainWindow.SetText("Added new " + added + " / " + finded + " climbs!");
        }
    }
}
