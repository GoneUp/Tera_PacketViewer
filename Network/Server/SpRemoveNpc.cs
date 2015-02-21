using System.IO;
using Data.Structures.Npc;

namespace Network.Server
{
    public class SpRemoveNpc : ASendPacket //len 32
    {
        protected Npc Npc;
        protected int DespawnType; //1 - delete, 5 - death

        public SpRemoveNpc(Npc npc, int despawnType = 1)
        {
            Npc = npc;
            DespawnType = despawnType;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Npc);
            WriteF(writer, Npc.Position.X);
            WriteF(writer, Npc.Position.Y);
            WriteF(writer, Npc.Position.Z);
            WriteD(writer, DespawnType);
            WriteD(writer, 0);
        }
    }
}