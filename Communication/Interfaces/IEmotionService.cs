using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IEmotionService : IComponent
    {
        void StartEmotion(Player player, int emoteId);
    }
}
