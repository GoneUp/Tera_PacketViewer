using System.IO;
using Data.Structures.Gather;
using Data.Structures.Player;

namespace Network.Server
{
    public enum GatherEndCode
    {
        Normal = 3,
        Failed = 2,
        Rupted = 1
    }

    public class SpGatherEnd : ASendPacket
    {
        protected Player Player;
        protected Gather Gather;
        protected GatherEndCode EndCode;

        public SpGatherEnd(Player player, Gather gather, GatherEndCode endCode)
        {
            Player = player;
            Gather = gather;
            EndCode = endCode;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteUid(writer, Gather);
            WriteD(writer, EndCode.GetHashCode());
        }
    }
}