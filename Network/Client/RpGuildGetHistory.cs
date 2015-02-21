namespace Network.Client
{
    public class RpGuildGetHistory : ARecvPacket
    {
        protected int Unk;

        public override void Read()
        {
            Unk = ReadD();
        }

        public override void Process()
        {
            Communication.Global.GuildService.SendGuildHistory(Connection.Player);
        }
    }
}