using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPartyRemoveMember : ASendPacket
    {
        protected Player Player;

        public SpPartyRemoveMember(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //name shift
            WriteD(writer, 11);
            WriteD(writer, Player.PlayerId);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Player.PlayerData.Name);
        }
    }
}