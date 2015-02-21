using Data.Structures.Player;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class UserSkill
    {
        [ProtoBuf.ProtoMember(1)]
        public int SkillId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string Tooltip { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int Level { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int Cost { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public RaceGenderClass RaceGenderClass { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public bool IsActive { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public int PrevSkillId { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public bool PrevSkillOverride { get; set; }
        
        public int TemplateId
        {
            get { return RaceGenderClass.Hash; }
        }


        public UserSkill()
        {
            Cost = (int) (Level*17.5);
        }
    }
}
