using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskObjectAction : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public List<KeyValuePair<int, int>> ObjectId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
