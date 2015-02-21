namespace Network.Client
{
    public class RpTeleportCharacter : ARecvPacket
    {
        protected int TeleportId;

        public override void Read()
        {
            TeleportId = ReadD();
        }

        public override void Process()
        {
            Communication.Global.TeleportService.StartPegasusFlight(Connection.Player, TeleportId);
        }
    }
}