using System.IO;
using Data.Structures.Gather;

namespace Network.Server
{
    public class SpGatherInfo : ASendPacket
    {
        protected Gather Gather;

        public SpGatherInfo(Gather gather)
        {
            Gather = gather;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Gather);
            WriteD(writer, Gather.Id);
            WriteD(writer, Gather.CurrentGatherCounter); //gather counter
            WriteF(writer, Gather.Position.X);
            WriteF(writer, Gather.Position.Y);
            WriteF(writer, Gather.Position.Z);
        }
    }
}