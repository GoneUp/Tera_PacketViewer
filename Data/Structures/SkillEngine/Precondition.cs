namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class Precondition
    {
        [ProtoBuf.ProtoMember(1)]
        public int CoolTime { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int ModeChangeMethod { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int ModeNo { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public Cost Cost { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int ExclusiveAbnormality { get; set; }
    }
}
