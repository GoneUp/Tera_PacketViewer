namespace Network.Client
{
    public class RpChatBlock : ARecvPacket
    {
        protected string NameOfFlooder;

        public override void Read()
        {
            ReadH();
            NameOfFlooder = ReadS();
        }

        public override void Process()
        {
            
        }
    }
}