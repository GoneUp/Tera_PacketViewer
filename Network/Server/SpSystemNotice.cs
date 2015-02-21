using System.IO;

namespace Network.Server
{
    public class SpSystemNotice : ASendPacket
    {
        protected string Text;
        protected int TimeoutSeconds;

        public SpSystemNotice(string text, int timeoutSeconds = 1)
        {
            Text = text;
            TimeoutSeconds = timeoutSeconds;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 15); //Text shift
            WriteH(writer, 1);
            WriteC(writer, 0x99);
            WriteC(writer, 0xFF);
            WriteC(writer, 0);
            WriteD(writer, TimeoutSeconds);
            WriteS(writer, Text);
        }
    }
}