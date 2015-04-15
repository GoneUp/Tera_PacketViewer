namespace PacketViewer.Network
{
    public class Packet_old
    {
        public bool IsServer { get; set; }
        public ushort OpCode { get; set; }
        public byte[] Data { get; set; }

        public string Name { get; set; }

        public string Hex { get; set; }
        public string Text { get; set; }

       public Packet_old(bool isServer, ushort opCode, string opcodename, byte[] data, bool hexWithSpaces)
        {
            IsServer = isServer;
            OpCode = opCode;
            Data = data;
            Name = opcodename;

            Hex = Data.ToHex();
            Text = "0x" + string.Format("{0:X4}", opCode) + "\n\n" + Data.FormatHex();

           if (hexWithSpaces)
           {
               string newHex = "";
               for (int i = 0; i < Hex.Length; i += 2)
               {
                   newHex += Hex.Substring(i, 2) + " ";
               }
               Hex = newHex;
           }
        }
    }
}
