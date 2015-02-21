using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpUpdateHp : ASendPacket
    {
        protected Creature Creature;
        protected int Diff;
        protected Creature Attacker;

        public SpUpdateHp(Creature creature, int diff, Creature attacker)
        {
            Creature = creature;
            Diff = diff;
            Attacker = attacker;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Creature.LifeStats.Hp);
            WriteD(writer, Creature.MaxHp);
            WriteD(writer, Diff);

            if (Attacker != null)
            {
                WriteD(writer, 1);
                WriteUid(writer, Attacker);
                WriteUid(writer, Creature);
            }
            else
            {
                WriteD(writer, 0);
                WriteUid(writer, Creature);
                WriteQ(writer, 0);
            }
        }
    }
}