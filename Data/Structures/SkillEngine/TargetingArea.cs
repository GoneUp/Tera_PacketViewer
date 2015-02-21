using Data.Enums.SkillEngine;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class TargetingArea
    {
        [ProtoBuf.ProtoMember(1)]
        public TargetingAreaType Type { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public float RotateAngle { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public float MaxHeight { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int CrosshairRadius { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int MaxCount { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public float MaxRadius { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public float MinHeight { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public float MinRadius { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public float OffsetAngle { get; set; }

        [ProtoBuf.ProtoMember(10)]
        public float OffsetDistance { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public int PierceDepth { get; set; }

        [ProtoBuf.ProtoMember(12)]
        public float RangeAngle { get; set; }

        [ProtoBuf.ProtoMember(13)]
        public int CrosshairRadius2 { get; set; }

        [ProtoBuf.ProtoMember(14)]
        public AreaEffect Effect { get; set; }

        //HitEffect

        [ProtoBuf.ProtoMember(16)]
        public float ReactionBasicRate { get; set; }

        [ProtoBuf.ProtoMember(17)]
        public float ReactionMiniRate { get; set; }

        //Only in patches

        public int? DropItem = null;

        public TargetingArea()
        {
            ReactionBasicRate = 1f;
            ReactionMiniRate = 1f;
        }
    }
}