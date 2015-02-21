using System.IO;
using Data.Structures.Creature;
using Data.Structures.Npc;

namespace Network.Server
{
    public class SpNpcStatus : ASendPacket
    {
        protected Npc Npc;
        protected int Unk1;
        protected int Unk2;
        protected Creature Target;

        public SpNpcStatus(Npc npc, int unk1, int unk2, Creature target = null)
        {
            Npc = npc;
            Unk1 = unk1;
            Unk2 = unk2;
            Target = target;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Npc);
            WriteC(writer, 0);
            WriteD(writer, Unk1);
            WriteUid(writer, Target);
            WriteD(writer, Unk2);
        }
    }
}