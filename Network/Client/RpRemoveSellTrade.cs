namespace Network.Client
{
    public class RpRemoveSellTrade : ARecvPacket
    {
        protected long PlayerUid;
        protected int DialogUid; //not sure
        protected int ItemId;
        protected int ItemCounter;

        public override void Read()
        {
            PlayerUid = ReadQ();
            DialogUid = ReadD();
            ItemId = ReadD();
            ItemCounter = ReadD();
        }

        public override void Process()
        {
            Communication.Global.PlayerService.RemoveSellItemsFromNpcTrade(Connection.Player, ItemId, ItemCounter, DialogUid);
        }
    }
}