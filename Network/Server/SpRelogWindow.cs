using System.IO;

namespace Network.Server
{
    public class SpRelogWindow : ASendPacket
    {
        protected int Time;

        public SpRelogWindow(int time)
        {
            Time = time;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Time);
        }
    }
}