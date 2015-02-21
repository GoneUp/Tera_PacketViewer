using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPegasusFinishFly : ASendPacket
    {
        protected Player Player;

        public SpPegasusFinishFly(Player player)
        {
            Player = player;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
        }
    }
}
