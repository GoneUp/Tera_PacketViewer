using System.Collections.Generic;
using Data.Enums;
using Data.Interfaces;

namespace Data.Structures.Quest
{
    [ProtoBuf.ProtoContract]
    public class QuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public QuestStepType Type;

        [ProtoBuf.ProtoMember(2)]
        public List<string> Npc = new List<string>();
        [ProtoBuf.ProtoMember(3)]
        public List<string> SlotNeeds = new List<string>();
        [ProtoBuf.ProtoMember(4)]
        public List<string> ItemsAdd = new List<string>();
        [ProtoBuf.ProtoMember(5)]
        public int Chanse = 100;
        [ProtoBuf.ProtoMember(6)]
        public int Count = 1;

        //[ProtoBuf.ProtoMember(7)]
        //public SkillName Skill = SkillName.Unknown;
    }

    [ProtoBuf.ProtoContract]
    public class NewQuest
    {
        [ProtoBuf.ProtoMember(1)]
        public int QuestId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public QuestType Type { get; set; }

        [ProtoBuf.ProtoMember(3)]
        private string _name = "";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [ProtoBuf.ProtoMember(4)]
        private string _startNpc = "";

        public string StartNpc
        {
            get { return _startNpc; }
            set { _startNpc = value; }
        }

        [ProtoBuf.ProtoMember(5)]
        private string _rewardNpc = "";

        public string RewardNpc
        {
            get { return _rewardNpc; }
            set { _rewardNpc = value; }
        }

        [ProtoBuf.ProtoMember(6)]
        public int NeedLevel { get; set; }

        [ProtoBuf.ProtoMember(7)]
        private List<PlayerClass> _needClasses = new List<PlayerClass>();

        public List<PlayerClass> NeedClasses
        {
            get { return _needClasses; }
            set { _needClasses = value; }
        }

        [ProtoBuf.ProtoMember(9)]
        private List<int> _needQuests = new List<int>();

        public List<int> NeedQuests
        {
            get { return _needQuests; }
            set { _needQuests = value; }
        }

        [ProtoBuf.ProtoMember(10)]
        private List<IQuestStep> _steps = new List<IQuestStep>();

        public List<IQuestStep> Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }

        [ProtoBuf.ProtoMember(11)]
        private List<QuestReward> _rewards = new List<QuestReward>();

        public List<QuestReward> Rewards
        {
            get { return _rewards; }
            set { _rewards = value; }
        }

        public override string ToString()
        {
            return QuestId + " : " + Name;
        }
    }
}