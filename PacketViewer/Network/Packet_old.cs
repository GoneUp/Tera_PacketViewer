namespace PacketViewer.Network
{
    public class Packet_old
    {
        public Direction Dir;
        public ushort OpCode;  
        public string OpName;

        public byte[] Data;
        public string HexShortText;
        public string HexLongText;

        public Packet_old(Direction dir, ushort opCode, byte[] data, bool hexWithSpaces)
        {
            Dir = dir;
            OpCode = opCode;
            Data = data;
            OpName = PacketTranslator.GetOpcodeName(opCode); ;

            HexShortText = Data.ToHex();
            HexLongText = "0x" + string.Format("{0:X4}", opCode) + "\n\n" + Data.FormatHex();

            if (hexWithSpaces)
            {
                string newHex = "";
                for (int i = 0; i < HexShortText.Length; i += 2)
                {
                    newHex += HexShortText.Substring(i, 2) + " ";
                }
                HexShortText = newHex;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} [{2}]", (Dir == Direction.SC) ? "S" : "C" , OpName, Data.Length);
        }
    }

    public enum Direction
    {
        CS,
        SC
    }
}
