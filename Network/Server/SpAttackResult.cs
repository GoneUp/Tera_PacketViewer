using System.IO;
using Data.Structures.Creature;
using Data.Structures.World;

namespace Network.Server
{
    public class SpAttackResult : ASendPacket
    {
        protected Creature Creature;
        protected Creature Target;

        protected int SkillId;

        protected int AttackUid;
        protected int AttackType;
        protected int Damage;

        protected VisualEffect VisualEffect;

        public SpAttackResult(Creature creature, int skillId, AttackResult atk)
        {
            Creature = creature;
            Target = atk.Target;

            SkillId = skillId;

            AttackUid = atk.AttackUid;
            AttackType = atk.AttackType.GetHashCode();
            Damage = atk.Damage;

            VisualEffect = atk.VisualEffect;

            if (VisualEffect != null)
                AttackType |= 1 << 24;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) (VisualEffect != null ? VisualEffect.Times.Count : 0)); //count of timesteps
            int timesShift = (int) writer.BaseStream.Position;
            WriteH(writer, 0); //shift

            WriteUid(writer, Creature); //attacker uniqueid
            WriteUid(writer, Target); //target unique id

            WriteD(writer, Creature.GetModelId());
            WriteD(writer, SkillId + 0x4000000);
            WriteQ(writer, 0);
            WriteD(writer, AttackUid);

            WriteD(writer, 0);

            WriteD(writer, Damage); //damage ;)
            WriteD(writer, AttackType); // 1 - Normal, 65537 - Critical
            WriteC(writer, 0);

            if (VisualEffect != null)
            {
                WriteF(writer, VisualEffect.Position.X);
                WriteF(writer, VisualEffect.Position.Y);
                WriteF(writer, VisualEffect.Position.Z);
                WriteH(writer, VisualEffect.Position.Heading);

                WriteD(writer, VisualEffect.Type.GetHashCode());
                WriteD(writer, 0);
                WriteD(writer, AttackUid);

                foreach (int time in VisualEffect.Times)
                {
                    writer.Seek(timesShift, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);

                    WriteH(writer, (short) writer.BaseStream.Position);
                    timesShift = (int) writer.BaseStream.Position;
                    WriteH(writer, 0);

                    WriteD(writer, time);
                    WriteB(writer, "0000803F0000803F000080BF");
                }
            }
            else
                WriteB(writer, new byte[27]); //unk
        }
    }
}