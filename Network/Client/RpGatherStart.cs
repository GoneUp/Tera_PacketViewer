namespace Network.Client
{
    public class RpGatherStart : ARecvPacket
    {
        protected long GatherUid;

        public override void Read()
        {
            GatherUid = ReadQ();
        }

        public override void Process()
        {
            Communication.Global.PlayerService.StartGather(Connection.Player, GatherUid);
        }
    }
}