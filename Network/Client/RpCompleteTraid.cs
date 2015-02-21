namespace Network.Client
{
    public class RpCompleteTraid : ARecvPacket
    {
        protected int DialogUid;

        public override void Read()
        {
            ReadD(); //04070000
            ReadD(); //0
            DialogUid = ReadD();
        }

        public override void Process()
        {
            Communication.Global.PlayerService.CompleteNpcTraid(Connection.Player, DialogUid);
        }
    }
}