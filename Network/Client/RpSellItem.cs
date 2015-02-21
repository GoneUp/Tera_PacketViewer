namespace Network.Client
{
    public class RpSellItem : ARecvPacket
    {
        protected int ItemId;
        protected int Counter;
        protected long PlayerUid;
        protected int Slot;

        public override void Read()
        {
            PlayerUid = ReadQ();
            ReadD(); // dialog uid?
            ItemId = ReadD();
            Counter = ReadD();
            Slot = ReadD();
        }

        public override void Process()
        {
            Communication.Global.PlayerService.AddItemsToNpcSell(Connection.Player, ItemId, Counter, Slot);
        }
    }
}