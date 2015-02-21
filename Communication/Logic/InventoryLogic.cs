using Data.Structures.Player;

namespace Communication.Logic
{
    public class InventoryLogic : Global
    {
        public static void ShowInventory(Player player)
        {
            InventoryService.ShowPlayerInventory(player);
        }
        public static void AddItem(Player player, int itemId, int counter = 1)
        {
            InventoryService.AddItemToPlayer(player, itemId, counter);
        }

        public static void AddItem(Player player, InventoryItem item)
        {
            InventoryService.AddItemToPlayer(player, item);
        }

        public static void RemoveItem(Player player, int slot, int counter = 1)
        {
            InventoryService.RemoveItemFromPlayer(player, slot, counter);
        }

        public static void ReplaceItem(Player player, int from, int to, bool isForDress = false)
        {
            InventoryService.ReplaceItemInInventory(player, from, to, isForDress);
        }
    }
}
