using System.IO;

namespace Network.Server
{
    public class SpInspectUnk : ASendPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0x0e);
            WriteD(writer, 0x0e);
        }
    }
}
