using Data.Enums;

namespace Data.Structures.Template.Item
{
    [ProtoBuf.ProtoContract]
    public class Passivity
    {
        [ProtoBuf.ProtoMember(1)] public int PassivityId;
        [ProtoBuf.ProtoMember(2)] public int Method;
        [ProtoBuf.ProtoMember(3)] public int TickInterval;
        [ProtoBuf.ProtoMember(4)] public int Type;
        [ProtoBuf.ProtoMember(5)] public float Value;
        [ProtoBuf.ProtoMember(6)] public int Kind;
        [ProtoBuf.ProtoMember(7)] public float ConditionValue;
        [ProtoBuf.ProtoMember(8)] public NpcSize MobSize;
        [ProtoBuf.ProtoMember(10)] public bool JudgmentOnce;
        [ProtoBuf.ProtoMember(11)] public bool BalancedByTargetCount;
        [ProtoBuf.ProtoMember(12)] public float Probability;
        [ProtoBuf.ProtoMember(13)] public int AbnormalityKind;
        [ProtoBuf.ProtoMember(14)] public int Condition;
        [ProtoBuf.ProtoMember(15)] public int ConditionCategory;
        [ProtoBuf.ProtoMember(16)] public int AbnormalityCategory;
    }
}
