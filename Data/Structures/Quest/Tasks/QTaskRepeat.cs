using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskRepeat : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string JournalText2 { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public List<int> NpcFullIds { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int SpecifyTheTargetNpc { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public string ItemNameFlag { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public int BabajkaFlag { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }

    }
}
