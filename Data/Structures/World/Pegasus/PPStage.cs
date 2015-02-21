using System.Collections.Generic;
using Data.Enums.Pegasus;

namespace Data.Structures.World.Pegasus
{
    [ProtoBuf.ProtoContract]
    public class PPStage
    {
        [ProtoBuf.ProtoMember(1)]
        public PType Type;

        [ProtoBuf.ProtoMember(2)]
        public int ContinentId;

        [ProtoBuf.ProtoMember(10)]
        public List<FlyStep> FlySteps;
    }
}
