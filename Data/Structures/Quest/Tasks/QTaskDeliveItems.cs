using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskDeliveItems : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int NpcFullId { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public List<KeyValuePair<int, int>> Items { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public short Counter { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public string JournalText2 { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
