using Data.Interfaces;
using Data.Structures.Creature;

namespace Communication.Interfaces
{
    public interface IAiService : IComponent
    {
        IAi CreateAi(Creature creature);
    }
}