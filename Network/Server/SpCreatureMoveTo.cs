using System.IO;
using Data.Structures.Creature;
using Data.Structures.World;

namespace Network.Server
{
    public class SpCreatureMoveTo : ASendPacket
    {
        protected Creature Creature;
        protected Creature Target;

        protected WorldPosition Position;

        public SpCreatureMoveTo(Creature creature, Creature target, WorldPosition position)
        {
            Creature = creature;
            Target = target;
            Position = position;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteUid(writer, Target);
            WriteF(writer, Position.X);
            WriteF(writer, Position.Y);
            WriteF(writer, Position.Z);
            WriteH(writer, Position.Heading);
        }
    }
}