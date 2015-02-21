using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpAttackShowBlock : ASendPacket
    {
        protected Creature Creature;
        protected int SKillId;

        public SpAttackShowBlock(Creature creature, int skillId)
        {
            Creature = creature;
            SKillId = skillId;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteD(writer, SKillId);
            WriteD(writer, 0);
        }
    }
}
