namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class AbnormalityEffect
    {
        [ProtoBuf.ProtoMember(1)]
        public int AppearEffectId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int AttackEffectId { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int DamageEffectId { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int DisappearEffectId { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int EffectId { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public string EffectPart { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public int Method { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public int TickInterval { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public int Type { get; set; }

        [ProtoBuf.ProtoMember(10)]
        public float Value { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public int OverlayEffectId { get; set; }

        public AbnormalityEffect()
        {
            EffectPart = "";
        }
    }
}
