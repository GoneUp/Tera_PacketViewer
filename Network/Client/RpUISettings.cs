using Utils;

namespace Network.Client
{
    public class RpUISettings : ARecvPacket
    {
        public byte[] UISettings;

        public override void Read()
        {
            UISettings = ReadB((int)Reader.BaseStream.Length);
        }

        public override void Process()
        {
            Connection.Account.UiSettings = UISettings;
        }
    }
}