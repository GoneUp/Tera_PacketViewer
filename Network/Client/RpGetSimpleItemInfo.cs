using Network.Server;

namespace Network.Client
{
    public class RpGetSimpleItemInfo : ARecvPacket
    {
        protected int ItemId;

        public override void Read()
        {
            ItemId = ReadD();
        }

        public override void Process()
        {
            new SpSimpleItemInfo(ItemId).Send(Connection);
        }
    }
}