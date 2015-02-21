using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpShowIcon : ASendPacket
    {
        protected Creature Creature;
        protected int Icon;

        public SpShowIcon(Creature creature, int icon)
        {
            Creature = creature;
            Icon = icon;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteD(writer, Icon);
        }
    }
}