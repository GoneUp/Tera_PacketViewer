using Communication.Logic;

namespace Network.Client
{
    public class RpCheckNameForUse : ARecvPacket
    {
        protected short Type;
        protected string Name;

        public override void Read()
        {
            Type = (short) ReadH();
            Name = ReadS();
        }

        public override void Process()
        {
            PlayerLogic.CheckNameForUse(Connection, Name, Type);
        }
    }
}