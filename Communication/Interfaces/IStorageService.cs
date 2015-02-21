using System.Collections.Generic;
using Data.Enums.Item;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IStorageService : IComponent
    {
        void ShowPlayerStorage(Player player, StorageType storageType, bool shadowUpdate = true, int offset = 0);
        void AddStartItemsToPlayer(Player player);
        bool AddItem(Player player, Storage storage, int itemId, int itemCounter, int slot = -1);
        bool AddItem(Player player, Storage storage, StorageItem item);
        bool RemoveItem(Player player, Storage storage, int slot, int counter);
        bool RemoveItemById(Player player, Storage storage, int itemId, int counter);
        void ReplaceItem(Player player, Storage storage, int @from, int to, bool isForDress = false, bool showStorage = true);
        List<int> GetFreeSlots(Storage storage);
        bool AddMoneys(Player player, Storage storage, long counter);
        bool RemoveMoney(Player player, Storage storage, long counter);
        bool ContainsItem(Storage storage, int itemId, long counter);
        StorageItem GetItemById(Storage storage, int id);
        StorageItem GetItemBySlot(Storage storage, int slot);

        bool PlaceItemToOtherStorage(Player player, Player second, Storage from, int fromSlot, Storage to, int toSlot, int counter);
    }
}