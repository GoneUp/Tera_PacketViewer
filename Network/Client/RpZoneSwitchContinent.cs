using Communication.Logic;

namespace Network.Client
{
    class RpZoneSwitchContinent : ARecvPacket
    {
        protected int ContinentId;

        public override void Read()
        {
            ReadD(); //Unk1
            ContinentId = ReadD();
            //ReadD(); //Unk2 0xFFFFFFFF
        }

        public override void Process()
        {
            if (Connection.Player == null)
                return;

            PlayerLogic.SwitchContinent(Connection.Player, ContinentId);
        }
    }
}
