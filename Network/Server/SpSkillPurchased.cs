using System.IO;
using Data.Structures.SkillEngine;

namespace Network.Server
{
    public class SpSkillPurchased : ASendPacket
    {
        protected UserSkill Skill;

        public SpSkillPurchased(UserSkill skill)
        {
            Skill = skill;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, 1); //IsActive?
            WriteC(writer, 0); //???

            WriteD(writer, Skill.PrevSkillId);
            WriteD(writer, Skill.SkillId);
        }
    }
}
