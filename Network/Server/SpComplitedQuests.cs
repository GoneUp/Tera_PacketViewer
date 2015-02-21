using System.Collections.Generic;
using System.IO;

namespace Network.Server
{
    public class SpComplitedQuests : ASendPacket
    {
        protected List<int> QuestsIds;

        public SpComplitedQuests(List<int> questsIds)
        {
            QuestsIds = questsIds;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) QuestsIds.Count);
            int shift = (int) writer.BaseStream.Position;
            WriteH(writer, 0);

            for (int i = 0; i < QuestsIds.Count; i++)
            {
                writer.Seek(shift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) writer.BaseStream.Length);
                shift = (int) writer.BaseStream.Position;
                WriteH(writer, 0);

                WriteD(writer, QuestsIds[i]);
            }
        }
    }
}