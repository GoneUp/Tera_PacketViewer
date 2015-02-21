using Data.Structures.Player;
using Data.Structures.World;

namespace Communication.Interfaces
{
    public interface IItemService : IComponent
    {
        void ItemUse(Player player, int itemId, WorldPosition position);
        void GetItemInfo(Player player, long itemUid);
    }
}
