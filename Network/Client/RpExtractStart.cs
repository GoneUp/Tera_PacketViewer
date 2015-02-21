namespace Network.Client
{
    public class RpExtractStart : ARecvPacket
    {
        protected int Type;

        public override void Read()
        {
            Type = ReadD();
        }

        public override void Process()
        {
            
        }
    }
}