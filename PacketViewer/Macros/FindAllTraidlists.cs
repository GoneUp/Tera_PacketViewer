using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PacketViewer.Macros
{
    internal class FindAllTraidlists
    {
        protected MainWindow MainWindow;

        public FindAllTraidlists(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            MenuItem menuItem = new MenuItem {Header = "Find all tradelists"};
            menuItem.Click += Run;

            MainWindow.MacrosMenuItem.Items.Add(menuItem);
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            Dictionary<int, Dictionary<int, List<int>>> npcTraidList = new Dictionary<int, Dictionary<int, List<int>>>();

            short spTradeListOpcode = Packet.GetPacketOpcode(MainWindow, "SpTradeList");
            short rpShowDialog = Packet.GetPacketOpcode(MainWindow, "RpShowDialog", false);
            short spNpcInfo = Packet.GetPacketOpcode(MainWindow, "SpNpcInfo");

            long lastDialogUid = 0;

            var npcs = new Dictionary<long, int>();


            string res = "";
            if (File.Exists("data/npc_traidlists.dat"))
            {
                using (var stream = File.OpenRead("data/npc_traidlists.dat"))
                {
                    using (var rd = new BinaryReader(stream))
                    {

                        int listCount = rd.ReadInt32();

                        for (int i = 0; i < listCount; i++)
                        {
                            int npcId = rd.ReadInt32();

                            int tabCount = rd.ReadInt32();

                            var temp = new Dictionary<int, List<int>>();

                            for (int j = 0; j < tabCount; j++)
                            {
                                int tabId = rd.ReadInt32();
                                int itemCounter = rd.ReadInt32();

                                var temp1 = new List<int>();

                                for (int k = 0; k < itemCounter; k++)
                                    temp1.Add(rd.ReadInt32());

                                temp.Add(tabId, temp1);
                            }

                            npcTraidList.Add(npcId, temp);
                        }
                    }
                }
            }

            foreach (Packet packet in MainWindow.pp.Packets)
            {
                if (packet.OpCode == spNpcInfo)
                {
                    if (!npcs.ContainsKey(BitConverter.ToInt64(packet.Data, 10)))
                        npcs.Add(BitConverter.ToInt64(packet.Data, 10), BitConverter.ToInt32(packet.Data, 44));
                    continue;
                }
                if (packet.OpCode == rpShowDialog)
                {
                    lastDialogUid = BitConverter.ToInt64(packet.Data, 4);
                    continue;
                }

                if (packet.OpCode != spTradeListOpcode)
                    continue;

                if (lastDialogUid != 0 && npcs.ContainsKey(lastDialogUid))
                {
                    if (npcTraidList.ContainsKey(npcs[lastDialogUid]))
                        continue;

                    int npcId = npcs[lastDialogUid];

                    short tabCounter = BitConverter.ToInt16(packet.Data, 4);

                    int position = 32;

                    var tab = new Dictionary<int, List<int>>();

                    for (int i = 0; i < tabCounter; i++)
                    {
                        int itemCounter = BitConverter.ToInt16(packet.Data, position + 4);
                        int tabId = BitConverter.ToInt32(packet.Data, position + 8);

                        tab.Add(tabId, new List<int>());

                        position += 12;

                        for (int j = 0; j < itemCounter; j++)
                        {
                            tab[tabId].Add(BitConverter.ToInt32(packet.Data, position + 4));
                            position += 8;
                        }
                    }
                    npcTraidList.Add(npcId, tab);
                }
            }

             MainWindow.SetText(res);

             if (!Directory.Exists("data"))
                 Directory.CreateDirectory("data");

             using (var stream = File.Create("data/npc_traidlists.dat"))
             {
                 using (var writer = new BinaryWriter(stream))
                 {
                     writer.Write(npcTraidList.Count);

                     res += "Finded " + npcTraidList.Count + " tradelists \n";

                     foreach (KeyValuePair<int, Dictionary<int, List<int>>> keyValuePair in npcTraidList)
                     {
                         res += "NpcId: " + keyValuePair.Key + "\n";

                         writer.Write(keyValuePair.Key); //npcId

                         writer.Write(keyValuePair.Value.Count); //tabs counter

                         foreach (KeyValuePair<int, List<int>> tab in keyValuePair.Value)
                         {
                             res += "      TabId: " + tab.Key + "\n";

                             writer.Write(tab.Key); //tab id
                             writer.Write(tab.Value.Count); //items in tab counter

                             foreach (int id in tab.Value)
                             {
                                 res += "         ItemId: " + id + "\n";
                                 writer.Write(id); //item id
                             }
                         }

                         res += "\n\n\n\n";
                     }
                 }
             }

            MainWindow.SetText(res);
        }
    }
}
