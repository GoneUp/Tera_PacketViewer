using System.Collections.Generic;
using System.ComponentModel;
using Data.Enums;
using Data.Interfaces;
using Data.Structures.Quest.Enums;

namespace Data.Structures.Quest
{
    [ProtoBuf.ProtoContract]
    public class Quest
    {
        [ProtoBuf.ProtoMember(1)]
        public int QuestId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public QuestType Type { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public string StartNpc { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int NeedLevel { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public List<PlayerClass> NeedClasses { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public List<int> NeedQuests { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public List<IQuestStep> Steps { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public List<QuestReward> Rewards { get; set; }

        [ProtoBuf.ProtoMember(10)]
        public int RewardMoney { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public int RewardExp { get; set; }

        [ProtoBuf.ProtoMember(12)]
        public int RepeatCounter { get; set; }

        [ProtoBuf.ProtoMember(13)]
        public string QuestTitle { get; set; }

        [ProtoBuf.ProtoMember(14)]
        public QuestRewardType QuestRewardType { get; set; }

        [ProtoBuf.ProtoMember(80)]
        public bool IsDebug { get; set; }

        public Quest()
        {
            Name = "";
            StartNpc = "";
            NeedClasses = new List<PlayerClass>();
            NeedQuests = new List<int>();
            Steps = new List<IQuestStep>();
            Rewards = new List<QuestReward>();
            QuestTitle = "";

        }

        public override string ToString()
        {
            return QuestId + " : " + Name;
        }

        public bool IsRewardSwitchable()
        {
            return Rewards.Count > 1;
        }
    }
}