using System.Collections.Generic;

namespace Data.Structures.Player
{
    [ProtoBuf.ProtoContract]
    public class Inventory
    {
        [ProtoBuf.ProtoMember(1)]
        public Dictionary<int, InventoryItem> Items = new Dictionary<int, InventoryItem>();
        public object ItemsLock = new object();

        [ProtoBuf.ProtoMember(2)]
        public long Money = 100;

        [ProtoBuf.ProtoMember(3)]
        public short Size = 40;

        public static List<int> ThingsSlots = new List<int> {1, 3, 4, 5};

        public InventoryItem GetItem(int slot)
        {
            lock (ItemsLock)
            {
                if (Items.ContainsKey(slot))
                    return Items[slot];
            }

            return null;
        }

        public int? GetItemId(int slot)
        {
            lock (ItemsLock)
            {
                if (Items.ContainsKey(slot))
                    return Items[slot].ItemId;
            }

            return null;
        }

        public void Release()
        {
            foreach (InventoryItem item in Items.Values)
                item.Release();

            Items = null;
            ItemsLock = null;
        }

        public void ReleaseUniqueIds()
        {
            foreach (InventoryItem item in Items.Values)
                item.ReleaseUniqueId();
        }

        public List<KeyValuePair<int, InventoryItem>> GetItemsById(int itemId)
        {
            List<KeyValuePair<int, InventoryItem>> items = new List<KeyValuePair<int, InventoryItem>>();

            lock (ItemsLock)
            {
                foreach (KeyValuePair<int, InventoryItem> keyValuePair in Items)
                {
                    if(keyValuePair.Value.ItemTemplate.Id == itemId)
                        items.Add(keyValuePair);
                }
            }
            return items;
        }
    }
}