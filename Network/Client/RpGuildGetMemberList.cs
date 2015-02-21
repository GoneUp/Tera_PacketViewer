namespace Network.Client
{
    public class RpGuildGetMemberList : ARecvPacket
    {
        public override void Read()
        {
            //empty packet, nothing
        }

        public override void Process()
        {
            Communication.Global.GuildService.SendGuildToPlayer(Connection.Player);
        }
    }
}