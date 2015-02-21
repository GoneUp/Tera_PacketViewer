using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PacketViewer.Macros
{
    internal class FindAllGatherables
    {
        protected MainWindow MainWindow;

        public FindAllGatherables(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            MenuItem menuItem = new MenuItem {Header = "Find all gather templates"};
            menuItem.Click += Run;

            MainWindow.MacrosMenuItem.Items.Add(menuItem);
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            short spGatherInfoOpCode = Packet.GetPacketOpcode(MainWindow, "SpGatherInfo");
            short spBindOpCode = Packet.GetPacketOpcode(MainWindow, "SpCharacterBind");

            Dictionary<int, Dictionary<long, byte[]>> gathers = new Dictionary<int, Dictionary<long, byte[]>>();

            FileStream stream;

            string res = "";

            /*if (File.Exists("data/spawn/7001_gather.dat"))
            {
                gathers.Add(7001, new Dictionary<long, byte[]>());
                using (stream = File.Open("data/spawn/7001_gather.dat", FileMode.Open))
                {
                    using (BinaryReader r = new BinaryReader(stream))
                    {
                        int counter = r.ReadInt32();

                        for (int i = 0; i < counter; i++)
                        {
                            long uid = r.ReadInt64();
                            byte[] datas = r.ReadBytes(20);
                            gathers[7001].Add(uid, datas);
                        }
                    }
                }

                foreach (KeyValuePair<int, Dictionary<long, byte[]>> re in gathers)
                    res += "Loaded " + re.Value.Count + " objects from file for map " + re.Key + "\n";
            }
             */

            int mapId = 0;
            foreach (Packet packet in MainWindow.pp.Packets)
            {
                if (packet.OpCode == spBindOpCode)
                {
                    mapId = BitConverter.ToInt32(packet.Data, 4);
                    if (!gathers.ContainsKey(mapId))
                        gathers.Add(mapId, new Dictionary<long, byte[]>());
                    continue;
                }

                if (packet.OpCode != spGatherInfoOpCode)
                    continue;

                if (!gathers[mapId].ContainsKey(BitConverter.ToInt64(packet.Data, 4)))
                {
                    var gInfo = new byte[20];
                    Buffer.BlockCopy(packet.Data, 12, gInfo, 0, 20);
                    gathers[mapId].Add(BitConverter.ToInt64(packet.Data, 4),
                                       gInfo);
                }
            }

            foreach (KeyValuePair<int, Dictionary<long, byte[]>> re in gathers)
                res += "On map " + re.Key + " finded " + re.Value.Count + " gatherable objects. \n";

            MainWindow.SetText(res);

            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");

            if (!Directory.Exists("data/spawn"))
                Directory.CreateDirectory("data/spawn");

            foreach (int mapid in gathers.Keys)
            {
                using (stream = File.Create("data/spawn/" + mapid + "_gather.dat"))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(gathers[mapid].Count);

                        foreach (KeyValuePair<long, byte[]> keyValuePair in gathers[mapid])
                        {
                            //writer.Write(keyValuePair.Key);
                            writer.Write(keyValuePair.Value);
                        }

                        stream.Close();
                        writer.Close();
                    }
                }
            }
        }
    }
}
