using Data.Enums.Gather;

namespace Data.Structures.Template
{
    [ProtoBuf.ProtoContract]
    public class GatherTemplate
    {
        [ProtoBuf.ProtoMember(1)]
        public int Name;

        [ProtoBuf.ProtoMember(2)]
        public int Grade;

        [ProtoBuf.ProtoMember(3)]
        public int Height;

        [ProtoBuf.ProtoMember(4)]
        public int ResourceSize;

        [ProtoBuf.ProtoMember(5)]
        public ResourceType ResourceType;

        [ProtoBuf.ProtoMember(6)]
        public int CollectionId;

        [ProtoBuf.ProtoMember(7)]
        public int NeededProficiency;

        [ProtoBuf.ProtoMember(8)]
        public int PickSkillType;

        [ProtoBuf.ProtoMember(9)]
        public bool QuestCollection;

        [ProtoBuf.ProtoMember(10)]
        public TypeName TypeName;

        [ProtoBuf.ProtoMember(11)]
        public bool ShowNamePlate;

        [ProtoBuf.ProtoMember(12)]
        public int DespawnStartTime;

        [ProtoBuf.ProtoMember(13)]
        public int DespawnDuration;

        [ProtoBuf.ProtoMember(50)]
        public int DespawnEffectId;
    }
}