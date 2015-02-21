using System.Collections.Generic;
using Data.Structures.Player;
using Data.Structures.Template.Item;
using Utils;

namespace Data.Structures.World
{
    public class ShoppingCart
    {
        public int Uid = Funcs.GetRoundedUtc();

        public List<ShoppingItem> BuyItems = new List<ShoppingItem>();
        public List<ShoppingItem> SellItems = new List<ShoppingItem>();

        public class ShoppingItem
        {
            public ItemTemplate ItemTemplate;
            public int Count;
            public StorageItem InventoryItem;

            public ShoppingItem(ItemTemplate itemTemplate, int count, StorageItem inventoryItem = null)
            {
                ItemTemplate = itemTemplate;
                Count = count;
                InventoryItem = inventoryItem;
            }

            public void AddCount(int count)
            {
                Count += count;
            }
        }

        public long GetBuyItemsPrice()
        {
            long result = 0;

            try
            {
                foreach (var item in BuyItems)
                    result += item.ItemTemplate.BuyPrice*item.Count;
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
                //Nothing
            }

            return result;
        }

        public long GetSellItemsPrice()
        {
            long result = 0;

            try
            {
                foreach (var item in SellItems)
                    result += item.ItemTemplate.SellPrice*item.Count;
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
                //Nothing
            }

            return result;
        }
    }
}