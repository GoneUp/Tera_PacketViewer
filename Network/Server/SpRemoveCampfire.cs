using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpRemoveCampfire : ASendPacket
    {
        protected Campfire Campfire;
        protected byte Type;

        public SpRemoveCampfire(Campfire campfire, byte type = 0)
        {
            Campfire = campfire;
            Type = type;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Campfire);
            WriteC(writer, Type);
        }
    }
}