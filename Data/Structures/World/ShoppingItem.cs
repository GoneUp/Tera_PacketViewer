using Data.Structures.Template.Item;

namespace Data.Structures.World
{
    public class ShoppingItem
    {
        public ItemTemplate ItemTemplate;
        public int Count;
        public long Uid;

        public ShoppingItem(ItemTemplate itemTemplate, int count, long uid = 0)
        {
            ItemTemplate = itemTemplate;
            Count = count;
            Uid = uid;
        }

        public void AddCount(int count)
        {
            Count += count;
        }
    }
}