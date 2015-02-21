using System.IO;
using System.Text;

namespace Network.Server
{
    public class SpPlayerTradeHistory : ASendPacket
    {
        protected string[] Args;

        public SpPlayerTradeHistory(string[] args)
        {
            Args = args;
        }

        public override void Write(BinaryWriter writer)
        {
            for (int i = 0; i < Args.Length; i++)
            {
                WriteH(writer, (short)(i == 0 ? 6 : 11));
                writer.Write(Encoding.Unicode.GetBytes(Args[i]));
            }

            WriteH(writer, 0);
        }
    }
}