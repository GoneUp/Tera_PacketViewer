using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskOverTheState : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public List<int> NpcFullId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
