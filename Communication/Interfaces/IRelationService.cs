using Data.Enums.Player;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IRelationService : IComponent
    {
        PlayerRelation GetRelation(Player asker, Player asked);
        void ResendRelation(Player player);
    }
}
