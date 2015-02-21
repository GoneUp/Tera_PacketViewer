using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterBind : ASendPacket //len 21
    {
        protected Player Player;

        public SpCharacterBind(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            //TODO:
            WriteD(writer, Player.Position.MapId);
            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Y);
            WriteF(writer, Player.Position.Z);
            WriteC(writer, 0); //NOT Heading
        }
    }
}