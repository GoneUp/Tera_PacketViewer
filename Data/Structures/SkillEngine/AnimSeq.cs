namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class AnimSeq
    {
        [ProtoBuf.ProtoMember(1)]
        public Animation Animation { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public Animation MovingAnimation { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public Animation WaitAnimation { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int Duration { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int BlendInTime { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public float Rate { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public bool Looping { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public float LoopingRate { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public float RootMotionXYRate { get; set; }

        [ProtoBuf.ProtoMember(10)]
        public float RootMotionZRate { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public int MotionId { get; set; }
    }
}
