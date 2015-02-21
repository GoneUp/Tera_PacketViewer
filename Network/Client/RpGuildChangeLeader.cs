namespace Network.Client
{
    class RpGuildChangeLeader : ARecvPacket
    {
        protected string NewLeaderName;

        public override void Read()
        {
            ReadH();
            NewLeaderName = ReadS();
        }

        public override void Process()
        {
            Communication.Global.GuildService.ChangeGuildLeader(Connection.Player, NewLeaderName);
        }
    }
}
