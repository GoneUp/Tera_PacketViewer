using Data.Enums.Craft;
using Data.Enums.Gather;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface ICraftLearnService
    {
        void ProcessCraftStat(Player player, CraftStat craftStat);
        void ProcessGatherStat(Player player, TypeName typeName);
    }
}
