namespace Network.Client
{
    public class RpGetServerGuilds : ARecvPacket
    {
        public override void Read()
        {
            ReadD();
        }

        public override void Process()
        {
            Communication.Global.GuildService.SendServerGuilds(Connection.Player, 1);
        }
    }
}