namespace Network.Client
{
    class RpMountUnkQuestion : ARecvPacket
    {
        protected long Uid;
        protected int Unk2;

        public override void Read()
        {
            Uid = ReadQ();
            Unk2 = ReadD(); //30
        }

        public override void Process()
        {
            Communication.Global.MountService.UnkQuestion(Connection.Player, Unk2);
        }
    }
}
