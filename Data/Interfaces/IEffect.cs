using Data.Structures.Creature;

namespace Data.Interfaces
{
    public interface IEffect
    {
        void Action();
        void SetImpact(CreatureEffectsImpact impact);
        void Release();
    }
}