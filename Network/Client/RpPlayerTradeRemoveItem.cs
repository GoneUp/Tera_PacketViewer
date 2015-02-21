namespace Network.Client
{
    public class RpPlayerTradeRemoveItem : ARecvPacket
    {
        protected int Slot;
        protected int Count;

        public override void Read()
        {
            ReadQ(); // My uid
            ReadQ(); // Other uid
            ReadD(); // Trade id
            ReadQ(); // My uid
            Slot = ReadD();
            Count = ReadD(); // count
            //Money = ReadQ();
        }

        public override void Process()
        {
            if (Slot >= 0 && Count > 0)
                Communication.Global.TradeService.RemoveItem(Connection.Player, Slot, Count);
        }
    }
}
