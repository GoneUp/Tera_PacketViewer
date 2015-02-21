using System.Collections.Generic;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class ProjectileData
    {
        [ProtoBuf.ProtoMember(1)]
        public int LifeTime { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int AreaBoxSizeX { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int AreaBoxSizeY { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int AreaBoxSizeZ { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public List<Targeting> TargetingList { get; set; }
    }
}
