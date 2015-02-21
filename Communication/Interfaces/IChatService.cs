using Data.Enums;
using Data.Interfaces;

namespace Communication.Interfaces
{
    public interface IChatService : IComponent
    {
        void ProcessMessage(IConnection connection, string message, ChatType type);
        void ProcessPrivateMessage(IConnection connection, string playerName, string message);
        void SendChatInfo(IConnection connection, int type, string name);
    }
}