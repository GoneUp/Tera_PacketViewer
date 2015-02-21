using Data.Structures.Template.Item;

namespace Data.Structures.Player
{
    [ProtoBuf.ProtoContract]
    public class StorageItem : TeraObject
    {
        [ProtoBuf.ProtoMember(1)]
        public int ItemId;
        [ProtoBuf.ProtoMember(2)]
        private int _count = 1;
        [ProtoBuf.ProtoMember(3)]
        public int Color;

        public int Count
        {
            get //Hack prevent
            {
                if (ItemId == 20000000) return _count;
                if (_count > 999) _count = 999;
                if (_count < 0) _count = 0;
                return _count;
            }
            set { _count = value; }
        }

        public ItemTemplate ItemTemplate
        {
            get { return ItemTemplate.Factory(ItemId); }
        }
    }
}