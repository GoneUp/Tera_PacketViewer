using Communication.Logic;

namespace Network.Client
{
    public class RpEnterWorld : ARecvPacket
    {
        public override void Read()
        {
            //Nothing
        }

        public override void Process()
        {
            PlayerLogic.PlayerEnterWorld(Connection.Player);
        }
    }
}