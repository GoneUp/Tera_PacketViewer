namespace Network.Client
{
    class RpGuildChangeRankPrivileges : ARecvPacket
    {
        public int NewPrivileges;
        protected int RankId;
        public string RankName;

        public override void Read()
        {
            ReadH(); //unk
            RankId = ReadD();
            NewPrivileges = ReadD();
            RankName = ReadS();
        }

        public override void Process()
        {
            Communication.Global.GuildService.ChangeRankPrivileges(Connection.Player, RankId, NewPrivileges, RankName);
        }
    }
}
