namespace Data.Structures.Template.Item.CategorieStats
{
    [ProtoBuf.ProtoContract]
    public class SkillStat : IDefaultCategorieStat
    {
        [ProtoBuf.ProtoMember(1)]
        public int SkillId;

        [ProtoBuf.ProtoMember(101)]
        public bool RemoveItem;
    }
}
