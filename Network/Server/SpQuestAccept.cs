using System.IO;
using Utils;

namespace Network.Server
{
    public class SpQuestAccept : ASendPacket
    {
        protected string Options;

        public SpQuestAccept(string options)
        {
            Options = options;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0x0006); //shift??
            WriteH(writer, 0x0040); //shift??
            WriteB(writer, "3600320034000B00510075006500730074004E0061006D0065000B00");
            WriteS(writer, Options);
        }
    }
}