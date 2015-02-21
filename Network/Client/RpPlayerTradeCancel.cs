namespace Network.Client
{
    public class RpPlayerTradeCancel : ARecvPacket
    {
        public override void Read()
        {
            //Q Uid1
            //Q Uid2
            //D TradeId
        }

        public override void Process()
        {
            Communication.Global.TradeService.Cancel(Connection.Player);
        }
    }
}
