using Data.Structures.Account;
using Data.Structures.Player;

namespace Data.Interfaces
{
    public interface IConnection
    {
        Account Account { get; set; }
        Player Player { get; set; }
        bool IsValid { get; }

        void Close();
        void PushPacket(byte[] data);
        long Ping();
    }
}
