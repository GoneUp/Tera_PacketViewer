using Communication.Logic;

namespace Network.Client
{
    class RpExit : ARecvPacket
    {
        public override void Read()
        {
            //Nothing
        }

        public override void Process()
        {
            AccountLogic.ExitPlayer(Connection);
        }
    }
}