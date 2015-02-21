namespace Network.Client
{
    public class RpGuildInvite : ARecvPacket //6A2B
    {
        protected string InvitedName;
        protected string Message;
        protected byte[] Unk;

        public override void Read()
        {
            Unk = ReadB(4);
            InvitedName = ReadS();
            Message = ReadS();
        }

        public override void Process()
        {
            
        }
    }
}