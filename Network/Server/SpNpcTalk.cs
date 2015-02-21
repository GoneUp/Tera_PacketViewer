using System.IO;
using Data.Structures.Npc;

namespace Network.Server
{
    public class SpNpcTalk : ASendPacket
    {
        protected Npc Npc;
        protected string Options; // Like '@quest:1301001'

        public SpNpcTalk(Npc npc, string options)
        {
            Npc = npc;
            Options = options;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); // shift
            WriteUid(writer, Npc);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Options);
        }

        //65D4 0E00 5152040000800B00 4000 7100 7500 6500 7300 7400 3A00 3100 3300 3000 3100 3000 3000 3200 0000
    }
}