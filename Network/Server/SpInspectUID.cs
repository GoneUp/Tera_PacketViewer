using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpInspectUid : ASendPacket
    {
        protected Player Player;

        public SpInspectUid(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0);
            WriteUid(writer, Player);
        }
    }
}
