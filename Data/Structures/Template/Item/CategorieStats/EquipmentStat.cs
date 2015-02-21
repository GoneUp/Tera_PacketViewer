namespace Data.Structures.Template.Item.CategorieStats
{
    [ProtoBuf.ProtoContract]
    public class EquipmentStat : IDefaultCategorieStat
    {
        [ProtoBuf.ProtoMember(1)] public int EquipmentId;

        [ProtoBuf.ProtoMember(2)] public int Balance;

        [ProtoBuf.ProtoMember(3)] public int CountOfSlot;

        [ProtoBuf.ProtoMember(4)] public int Def;

        [ProtoBuf.ProtoMember(5)] public int Impact;

        [ProtoBuf.ProtoMember(6)] public int MinAtk;

        [ProtoBuf.ProtoMember(7)] public int MaxAtk;

        [ProtoBuf.ProtoMember(8)] public int PassivityLinkG;

        [ProtoBuf.ProtoMember(101)] public string Part;
    }
}
