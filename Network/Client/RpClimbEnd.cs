namespace Network.Client
{
    public class RpClimbEnd : ARecvPacket
    {
        protected float X;
        protected float Y;
        protected float Z;
        protected short Heading;

        public override void Read()
        {
            X = ReadF();
            Y = ReadF();
            Z = ReadF();
            Heading = (short) ReadH();
        }

        public override void Process()
        {
            
        }
    }
}