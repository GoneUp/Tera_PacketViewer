namespace Network.Client
{
    public class RpClimbUp : ARecvPacket
    {
        protected float X;
        protected float Y;
        protected float Z;

        public override void Read()
        {
            X = ReadF();
            Y = ReadF();
            Z = ReadF();
        }

        public override void Process()
        {
            
        }
    }
}