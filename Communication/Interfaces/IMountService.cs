using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IMountService : IComponent
    {
        void UnkQuestion(Player player, int unk);
        void ProcessMount(Player player, int skillId);
    }
}
