namespace Network.Client
{
    class RpGuildChangeMotd : ARecvPacket
    {
        protected string NewMotd;

        public override void Read()
        {
            ReadH();
            NewMotd = ReadS();
        }

        public override void Process()
        {
            Communication.Global.GuildService.ChangeMotd(Connection.Player, NewMotd);
        }
    }
}
