using System.Collections.Generic;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IInventoryService : IComponent
    {
        void ShowPlayerInventory(Player player);
        void AddStartItemsToPlayer(Player player);
        void AddItemToPlayer(Player player, int itemId, int itemCounter);
        void AddItemToPlayer(Player player, InventoryItem item);
        void RemoveItemFromPlayer(Player player, int slot, int counter);
        void RemoveItemFromPlayerById(Player player, int itemId, int counter);
        void ReplaceItemInInventory(Player player, int from, int to, bool isForDress);
        void UpdatePlayerInventory(Player player);
        List<int> GetFreeSlots(Player player);
        void AddMoneys(Player player, long counter);
        void RemoveMoney(Player player, long counter);
        bool ContainsItem(Player player, int itemId, long counter);
        InventoryItem GetInventoryItemById(Player player, int id);
        void ColldownItems(Player player, int itemId);
    }
}