using System.IO;
using Utils;

namespace Network.Server
{
    public class SpUISettings : ASendPacket
    {
        protected byte[] UISettings;

        public SpUISettings(byte[] settings)
        {
            UISettings = settings;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteB(writer, UISettings);
        }
    }
}
