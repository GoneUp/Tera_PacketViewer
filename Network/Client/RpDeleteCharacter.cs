using Network.Server;

namespace Network.Client
{
    public class RpDeleteCharacter : ARecvPacket
    {
        protected int PlayerIndex;

        public override void Read()
        {
            PlayerIndex = ReadD();
        }

        public override void Process()
        {
            Communication.Logic.AccountLogic.RemovePlayer(Connection, PlayerIndex);
        }
    }
}