using Communication.Logic;

namespace Network.Client
{
    public class RpGetPlayerList : ARecvPacket
    {
        public override void Read()
        {
            //Nothing
        }

        public override void Process()
        {
            AccountLogic.GetPlayerList(Connection);
        }
    }
}