using Communication.Logic;

namespace Network.Client
{
    public class RpCheckName : ARecvPacket
    {
        protected string Name;
        protected short Type;

        public override void Read()
        {
            ReadB(14);
            Type = (short) ReadH();
            ReadH();
            Name = ReadS();
        }

        public override void Process()
        {
            PlayerLogic.CheckName(Connection, Name, Type);
        }
    }
}