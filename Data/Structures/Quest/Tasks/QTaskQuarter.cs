using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskQuarter : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int NpcFullId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
