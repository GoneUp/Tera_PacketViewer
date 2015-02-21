using System.IO;

namespace Network.Server
{
    public class SpZoneUnkAnswer : ASendPacket
    {
        protected byte Sw;

        public SpZoneUnkAnswer(byte sw)
        {
            Sw = sw;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, Sw);
        }
    }
}