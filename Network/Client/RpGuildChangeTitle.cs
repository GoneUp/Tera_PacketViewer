namespace Network.Client
{
    class RpGuildChangeTitle : ARecvPacket
    {
        protected string NewTitle;

        public override void Read()
        {
            ReadH();
            NewTitle = ReadS();
        }

        public override void Process()
        {
            Communication.Global.GuildService.ChangeTitle(Connection.Player, NewTitle);
        }
    }
}
