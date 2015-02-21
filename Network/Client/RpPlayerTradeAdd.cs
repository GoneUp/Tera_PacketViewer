namespace Network.Client
{
    public class RpPlayerTradeAdd : ARecvPacket
    {
        protected int Slot;
        protected int Counter;
        protected long Money;

        public override void Read()
        {
            ReadQ(); // SellerUid 
            ReadQ(); // TargetUid 
            ReadD(); // Trade id
            ReadQ(); //seller uid too
            Slot = ReadD(); // omg... Slot - ??
            Counter = ReadD();
            Money = ReadQ(); // Money
        }

        public override void Process()
        {
            if(Slot > 0)
                Communication.Global.TradeService.AddItem(Connection.Player, Slot - 20, Counter);

            if(Money > 0)
                Communication.Global.TradeService.ChangeMoney(Connection.Player, Money);
        }
    }
}