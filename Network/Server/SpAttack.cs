using System.IO;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Network.Server
{
    public class SpAttack : ASendPacket
    {
        protected Creature Creature;
        protected Attack Attack;

        public SpAttack(Creature creature, Attack attack)
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

            if (Attack.Stage == 0)
            {
                WriteH(writer, 1); //Unk count
                WriteH(writer, 50); //Shift
            }
            else
                WriteD(writer, 0);

            WriteUid(writer, Creature);
            WriteF(writer, Attack.Args.StartPosition.X);
            WriteF(writer, Attack.Args.StartPosition.Y);
            WriteF(writer, Attack.Args.StartPosition.Z);
            WriteH(writer, Attack.Args.StartPosition.Heading);
            WriteD(writer, model);
            WriteD(writer, Attack.Args.SkillId + 0x4000000);
            WriteD(writer, Attack.Stage);
            WriteF(writer, Creature.Attack.Speed);

            if (Creature is Player)
                WriteD(writer, Attack.UID);
            else
                WriteD(writer, 0);

            if (Attack.Stage == 0)
            {
                WriteB(writer, "000032000000000000000000803F0000803F");
                WriteD(writer, Attack.UID);
            }
        }
    }
}