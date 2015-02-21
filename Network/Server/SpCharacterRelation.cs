using System.IO;
using Data.Enums.Player;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpCharacterRelation : ASendPacket
    {
        protected Creature Creature;
        protected PlayerRelation Relation;

        public SpCharacterRelation(Creature creature, PlayerRelation relation)
        {
            Creature = creature;
            Relation = relation;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteD(writer, Relation.GetHashCode());
        }
    }
}