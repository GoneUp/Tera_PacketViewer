using Utils;

namespace Network.Client
{
    public class RpRequestCancel : ARecvPacket
    {
        protected int Uid;
        protected int Type;

        public override void Read()
        {
            Type = ReadD();
            Uid = ReadD();
        }

        public override void Process()
        {
            Log.Debug("Request cancel arrived from {0}", Connection.Player.PlayerData.Name);
            Communication.Global.ActionEngine.ProcessRequest(Uid, false, Connection.Player);
        }
    }
}