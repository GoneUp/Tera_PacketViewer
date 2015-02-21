using System.IO;

namespace Network.Server
{
    public class SpCraftProgress : ASendPacket
    {
        protected byte State;
        protected byte Unk;
        protected short Unk2;
        protected byte Unk3;
        protected byte Unk4;

        public SpCraftProgress(byte state, byte unk = 1, short unk2 = 0, byte unk3 = 0, byte unk4 = 1)
        {
            State = state;
            Unk = unk;
            Unk2 = unk2;
            Unk3 = unk3;
            Unk4 = unk4;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, Unk);
            WriteC(writer, State);
            WriteH(writer, Unk2);
            WriteC(writer, Unk3);
            WriteC(writer, Unk4);
        }
    }
}
