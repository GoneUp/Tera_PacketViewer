using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpRemoveHpBar : ASendPacket
    {
        protected Creature Creature;

        public SpRemoveHpBar(Creature creature)
        {
            Creature = creature;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
        }
    }
}
