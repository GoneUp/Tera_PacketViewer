using Data.Structures.Player;
using Data.Structures.World.Requests;

namespace Communication.Interfaces
{
    public interface IDuelService : IComponent
    {
        void StartDuel(Player initiator, Player initiated, Request request);
        void ProcessDamage(Player player);
        void FinishDuel(Player winner);
        void PlayerLeaveWorld(Player player);
    }
}
