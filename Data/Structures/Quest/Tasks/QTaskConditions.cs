using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskConditions : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public List<KeyValuePair<int, int>> Items { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int SkillId { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
