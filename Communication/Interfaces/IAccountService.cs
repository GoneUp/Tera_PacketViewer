using Data.Interfaces;

namespace Communication.Interfaces
{
    public interface IAccountService : IComponent
    {
        void Authorized(IConnection connection, string accountName);
        void AbortExitAction(IConnection connection);
    }
}
