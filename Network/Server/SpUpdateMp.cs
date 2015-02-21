using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpUpdateMp : ASendPacket
    {
        protected Creature Creature;
        protected int Diff;
        protected Creature Attacker;

        public SpUpdateMp(Creature creature, int diff, Creature attacker)
        {
            Creature = creature;
            Diff = diff;
            Attacker = attacker;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Creature.LifeStats.Mp);
            WriteD(writer, Creature.MaxMp);
            WriteD(writer, Diff); //added Mp

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