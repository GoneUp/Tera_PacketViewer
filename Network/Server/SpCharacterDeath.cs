using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterDeath : ASendPacket
    {
        protected bool IsDeath;
        protected Player Player;

        public SpCharacterDeath(Player player, bool isDeath)
        {
            IsDeath = isDeath;
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Y);
            WriteF(writer, Player.Position.Z);
            WriteH(writer, (short) (IsDeath ? 0 : 1));
        }
    }
}