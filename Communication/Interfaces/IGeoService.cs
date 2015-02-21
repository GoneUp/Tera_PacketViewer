using Data.Structures.World;

namespace Communication.Interfaces
{
    public interface IGeoService : IComponent
    {
        void Init();
        void FixZ(WorldPosition position);
        void FixOffset(int mapId, float x, float y, float z);
    }
}