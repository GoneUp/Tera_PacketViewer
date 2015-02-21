using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterPosition : ASendPacket
    {
        protected Player Player;

        public SpCharacterPosition(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Y);
            WriteF(writer, Player.Position.Z);
            WriteH(writer, Player.Position.Heading);
            WriteC(writer, (byte) (Player.LifeStats.IsDead() ? 0 : 1));
        }
    }
}