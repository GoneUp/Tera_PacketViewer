using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterState : ASendPacket //len 17
    {
        protected Player Player;

        public SpCharacterState(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, Player.PlayerMode.GetHashCode());
            WriteC(writer, 0);
        }
    }
}