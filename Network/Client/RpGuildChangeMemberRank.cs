
namespace Network.Client
{
    class RpGuildChangeMemberRank : ARecvPacket
    {
        protected int MemberId;
        protected int NewRank;

        public override void Read()
        {
            MemberId = ReadD();
            NewRank = ReadD();
        }

        public override void Process()
        {
            Communication.Global.GuildService.ChangeMemberRank(Connection.Player, MemberId, NewRank);
        }
    }
}
