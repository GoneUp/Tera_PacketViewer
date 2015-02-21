namespace Network.Client
{
    class RpServerGuildsPage : ARecvPacket
    {
        protected int TabId;

        public override void Read()
        {
            TabId = ReadD();
        }

        public override void Process()
        {
            Communication.Global.GuildService.SendServerGuilds(Connection.Player, TabId);
        }
    }
}
