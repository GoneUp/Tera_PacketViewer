using Communication.Logic;

namespace Network.Client
{
    class RpGetBindPoint : ARecvPacket
    {
        public override void Read()
        {
            //Nothing
        }

        public override void Process()
        {
            PlayerLogic.SendBindPoint(Connection);
        }
    }
}
