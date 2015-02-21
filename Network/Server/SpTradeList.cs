using System;
using System.Collections.Generic;
using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpTradeList : ASendPacket
    {
        protected Tradelist Tradelist;

        public SpTradeList(Tradelist tradelist)
        {
            Tradelist = tradelist;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Tradelist.ItemsByTabs.Count);
            WriteB(writer, "2000B008B8030080000E"); //2000 mb shift?
            WriteD(writer, (int) DateTime.Now.Ticks);
            WriteH(writer, 0x3EC0); // ???
            WriteH(writer, 0);

            WriteB(writer, "7B14AE47E17A843F");

            foreach (KeyValuePair<int, List<int>> tab in Tradelist.ItemsByTabs)
            {
                WriteH(writer, (short) writer.BaseStream.Length);
                WriteH(writer, 0); //next tab shift

                WriteH(writer, (short) tab.Value.Count);
                WriteH(writer, (short) (writer.BaseStream.Length + 6)); //first item shift
                WriteD(writer, tab.Key); // name Id

                writer.Seek((int) writer.BaseStream.Length - 10, SeekOrigin.Begin);
                WriteH(writer, (short) (writer.BaseStream.Length + tab.Value.Count*8));
                writer.Seek(0, SeekOrigin.End);

                for (int i = 0; i < tab.Value.Count; i++)
                {
                    short nowItemShift = (short) writer.BaseStream.Length;
                    WriteH(writer, nowItemShift); //now item shift
                    WriteH(writer, (short) (i == tab.Value.Count - 1 ? 0 : nowItemShift + 8)); //next item shift
                    WriteD(writer, tab.Value[i]);
                }
            }
        }
    }
}