using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Data.Structures.Template;
using ProtoBuf;

namespace PacketViewer.Macros
{
    internal class FindAllNpcs
    {
        protected MainWindow MainWindow;

        public FindAllNpcs(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            MenuItem menuItem = new MenuItem {Header = "Find all npc"};
            menuItem.Click += Run;

            MainWindow.MacrosMenuItem.Items.Add(menuItem);
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            short spNpcInfoOpCode = Packet.GetPacketOpcode(MainWindow, "SpNpcInfo");
            short spBindOpCode = Packet.GetPacketOpcode(MainWindow, "SpCharacterBind");

            Dictionary<int, Dictionary<long, byte[]>> npcs = new Dictionary<int, Dictionary<long, byte[]>>();

            int mapId = 0;

            /*if (File.Exists("data/spawn/7001_spawn.dat"))
            {
                npcs.Add(7001, new Dictionary<long, byte[]>());
                using (stream = File.Open("data/spawn/7001_spawn.dat",FileMode.Open))
                {
                    using (BinaryReader r = new BinaryReader(stream))
                    {
                        int counter = r.ReadInt32();

                        for (int i = 0; i < counter; i++)
                        {
                            long uid = r.ReadInt64();
                            int datalen = r.ReadInt32();
                            byte[] datas = r.ReadBytes(datalen);
                            npcs[7001].Add(uid, datas);
                        }
                    }
                }
            }*/

            foreach (Packet packet in MainWindow.pp.Packets)
            {
                if (packet.OpCode == spBindOpCode)
                {
                    mapId = BitConverter.ToInt32(packet.Data, 4);
                    if (!npcs.ContainsKey(mapId))
                        npcs.Add(mapId, new Dictionary<long, byte[]>());
                    continue;
                }

                if (packet.OpCode != spNpcInfoOpCode)
                    continue;

                long id = BitConverter.ToInt64(packet.Data, 10);

                if (npcs[mapId].ContainsKey(id))
                    continue;

                byte[] data = new byte[packet.Data.Length - 8];
                Buffer.BlockCopy(packet.Data, 8, data, 0, data.Length);

                npcs[mapId].Add(id, data);
            }

            int count = 0;

            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");

            if (!Directory.Exists("data/spawn"))
                Directory.CreateDirectory("data/spawn");

            foreach (int mapid in npcs.Keys)
            {
                using (FileStream stream = File.Create("data/spawn/" + mapid + "_spawn.bin"))
                {
                    foreach (KeyValuePair<long, byte[]> keyValuePair in npcs[mapid])
                    {
                        SpawnTemplate spawnTemplate = new SpawnTemplate
                                                          {
                                                              NpcId = BitConverter.ToInt32(keyValuePair.Value, 36),
                                                              Type = BitConverter.ToInt16(keyValuePair.Value, 40),
                                                              MapId = mapid,
                                                              X = BitConverter.ToSingle(keyValuePair.Value, 18),
                                                              Y = BitConverter.ToSingle(keyValuePair.Value, 22),
                                                              Z = BitConverter.ToSingle(keyValuePair.Value, 26),
                                                              Heading = BitConverter.ToInt16(keyValuePair.Value, 30)
                                                          };

                        Serializer.SerializeWithLengthPrefix(stream, spawnTemplate, PrefixStyle.Fixed32);

                        count++;
                    }
                }
            }

            MainWindow.SetText("Finded " + count + " npcs in " + npcs.Count + " maps!");
        }
    }
}
