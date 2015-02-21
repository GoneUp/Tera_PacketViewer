using Communication.Logic;

namespace Network.Client
{
    public class RpPlay : ARecvPacket
    {
        protected int PlayerId;
        public bool IsProlog;

        public override void Read()
        {
            PlayerId = ReadD();
            IsProlog = ReadC() == 1;
        }

        public override void Process()
        {
            PlayerLogic.PlayerSelected(Connection, PlayerId, IsProlog);
        }
    }
}