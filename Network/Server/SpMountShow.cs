using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpMountShow : ASendPacket
    {
        protected Player Player;
        protected int Mount;
        protected int SkillId;

        public SpMountShow(Player player, int mount, int skillId)
        {
            Player = player;
            Mount = mount;
            SkillId = skillId;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, Mount);
            WriteD(writer, SkillId); //MountSkillId
        }
    }
}