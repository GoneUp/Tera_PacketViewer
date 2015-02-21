using System.IO;

namespace Network.Server
{
    public class SpExitWindow : ASendPacket
    {
        protected int Timeout;

        public SpExitWindow(int timeout)
        {
            Timeout = timeout;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Timeout);
        }
    }
}
