namespace Network.Client
{
    public class RpFriendAdd : ARecvPacket
    {
        protected string Name;

        public override void Read()
        {
            ReadH(); //shift?
            Name = ReadS();
        }

        public override void Process()
        {
            
        }
    }
}