namespace Network.Client
{
    public class RpAddToTrade : ARecvPacket
    {
        protected int DialogUid; // not shure...
        protected int ItemId;
        protected int ItemsCounter;
        protected long PlayerUid;

        public override void Read()
        {
            PlayerUid = ReadQ();
            DialogUid = ReadD();
            ItemId = ReadD();
            ItemsCounter = ReadD();
        }

        public override void Process()
        {
            Communication.Global.PlayerService.AddItemsToNpcBuy(Connection.Player, ItemId, ItemsCounter);
        }
    }
}