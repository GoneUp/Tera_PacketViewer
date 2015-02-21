using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskSkillStrike : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public Dictionary<int, int> MobAndSkill { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
