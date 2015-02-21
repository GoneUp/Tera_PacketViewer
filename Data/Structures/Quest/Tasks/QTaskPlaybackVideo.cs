using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskPlaybackVideo : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int MovieId { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
