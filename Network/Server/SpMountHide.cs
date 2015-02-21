using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpMountHide : ASendPacket
    {
        protected Player Player;
        protected int Mount;

        public SpMountHide(Player player, int mount)
        {
            Player = player;
            Mount = mount;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, Mount + 111110); //MountSkillId
        }
    }
}