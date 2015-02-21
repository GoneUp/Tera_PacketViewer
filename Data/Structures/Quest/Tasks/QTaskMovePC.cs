using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
// ReSharper disable InconsistentNaming
    public class QTaskMovePC : IQuestStep
// ReSharper restore InconsistentNaming
    {
        [ProtoBuf.ProtoMember(1)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int[] TargetArea { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public string AreaName { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
