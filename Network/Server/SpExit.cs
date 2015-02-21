using System.IO;

namespace Network.Server
{
    public class SpExit : ASendPacket
    {
        protected int Unk1;
        protected int Unk2;

        public SpExit(int unk1 = 0, int unk2 = 1)
        {
            Unk1 = unk1;
            Unk2 = unk2;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Unk1);
            WriteD(writer, Unk2);
        }
    }
}
