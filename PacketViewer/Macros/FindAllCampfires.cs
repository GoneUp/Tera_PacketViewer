using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Data.Structures.Template;
using Data.Structures.World;
using ProtoBuf;

namespace PacketViewer.Macros
{
    class FindAllCampfires
    {
        protected MainWindow MainWindow;

        public FindAllCampfires(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            MenuItem menuItem = new MenuItem {Header = "Find all campfires"};
            menuItem.Click += Run;

            MainWindow.MacrosMenuItem.Items.Add(menuItem);
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            short spCampfireOpCode = Packet.GetPacketOpcode(MainWindow, "SpCampfire");
            short spBindOpCode = Packet.GetPacketOpcode(MainWindow, "SpCharacterBind");

            Dictionary<int, List<CampfireSpawnTemplate>> templates = new Dictionary<int, List<CampfireSpawnTemplate>>();

            int mapId = 0;

            if (File.Exists("data/campfires.bin"))
            {
                using (FileStream fs = File.OpenRead("data/campfires.bin"))
                {
                    templates = Serializer.Deserialize<Dictionary<int, List<CampfireSpawnTemplate>>>(fs);
                }
            }

            int count = 0;

            foreach (Packet packet in MainWindow.pp.Packets)
            {
                if (packet.OpCode == spBindOpCode)
                {
                    mapId = BitConverter.ToInt32(packet.Data, 4);
                    if (!templates.ContainsKey(mapId))
                        templates.Add(mapId, new List<CampfireSpawnTemplate>());
                    continue;
                }

                if (packet.OpCode != spCampfireOpCode)
                    continue;

                CampfireSpawnTemplate template = new CampfireSpawnTemplate
                    {
                        Position = new WorldPosition
                        {
                            MapId = mapId,
                            X = BitConverter.ToSingle(packet.Data, 20),
                            Y = BitConverter.ToSingle(packet.Data, 24),
                            Z = BitConverter.ToSingle(packet.Data, 28),
                        },
                    };

                if (AlreadyExistInList(template, templates[mapId]))
                    continue;
                
                templates[mapId].Add(template);
                count++;
            }

            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");

            using (FileStream fs = File.Create("data/campfires.bin"))
            {
                Serializer.Serialize(fs, templates);
            }

            MainWindow.SetText("Finded " + count + " new campfires!");
        }

        public bool AlreadyExistInList(CampfireSpawnTemplate template, List<CampfireSpawnTemplate> list)
        {
            if (list == null)
                return false;

            foreach (var st in list)
            {
                if (st.Position.DistanceTo(template.Position) < 100)
                    return true;
            }

            return false;
        }
    }
}
