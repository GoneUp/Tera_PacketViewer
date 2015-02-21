namespace Network.Client
{
    public class RpAddToExtract : ARecvPacket
    {
        protected int Type;
        protected long ItemUid;

        public override void Read()
        {
            Type = ReadD();
            ItemUid = ReadQ();
        }

        public override void Process()
        {
            
        }
    }
}