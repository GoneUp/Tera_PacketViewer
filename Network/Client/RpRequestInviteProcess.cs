namespace Network.Client
{
    public class RpRequestInviteProcess : ARecvPacket
    {
        protected int DialogUid;
        protected string PlayerName;
        protected bool IsAccept;
        protected int Type;

        public override void Read()
        {
            ReadH(); //name shift
            Type = ReadD();
            DialogUid = ReadD();
            ReadD();
            IsAccept = ReadD() == 1; //1 - is accept, 2 - decline
            PlayerName = ReadS();
        }

        public override void Process()
        {
            Communication.Global.ActionEngine.ProcessRequest(DialogUid, IsAccept, Connection.Player);
        }
    }
}