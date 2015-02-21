using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskVisitTheBlackCrack : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
