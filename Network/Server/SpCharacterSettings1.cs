using System.IO;

namespace Network.Server
{
    public class SpCharacterSettings1 : ASendPacket
    {
        protected byte[] Settings;

        public SpCharacterSettings1(byte[] settings)
        {
            Settings = settings;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteB(writer, Settings);
        }
    }
}