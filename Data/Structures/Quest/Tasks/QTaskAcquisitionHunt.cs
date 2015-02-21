using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskAcquisitionHunt : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public List<int> NpcFullId { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public List<KeyValuePair<int, int>> DropId { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
