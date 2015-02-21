using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpNpcHpMp : ASendPacket
    {
        protected Creature Creature;
        protected float Hp;
        protected bool IsFreandly;

        public SpNpcHpMp(Creature creature, bool isFreandly = false)
        {
            Creature = creature;
            IsFreandly = isFreandly;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteF(writer, (Creature.LifeStats.Hp/(Creature.MaxHp/100F))/100F);
            WriteC(writer, (byte) (IsFreandly ? 0 : 1));

            WriteD(writer, 0x00000000);
            WriteD(writer, 0x00000000);
            WriteD(writer, 0x401F0000);
            WriteD(writer, 0x05000000);
        }
    }
}