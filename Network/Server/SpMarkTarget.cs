using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpMarkTarget : ASendPacket
    {
        protected Creature Creature;
        protected int SkillId;
        protected byte Flag;

        public SpMarkTarget(Creature creature, int skillId, byte flag = 1)
        {
            Creature = creature;
            SkillId = skillId + 0x4000000;
            Flag = flag;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteD(writer, SkillId);
            WriteC(writer, Flag);
        }
    }
}