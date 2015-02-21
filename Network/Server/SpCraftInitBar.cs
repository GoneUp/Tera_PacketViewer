using System.IO;
namespace Network.Server
{
    public class SpCraftInitBar : ASendPacket
    {
        protected byte Unk;
        protected int MaxChance;

        public SpCraftInitBar(byte unk = 1, int maxChance = 100)
        {
            Unk = unk;
            MaxChance = maxChance;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, Unk);
            WriteD(writer, MaxChance);
        }
    }
}
