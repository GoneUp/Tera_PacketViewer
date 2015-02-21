using Communication.Logic;

namespace Network.Client
{
    public class RpUnstuck : ARecvPacket
    {
        public override void Read()
        {
            //Unused 8 bytes
        }

        public override void Process()
        {
            PlayerLogic.Unstuck(Connection);
        }
    }
}
