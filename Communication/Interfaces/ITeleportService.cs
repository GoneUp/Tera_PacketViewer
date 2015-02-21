using Data.Structures.Player;
using Data.Structures.World;

namespace Communication.Interfaces
{
    public interface ITeleportService : IComponent
    {
        void StartPegasusFlight(Player player, int destinationId);
        void ForceTeleport(Player player, WorldPosition position);
        void SwitchContinent(Player player, int continentId);
        WorldPosition GetBindPoint(Player player);
    }
}
