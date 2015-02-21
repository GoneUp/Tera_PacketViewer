using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskGather : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int CollectionId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int CollectionItem { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public short Counter { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public string TimeLimit { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
