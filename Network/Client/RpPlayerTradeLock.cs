namespace Network.Client
{
    public class RpPlayerTradeLock : ARecvPacket
    {
        public override void Read()
        {
            ReadQ(); // my uid
            ReadQ(); //other uid
            ReadD(); //trade Uid
            ReadQ(); //my uid too
        }

        public override void Process()
        {
            Communication.Global.TradeService.Lock(Connection.Player);
        }
    }
}