using Communication.Logic;
using Data.Structures;
using Data.Structures.Creature;

namespace Network.Client
{
    public class RpMarkTarget : ARecvPacket
    {
        protected long TargetUid;
        protected int SkillId;

        public override void Read()
        {
            TargetUid = ReadQ();
            SkillId = ReadD() - 0x4000000;
        }

        public override void Process()
        {
            Creature target = TeraObject.GetObject(TargetUid) as Creature;

            if (target != null)
                PlayerLogic.MarkTarget(Connection, target, SkillId);
        }
    }
}