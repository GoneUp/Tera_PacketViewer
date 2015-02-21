using System.Collections.Generic;
using Data.Structures;
using Data.Structures.Creature;
using Data.Structures.World;

namespace Network.Client
{
    public class RpUseSkill : ARecvPacket
    {
        protected List<Creature> Targets = new List<Creature>();

        protected int SkillId;

        protected WorldPosition StartPosition = new WorldPosition();
        protected WorldPosition TargetPosition = new WorldPosition();

        public override void Read()
        {
            int count = ReadH();
            ReadH();

            SkillId = ReadD() - 0x4000000;

            StartPosition.X = ReadF();
            StartPosition.Y = ReadF();
            StartPosition.Z = ReadF();
            StartPosition.Heading = (short) ReadH();

            TargetPosition.X = ReadF();
            TargetPosition.Y = ReadF();
            TargetPosition.Z = ReadF();
            TargetPosition.Heading = StartPosition.Heading;

            for (int i = 0; i < count; i++)
            {
                ReadD(); //shifts

                long uid = ReadQ();

                Creature creature = (Creature) TeraObject.GetObject(uid);

                if (creature != null)
                    Targets.Add(creature);
            }
        }

        public override void Process()
        {
            
        }
    }
}