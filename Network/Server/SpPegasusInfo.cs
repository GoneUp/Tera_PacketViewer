using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPegasusInfo : ASendPacket
    {
        protected Player Player;
        protected int Flag;

        public SpPegasusInfo(Player player, int flag = 1)
        {
            Flag = flag;
            Player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, Flag);
        }
    }
}
