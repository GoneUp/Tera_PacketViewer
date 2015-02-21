using System.IO;

namespace Network.Server
{
    public class SpCheckVersion : ASendPacket
    {
        protected int Version;

        public SpCheckVersion(int version)
        {
            Version = version;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, (byte) (Version == OpCodes.Version ? 1 : 0));
        }
    }
}