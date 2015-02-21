using System.IO;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Network.Server
{
    public class SpAttackDestination : ASendPacket
    {
        protected Creature Creature;
        protected Attack Attack;
        protected Creature Target;

        public SpAttackDestination(Creature creature, Attack attack, Creature target = null)
        {
            Creature = creature;
            Attack = attack;
            Target = target;
        }

        public override void Write(BinaryWriter writer)
        {
            int model = 0;

            if (Creature is Player)
                model = ((Player) Creature).PlayerData.SexRaceClass;
            else if (Creature is Npc)
                model = ((Npc) Creature).SpawnTemplate.NpcId;

            if (Target == null)
            {
                WriteD(writer, 0); //shifts
                WriteB(writer, "01002000"); //shifts
                WriteUid(writer, Creature);
                WriteD(writer, model);
                WriteD(writer, Attack.Args.SkillId + 0x4000000);
                WriteD(writer, Attack.UID);
                WriteB(writer, "20000000"); //shifts
            }
            else
            {
                WriteB(writer, "01002000"); //shifts
                WriteB(writer, "01003000"); //shifts
                WriteUid(writer, Creature);
                WriteD(writer, model);
                WriteD(writer, Attack.Args.SkillId + 0x4000000);
                WriteD(writer, Attack.UID);
                WriteB(writer, "20000000"); //shifts
                WriteB(writer, "00000000"); //shifts
                WriteUid(writer, Target);
                WriteB(writer, "30000000"); //shifts
            }

            WriteF(writer, Attack.Args.TargetPosition.X);
            WriteF(writer, Attack.Args.TargetPosition.Y);
            WriteF(writer, Attack.Args.TargetPosition.Z);
        }
    }
}