using System.Collections.Generic;

namespace Data.Structures.Template.Item.CategorieStats
{
    [ProtoBuf.ProtoContract]
    public class ChangeColorItem : IDefaultCategorieStat
    {
        [ProtoBuf.ProtoMember(1)] public int Id;

        [ProtoBuf.ProtoMember(2)] public string SelectOption;

        [ProtoBuf.ProtoMember(3)] public int LifeItem;

        [ProtoBuf.ProtoMember(101)] public List<KeyValuePair<int, float[]>> ColorVar;
    }
}
