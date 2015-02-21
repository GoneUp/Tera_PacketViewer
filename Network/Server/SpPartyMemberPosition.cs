using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPartyMemberPosition : ASendPacket
    {
        public Player Player;

        public SpPartyMemberPosition(Player player)
        {
            Player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 11); // ^(*,..,*)^
            WriteD(writer, Player.PlayerId);
            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Y);
            WriteB(writer, "00303CC5"); //Z?
            WriteD(writer, Player.Position.MapId);
            WriteD(writer, 4);// possible ID of mark
        }
    }
}
