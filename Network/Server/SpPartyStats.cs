using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPartyStats : ASendPacket
    {
        protected Player Player;

        public SpPartyStats(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 11);
            WriteD(writer, Player.PlayerId);
            WriteD(writer, Player.LifeStats.Hp);
            WriteD(writer, Player.LifeStats.Mp);
            WriteD(writer, Player.MaxHp);
            WriteD(writer, Player.MaxMp);
            WriteD(writer, Player.GetLevel());
            WriteB(writer, "04000178000000000000000000000000000000");
        }
    }
}