using Communication.Logic;

namespace Network.Client
{
    class RpAbortRelog : ARecvPacket
    {
        public override void Read()
        {
            //Nothing
        }

        public override void Process()
        {
            AccountLogic.AbortExitAction(Connection);
        }
    }
}
