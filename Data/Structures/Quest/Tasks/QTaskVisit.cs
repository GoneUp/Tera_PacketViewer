using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    /// <summary>
    /// Dialog with NPC
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class QTaskVisit : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public List<int> FullIds { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string JournalText{ get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
