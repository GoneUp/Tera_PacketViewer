namespace Network.Client
{
    class RpGuildMemberLeave : ARecvPacket
    {
        public override void Read()
        {
            //empty packet
        }

        public override void Process()
        {
            Communication.Global.GuildService.LeaveGuild(Connection.Player, Connection.Player.Guild);
        }
    }
}
