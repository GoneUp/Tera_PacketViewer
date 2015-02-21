using Data.Structures;

namespace Network.Client
{
    public class RpDialogShow : ARecvPacket
    {
        protected long TargetId;

        public override void Read()
        {
            TargetId = ReadQ();
        }

        public override void Process()
        {
            TeraObject obj = Uid.GetObject(TargetId) as TeraObject;

            if (obj != null)
                Communication.Logic.PlayerLogic.ShowDialog(Connection.Player, obj);
        }
    }
}