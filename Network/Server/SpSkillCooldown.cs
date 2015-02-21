using System.IO;

namespace Network.Server
{
    public class SpSkillCooldown : ASendPacket
    {
        protected int SkillId;
        protected int Time;

        public SpSkillCooldown(int skillid, int time)
        {
            SkillId = skillid + 0x4000000;
            Time = time;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, SkillId);
            WriteD(writer, Time);
        }
    }
}