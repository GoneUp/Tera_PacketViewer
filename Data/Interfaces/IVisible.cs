using Data.Structures.Player;

namespace Data.Interfaces
{
    public interface IVisible
    {
        Player Player { get; set; }
        void Start();
        void Update();
        void Stop();
        void Release();
    }
}