using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskGroupHunting : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public List<int> MobFullIds { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string GroupName { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
