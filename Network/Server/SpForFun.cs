using System.IO;

namespace Network.Server
{
    public class SpForFun : ASendPacket
    {
        protected string Text;

        public SpForFun(string text)
        {
            Text = text;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteS(writer, Text);
        }
    }
}