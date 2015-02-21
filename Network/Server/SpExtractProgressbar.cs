using System.IO;

namespace Network.Server
{
    public class SpExtractProgressbar : ASendPacket
    {
        protected int Counter;
        protected bool IsForStop;

        public SpExtractProgressbar(int counter, bool isForStop = false)
        {
            Counter = counter;
            IsForStop = isForStop;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) (IsForStop ? 0 : 257)); //oO
            WriteD(writer, Counter);
        }
    }
}