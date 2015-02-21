using Communication.Logic;

namespace Network.Client
{
    public class RpRelog : ARecvPacket
    {
        public override void Read()
        {
            //empty packet
        }

        public override void Process()
        {
            AccountLogic.RelogPlayer(Connection);
        }
    }
}