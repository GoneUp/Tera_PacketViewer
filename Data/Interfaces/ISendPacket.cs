namespace Data.Interfaces
{
    public interface ISendPacket
    {
        void Send(IConnection connection);
    }
}