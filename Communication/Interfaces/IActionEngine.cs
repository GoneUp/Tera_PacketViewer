using Data.Structures.Player;
using Data.Structures.World.Requests;

namespace Communication.Interfaces
{
    public interface IActionEngine : IComponent
    {
        void Init();
        void AddRequest(Request request);
        Request GetRequest(int id);
        void RemoveRequest(Request request);
        void ProcessRequest(int uid, bool isAccepted, Player requestedp = null);
    }
}
