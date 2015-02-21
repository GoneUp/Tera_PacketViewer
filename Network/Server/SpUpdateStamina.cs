using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpUpdateStamina : ASendPacket
    {
        protected Player Player;

        public SpUpdateStamina(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Player.LifeStats.Stamina); //NowStamina
            WriteD(writer, 120); //MaxStamina
            WriteH(writer, 3); //???
        }
    }
}
