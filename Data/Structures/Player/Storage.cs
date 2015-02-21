using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums.Item;

namespace Data.Structures.Player
{
    [ProtoBuf.ProtoContract]
    public class Storage
    {
        [ProtoBuf.ProtoMember(1)] public Dictionary<int, StorageItem> Items = new Dictionary<int, StorageItem>();
        public object ItemsLock = new object();

        [ProtoBuf.ProtoMember(2)] public long Money = 100;

        [ProtoBuf.ProtoMember(3)] public short Size = 40;

        [ProtoBuf.ProtoMember(4)] public StorageType StorageType;

        public bool Locked = false;

        public bool IsFull()
        {
            int count = 0;
            if (StorageType == StorageType.Inventory)
                for (int i = 20; i < Size + 20; i++)
                {
                    if (Items.ContainsKey(i))
                        count++;
                }
            else
                count = Items.Count;

            return count >= Size;
        }

        public bool IsEmpty(int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                if (Items.ContainsKey(i))
                    return false;
            }
            return true;
        }

        public StorageItem GetItem(int slot)
        {
            lock (ItemsLock)
            {
                if (Items.ContainsKey(slot))
                    return Items[slot];
            }

            return null;
        }

        public int GetFreeSlot(int offset = 0)
        {
            lock (ItemsLock)
            {
                for (int i = offset; i < Size; i++)
                    if (StorageType == StorageType.Inventory)
                    {
                        if (!Items.ContainsKey(i + 20))
                            return i + 20;
                    }
                    else
                    {
                        if (!Items.ContainsKey(i))
                            return i;
                    }
            }
            return -1;
        }

        public void Sort(int from, int to)
        {
            lock (ItemsLock)
            {
                List<StorageItem> list = new List<StorageItem>();
                for (int i = from; i < to; i++)
                    if (Items.ContainsKey(i))
                    {
                        list.Add(Items[i]);
                        Items.Remove(i);
                    }
                list.Sort((a, b) => a.ItemTemplate.ItemCategory - b.ItemTemplate.ItemCategory);
                for (int i = 0; i < list.Count; i++)
                    Items.Add(i + from, list[i]);
            }
        }

        public int LastId()
        {
            return Items.Keys.Concat(new[] {-1}).Max();
        }

        public int LastIdRanged(int from, int to)
        {
            for (int i = to; i >= from; i--)
                if (Items.ContainsKey(i))
                    return i;

            return 0;
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
            foreach (StorageItem item in Items.Values)
                item.Release();

            Items = null;
            ItemsLock = null;
        }

        public void ReleaseUniqueIds()
        {
            foreach (StorageItem item in Items.Values)
                item.ReleaseUniqueId();
        }

        public Dictionary<int, StorageItem> GetItemsById(int itemId)
        {
            var itms = new Dictionary<int, StorageItem>();
            lock (ItemsLock)
                foreach (KeyValuePair<int, StorageItem> itm in Items)
                {
                    if (itm.Value.ItemId == itemId)
                        itms.Add(itm.Key, itm.Value);
                }
            return itms;
        }
    }
}