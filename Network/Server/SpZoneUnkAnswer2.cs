using System.IO;

namespace Network.Server
{
    public class SpZoneUnkAnswer2 : ASendPacket
    {
        public int Params;
        public short Unk1;
        public short Unk2;

        public SpZoneUnkAnswer2(int pBytes, short unk1 = 0, short unk2 = 0)
        {
            Params = pBytes;
            Unk1 = unk1;
            Unk2 = unk2;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteD(writer, Params);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteH(writer,Unk1);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteH(writer, Unk2);
        }
    }
}
