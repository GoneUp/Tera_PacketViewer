using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpLevelUp : ASendPacket
    {
        protected Player Player;

        public SpLevelUp(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, Player.GetLevel());
        }
    }
}