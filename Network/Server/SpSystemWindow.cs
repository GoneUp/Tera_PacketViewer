using System.IO;
using Data.Enums;

namespace Network.Server
{
    public class SpSystemWindow : ASendPacket
    {
        protected SystemWindow Window;

        public SpSystemWindow(SystemWindow window)
        {
            Window = window;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Window.GetHashCode());
        }
    }
}