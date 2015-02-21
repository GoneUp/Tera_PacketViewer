namespace Network.Client
{
    public class RpInactive : ARecvPacket
    {
        public override void Read()
        {
            ReadD(); //1
        }

        public override void Process()
        {
            
        }
    }
}