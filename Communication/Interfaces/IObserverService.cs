using Data.Structures.Creature;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IObserverService : IComponent
    {
        void AddObserved(Player player, Creature creature);
        void RemoveObserved(Player player, Creature creature);
        void NotifyHpChanged(Creature creature);
        void NotifyMpChanged(Creature creature);
    }
}