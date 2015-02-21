using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpDirectionChange : ASendPacket
    {
        protected Creature Creature;
        protected short NewHeading;
        protected short Time;

        public SpDirectionChange(Creature creature, short newheading, short time = (short) 0)
        {
            Creature = creature;
            NewHeading = newheading;
            Time = time;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteH(writer, NewHeading);
            WriteH(writer, Time);
            WriteH(writer, 0); //unk
        }
    }
}