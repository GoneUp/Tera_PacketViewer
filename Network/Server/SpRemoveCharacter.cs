using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpRemoveCharacter : ASendPacket
    {
        protected Player Player;

        public SpRemoveCharacter(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, 1); //mb hide timer?
        }
    }
}