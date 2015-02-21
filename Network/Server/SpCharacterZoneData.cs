using System.IO;

namespace Network.Server
{
    public class SpCharacterZoneData : ASendPacket
    {
        protected byte[] Datas;

        public SpCharacterZoneData(byte[] datas)
        {
            Datas = datas;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, 0);
            WriteB(writer, Datas);
        }
    }
}