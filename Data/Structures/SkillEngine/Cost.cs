namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class Cost
    {
        [ProtoBuf.ProtoMember(1)]
        public int Hp { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int Mp { get; set; }
    }
}
