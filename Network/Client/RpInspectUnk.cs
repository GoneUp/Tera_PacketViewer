using Network.Server;

namespace Network.Client
{
    public class RpInspectUnk : ARecvPacket
    {
        public override void Read()
        { }

        public override void Process()
        {
            new SpInspectUnk().Send(Connection);
        }
    }
}
