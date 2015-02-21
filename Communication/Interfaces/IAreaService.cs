using Data.Structures.Player;
using Data.Structures.World;
using Data.Structures.World.Continent;

namespace Communication.Interfaces
{
    public interface IAreaService : IComponent
    {
        void Init();
        Area GetPlayerArea(Player player);
        Area GetAreaByCoords(WorldPosition coords);
        Section GetCurrentSection(Player player);
        Section GetSectionByCoords(WorldPosition coords);
    }
}
