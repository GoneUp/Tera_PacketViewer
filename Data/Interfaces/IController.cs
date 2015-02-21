using Data.Structures.Player;

namespace Data.Interfaces
{
    public interface IController
    {
        void Start(Player player);
        void Release();
        void Action();
    }
}