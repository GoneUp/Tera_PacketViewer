using System.Collections.Generic;
using System.IO;
using Communication.Logic;
using Data.Structures;
using Data.Structures.Creature;
using Data.Structures.Player;
using Data.Structures.World;
using Utils;

namespace Network.Client
{
    class RpUseCrosstargetSkill : ARecvPacket
    {
        protected List<UseSkillArgs> ArgsList = new List<UseSkillArgs>();

        public List<Creature> Targets = new List<Creature>();

        public override void Read()
        {
            int tarCount = ReadH();
            int tarShift = ReadH();

            int posCount = ReadH();
            int posShift = ReadH();

            int skillId = ReadD() - 0x04000000;

            float x = ReadF();
            float y = ReadF();
            float z = ReadF();
            short heading = (short) ReadH();

            if (tarCount > 0)
                Reader.BaseStream.Seek(tarShift - 4, SeekOrigin.Begin);

            for (int i = 0; i < tarCount; i++)
            {
                ReadD();

                long uniqueId = ReadQ();

                Creature creature = TeraObject.GetObject(uniqueId) as Creature;

                if (creature != null)
                    Targets.Add(creature);
            }

            if (posCount > 0)
                Reader.BaseStream.Seek(posShift - 4, SeekOrigin.Begin);

            for (int i = 0; i < posCount; i++)
            {
                ReadD();

                ArgsList.Add(
                    new UseSkillArgs
                        {
                            IsTargetAttack = true,
                            SkillId = skillId,
                            StartPosition =
                                new WorldPosition
                                    {
                                        X = x,
                                        Y = y,
                                        Z = z,
                                        Heading = heading,
                                    },
                            TargetPosition =
                                new WorldPosition
                                    {
                                        X = ReadF(),
                                        Y = ReadF(),
                                        Z = ReadF(),
                                        Heading = heading,
                                    },
                            Targets = Targets,
                        });
            }
        }

        public override void Process()
        {
            Log.Debug("Count: " + ArgsList.Count);
            PlayerLogic.UseSkill(Connection, ArgsList);
        }
    }
}
