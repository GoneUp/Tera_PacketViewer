using System.Collections.Generic;
using System.IO;
using Data.Structures.Npc;
using Data.Structures.Quest;

namespace Network.Server
{
    public class SpQuest : ASendPacket
    {
        protected QuestData QuestData;
        protected List<Npc> NpcList;
        protected int VisiblitySwitch;
        protected bool CountersComplete;

        public SpQuest(QuestData data, List<Npc> npcList = null, int visiblitySwitch = 1, bool countersComplete = true)
        {
            QuestData = data;
            NpcList = npcList ?? new List<Npc>();
            VisiblitySwitch = visiblitySwitch;
            CountersComplete = countersComplete;
        }

        public override void Write(BinaryWriter writer)
        {
            //0FE8 0100 0E00 0C00 00000000 0E00 0000 0000 0000 0100 3900 2A050000 E6310300 01000000 01000000 00000000 00000000 00 00 01 00000000 3900000000000000
            //0FE8 0100 0E00 0C00 00000000 0E00 0000 0100 3900 0100 5500 1EA20000 23730300 01000000 01000000 00000000 0000000000010100000000390000005663FC453DB65BC7E7FBC5419F010000ED030000372300005500000000000000
            //0FE8 0100 0E00 0C00 00000000 0E00 0000 0300 3900 0300 8D00 1EA20000 23730300 02000000 01000000 00000000 0100000000010100000000390055001C8BD345D7625BC78CB919429F0100001A0400003723000055007100F54FD9459A485BC7029A07429F0100001B040000372300007100000062F3E84578975DC7B604B0419F0100001C040000372300008D0095000000000095009D00000000009D00000000000000
            WriteH(writer, 1);
            WriteH(writer, 14); //First data shift

            WriteH(writer, 12); //???
            WriteD(writer, 0); //???

            WriteH(writer, 14); //Now data shift
            WriteH(writer, 0); //Next data shift

            WriteH(writer, (short) NpcList.Count);
            int npcShift = (int) writer.BaseStream.Position;
            WriteH(writer, 0);

            WriteH(writer, (short) QuestData.Counters.Count);
            int countersShift = (int) writer.BaseStream.Position;
            WriteH(writer, 0);

            WriteD(writer, QuestData.QuestId);
            WriteD(writer, QuestData.QuestId); //QuestUId???
            WriteD(writer, QuestData.Step + 1);
            WriteD(writer, 1);
            WriteD(writer, 0);
            WriteD(writer, VisiblitySwitch);

            WriteC(writer, 0);
            WriteC(writer, (byte) (CountersComplete ? 1 : 0));
            WriteC(writer, 1);

            WriteD(writer, 0);

            foreach (Npc npc in NpcList)
            {
                writer.Seek(npcShift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) writer.BaseStream.Position);
                npcShift = (int) writer.BaseStream.Position;
                WriteH(writer, 0);

                WriteF(writer, npc.Position.X);
                WriteF(writer, npc.Position.Y);
                WriteF(writer, npc.Position.Z);
                WriteD(writer, npc.SpawnTemplate.Type);
                WriteD(writer, npc.SpawnTemplate.NpcId);
                WriteD(writer, 13); //???
            }

            foreach (int counter in QuestData.Counters)
            {
                writer.Seek(countersShift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) writer.BaseStream.Position);
                countersShift = (int) writer.BaseStream.Position;
                WriteH(writer, 0);

                WriteD(writer, counter);
            }
        }
    }
}