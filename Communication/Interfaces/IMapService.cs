using Data.Structures;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.World;

namespace Communication.Interfaces
{
    public interface IMapService : IComponent
    {
        void Init();
        void SpawnMap(MapInstance instance);
        void SpawnTeraObject(TeraObject obj, MapInstance instance);
        void DespawnTeraObject(TeraObject obj);
        void PlayerEnterWorld(Player player);
        void CreateDrop(Npc npc, Player player);
        void PickUpItem(Player player, Item item);
        void PlayerLeaveWorld(Player player);

        bool IsDungeon(int mapId);
    }
}