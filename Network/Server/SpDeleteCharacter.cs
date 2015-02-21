using System.IO;

namespace Network.Server
{
    public class SpCharacterDelete : ASendPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, 1);
        }
    }
}