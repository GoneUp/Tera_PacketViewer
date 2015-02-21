using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface ITradeService : IComponent
    {
        void AddItem(Player player, int slot, int count);
        void RemoveItem(Player player, int slot, int count);
        void ChangeMoney(Player player, long money);
        void Lock(Player player);
        void Cancel(Player player);
    }
}