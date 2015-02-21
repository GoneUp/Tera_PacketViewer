using System.Collections.Generic;
using Data.Enums.SkillEngine;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class Skill
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int ParentId { get; set; }

        private int _baseId;

        public int BaseId
        {
            get
            {
                if (_baseId == 0)
                    _baseId = (Id / 10000) * 10000 + 100;
                return _baseId;
            }
        }

        [ProtoBuf.ProtoMember(3)]
        public SkillType Type { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public string Name { get; set; }

        //Category

        [ProtoBuf.ProtoMember(6)]
        public int TemplateId { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public bool ChangeDirToCenter { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public int NextSkill { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public PushTarget PushTarget { get; set; }

        [ProtoBuf.ProtoMember(10)]
        public Animation Animation { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public bool AutoUse { get; set; }

        [ProtoBuf.ProtoMember(12)]
        public bool KeepMovingCharge { get; set; }
        
        [ProtoBuf.ProtoMember(13)]
        public bool KeptMovingCharge { get; set; }

        [ProtoBuf.ProtoMember(14)]
        public bool NeedWeapon { get; set; }

        [ProtoBuf.ProtoMember(15)]
        public float TimeRate { get; set; }

        [ProtoBuf.ProtoMember(16)]
        public float TotalAtk { get; set; }

        //__value__

        //BattleField

        [ProtoBuf.ProtoMember(19)]
        public bool UseSkillWhileReaction { get; set; }

        [ProtoBuf.ProtoMember(20)]
        public int TotalStk { get; set; }

        [ProtoBuf.ProtoMember(21)]
        public int TotalStkPvP { get; set; }

        //Bullet

        [ProtoBuf.ProtoMember(23)]
        public List<SkillAction> Actions { get; set; }

        //Defence

        //Drain

        [ProtoBuf.ProtoMember(26)]
        public Precondition Precondition { get; set; }

        [ProtoBuf.ProtoMember(27)]
        public ProjectileData ProjectileData { get; set; }

        [ProtoBuf.ProtoMember(28)]
        public List<Targeting> TargetingList { get; set; }

        //Property

        [ProtoBuf.ProtoMember(30)]
        public ChargingStageList ChargingStageList { get; set; }

        public int Level
        {
            get { return (Id % 1000) / 100; }
        }

        //ConnectPrevSkill

        //Dash

        //Pulling

        //ShortTel
    }
}