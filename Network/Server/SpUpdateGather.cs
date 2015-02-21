using System.IO;
using Data.Enums.Gather;

namespace Network.Server
{
    public class SpUpdateGather : ASendPacket
    {
        protected TypeName Type;
        protected short Value;

        public SpUpdateGather(TypeName type, short value)
        {
            Type = type;
            Value = value;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Type.GetHashCode());
            WriteH(writer, Value);
        }
    }
}