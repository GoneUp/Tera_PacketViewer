namespace Network.Client
{
    public class RpZoneChange : ARecvPacket
    {
        public byte[] ZoneDatas;
        public override void Read()
        {
            ZoneDatas = ReadB(12);
        }

        public override void Process()
        {
            Communication.Logic.PlayerLogic.PlayerEnterZone(Connection.Player, ZoneDatas);
        }
    }
}