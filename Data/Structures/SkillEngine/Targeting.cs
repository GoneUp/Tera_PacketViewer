using System.Collections.Generic;
using Data.Enums.SkillEngine;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class Targeting
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public TargetingMethod Method { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public TargetingType Type { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int Time { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int StartTime { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public int EndTime { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public int Interval { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public int Until { get; set; }

        //__value__

        [ProtoBuf.ProtoMember(10)]
        public List<TargetingArea> AreaList { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public Cost Cost { get; set; }

        [ProtoBuf.ProtoMember(12)]
        public List<ProjectileSkill> ProjectileSkillList { get; set; }
    }
}
