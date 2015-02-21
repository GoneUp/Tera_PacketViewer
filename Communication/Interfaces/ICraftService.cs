using Data.Enums;
using Data.Enums.Craft;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface ICraftService : IComponent
    {
        void ProcessCraft(Player player, int recipeId);
        void UpdateCraftRecipes(Player player);
        void AddRecipe(Player player, int recipeId);
        void UpdateCraftStats(Player player);
        void ProgressCraftStat(Player player, CraftStat craftStat);
        void InitCraft(Player player, CraftStat craftStat);

    }
}
