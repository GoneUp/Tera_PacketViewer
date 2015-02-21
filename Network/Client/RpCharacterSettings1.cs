namespace Network.Client
{
    public class RpCharacterSettings1 : ARecvPacket
    {
        protected byte[] Settings;

        public override void Read()
        {
            Settings = ReadB((int) Reader.BaseStream.Length);
        }

        public override void Process()
        {
            Connection.Account.UiSettings = Settings;
        }
    }
}