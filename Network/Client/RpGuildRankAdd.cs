namespace Network.Client
{
    class RpGuildRankAdd : ARecvPacket
    {
        protected string RankName;

        public override void Read()
        {
            ReadH();
            RankName = ReadS();
        }

        public override void Process()
        {
            Communication.Global.GuildService.CreateNewRank(Connection.Player.Guild, RankName);
        }
    }
}
