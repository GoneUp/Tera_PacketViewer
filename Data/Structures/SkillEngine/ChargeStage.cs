namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class ChargeStage
    {
        [ProtoBuf.ProtoMember(1)]
        public float Duration { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public float CostHpRate { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public float CostMpRate { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int ShotSkillId { get; set; }
    }
}
