using System.Collections.Generic;
using Hik.Communication.ScsServices.Service;

namespace Communication.Interfaces
{
    [ScsService]
    public interface IInformerService : IComponent
    {
        void Auth(string key);
        List<string> GetOnlineList();
        void WatchAccount(string accountName);
        void ShutdownServer();

        #region events

        void OnAccountAuthed(string accountName);
        void OnAccountDiconnected(string accountName);

        void PacketSent(string accountName, string name, byte[] buffer, string callStack);
        void PacketReceived(string accountName, string name, byte[] buffer, string callStack);

        #endregion
    }
}