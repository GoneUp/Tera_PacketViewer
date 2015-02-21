using System.Collections.Generic;
using Data.Enums.SkillEngine;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class Abnormality
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public bool Infinity { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public bool IsBuff { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int Kind { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int Level { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public bool NotCareDeath { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public int Priority { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public int Property { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public int Time { get; set; }

        [ProtoBuf.ProtoMember(10)]
        public AbnormalityShowType IsShow { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public bool IsHideOnRefresh { get; set; }

        [ProtoBuf.ProtoMember(12)]
        public int BySkillCategory { get; set; }

        [ProtoBuf.ProtoMember(13)]
        public List<AbnormalityEffect> Effects { get; set; }

        [ProtoBuf.ProtoMember(14)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(15)]
        public string Tooltip { get; set; }

        public Abnormality()
        {
            Effects = new List<AbnormalityEffect>();
        }
    }
}