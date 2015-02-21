using System.Collections.Generic;
using Data.Enums;

namespace Data.Structures.Quest
{
    [ProtoBuf.ProtoContract]
    public class QuestReward
    {
        [ProtoBuf.ProtoMember(1)]
        public List<KeyValuePair<int, int>> Items { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int RewardSkill { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public byte TabId { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public PlayerClass PlayerClass { get; set; }

        [ProtoBuf.ProtoMember(50)]
        public bool IsDebug { get; set; }

        public override string ToString()
        {
            return "Вариант награды " + PlayerClass.ToString();
        }
    }
}