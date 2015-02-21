namespace Network.Client
{
    public class RpTradeInterupt : ARecvPacket
    {
        protected int Uid;

        public override void Read()
        {
            ReadQ(); //my uid
            ReadQ(); //other uid
            Uid = ReadD(); //TradeUid
        }

        public override void Process()
        {
            Communication.Global.PlayerService.InterruptNpcTraid(Connection.Player);
        }
    }
}