using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpNpcMove : ASendPacket //len 44
    {
        protected Creature Creature;
        protected short Speed;
        protected float X2;
        protected float Y2;
        protected float Z2;

        public SpNpcMove(Creature creature, short speed, float x2, float y2, float z2)
        {
            Creature = creature;
            Speed = speed;
            X2 = x2;
            Y2 = y2;
            Z2 = z2;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteF(writer, Creature.Position.X);
            WriteF(writer, Creature.Position.Y);
            WriteF(writer, Creature.Position.Z);
            WriteH(writer, Creature.Position.Heading);
            WriteH(writer, Speed);
            WriteF(writer, X2);
            WriteF(writer, Y2);
            WriteF(writer, Z2);
            WriteD(writer, 0);
        }
    }
}