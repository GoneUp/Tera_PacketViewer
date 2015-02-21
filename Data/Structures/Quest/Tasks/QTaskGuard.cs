using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskGuard : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int NpcFullId { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
