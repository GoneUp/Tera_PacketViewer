using System.IO;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Network.Server
{
    public class SpAttackEnd : ASendPacket //len 42
    {
        protected Creature Creature;
        protected Attack Attack;

        public SpAttackEnd(Creature creature, Attack attack)
        {
            Creature = creature;
            Attack = attack;
        }

        public override void Write(BinaryWriter writer)
        {
            int model = 0;

            if (Creature is Player)
                model = ((Player) Creature).PlayerData.SexRaceClass;
            else if (Creature is Npc)
                model = ((Npc) Creature).SpawnTemplate.NpcId;

            WriteUid(writer, Creature);
            WriteF(writer, Creature.Position.X);
            WriteF(writer, Creature.Position.Y);
            WriteF(writer, Creature.Position.Z);
            WriteH(writer, Creature.Position.Heading);
            WriteD(writer, model);
            WriteD(writer, Attack.Args.SkillId + 0x4000000);
            WriteD(writer, 0);
            WriteD(writer, Attack.UID);
        }
    }
}