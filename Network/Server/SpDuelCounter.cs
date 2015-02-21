using System.IO;

namespace Network.Server
{
    public class SpDuelCounter : ASendPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0x1388);
        }
    }
}