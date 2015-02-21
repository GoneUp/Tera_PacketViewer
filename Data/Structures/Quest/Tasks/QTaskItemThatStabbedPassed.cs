using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    /// <summary>
    /// Delive item(s) to NPC
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class QTaskItemThatStabbedPassed : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int CpecifyTargetNpcFullId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int CpecifyIcon { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public short Count { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public int ItemId { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
