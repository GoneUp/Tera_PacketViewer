using Network.Server;

namespace Network.Client
{
    public class RpGuildOnServer : ARecvPacket
    {
        public override void Read()
        {
            // D 6
        }

        public override void Process()
        {
            new SpGuildsOnServer().Send(Connection);
        }
    }
}