namespace Network.Client
{
    public class RpRequestAccept : ARecvPacket
    {
        protected int Uid;
        protected int Type;

        public override void Read()
        {
            Type = ReadD();
            Uid = ReadD();
        }

        public override void Process()
        {
            Communication.Global.ActionEngine.ProcessRequest(Uid, true, Connection.Player);
        }
    }
}