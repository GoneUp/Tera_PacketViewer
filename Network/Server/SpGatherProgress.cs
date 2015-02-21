using System.IO;

namespace Network.Server
{
    public class SpGatherProgress : ASendPacket
    {
        protected int Progress;

        public SpGatherProgress(int progress)
        {
            Progress = progress;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Progress);
        }
    }
}