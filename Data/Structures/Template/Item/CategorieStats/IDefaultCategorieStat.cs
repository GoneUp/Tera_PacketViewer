namespace Data.Structures.Template.Item.CategorieStats
{
    [ProtoBuf.ProtoContract]
    [ProtoBuf.ProtoInclude(1, typeof(ChangeColorItem))]
    [ProtoBuf.ProtoInclude(110, typeof(SkillStat))]
    [ProtoBuf.ProtoInclude(10000, typeof(EquipmentStat))]

    public interface IDefaultCategorieStat
    {

    }
}
