namespace Network.Client
{
    public class RpPartyRemoveMember : ARecvPacket
    {
        protected int PlayerId;

        public override void Read()
        {
            ReadD();
            PlayerId = ReadD();
        }

        public override void Process()
        {
            Communication.Global.PartyService.KickPlayerFromParty(Connection.Player, PlayerId);
        }
    }
}