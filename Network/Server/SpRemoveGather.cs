using System.IO;
using Data.Structures.Gather;

namespace Network.Server
{
    public class SpRemoveGather : ASendPacket
    {
        protected Gather Gather;
        protected byte DespawnType;

        public SpRemoveGather(Gather gather, byte despawnType = (byte) 0x01)
        {
            Gather = gather;
            DespawnType = despawnType;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Gather);
            WriteC(writer, DespawnType);
        }
    }
}