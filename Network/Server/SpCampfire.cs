using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpCampfire : ASendPacket
    {
        protected Campfire Campfire;

        public SpCampfire(Campfire campfire)
        {
            Campfire = campfire;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0);
            WriteUid(writer, Campfire);
            WriteD(writer, Campfire.Type);
            WriteF(writer, Campfire.Position.X);
            WriteF(writer, Campfire.Position.Y);
            WriteF(writer, Campfire.Position.Z);
            WriteD(writer, Campfire.Status);
        }
    }
}
