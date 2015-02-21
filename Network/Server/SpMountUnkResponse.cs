using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpMountUnkResponse : ASendPacket
    {
        protected Player Player;
        protected int Unk1;

        public SpMountUnkResponse(Player player, int unk1)
        {
            Player = player;
            Unk1 = unk1;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, Unk1);
        }
    }
}
