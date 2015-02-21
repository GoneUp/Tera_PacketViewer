namespace Network.Client
{
    public class RpInteruptAction : ARecvPacket
    {
        protected int Unk1;
        protected int Unk2;
        protected int Unk3;

        public override void Read()
        {
            Unk1 = ReadD(); // 0
            Unk2 = ReadD(); // 0
            Unk3 = ReadD(); // 1
        }

        public override void Process()
        {
            Connection.Player.Controller.Release();
        }
    }
}