using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    // Hunt for items to delive it to NPC
    [ProtoBuf.ProtoContract]
    public class QTaskHuntingDelivery : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int DeliverToFullId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public List<int> DroppedFrom { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int CpecifyIcon { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public short Count { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
