using System.IO;
using Data.Structures.Gather;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpGatherStart : ASendPacket
    {
        protected Player Player;
        protected Gather Gather;

        public SpGatherStart(Player player, Gather gather)
        {
            Player = player;
            Gather = gather;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteUid(writer, Gather);
        }
    }
}