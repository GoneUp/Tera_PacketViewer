namespace Network.Client
{
    class RpGuildChangeAd : ARecvPacket
    {
        protected string Ad;

        public override void Read()
        {
            ReadH();
            Ad = ReadS();
        }

        public override void Process()
        {
            Communication.Global.GuildService.ChangeAd(Connection.Player, Ad);
        }
    }
}
