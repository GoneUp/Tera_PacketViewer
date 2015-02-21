using System.IO;

namespace Network.Server
{
    public class SpCharacterCheckNameResult : ASendPacket
    {
        protected int Result;
        protected string Name;
        protected int Type;

        public SpCharacterCheckNameResult(int result, string name, int type = 1)
        {
            Result = result;
            Name = name;
            Type = type;
        }

        public override void Write(BinaryWriter writer)
        {
            //010008000800000016000200 0000 00000000 4E006500770074006500720061000000
            WriteB(writer, "01000800080000001600");
            WriteD(writer, Type);
            WriteD(writer, Result);
            WriteS(writer, Name);
        }
    }
}