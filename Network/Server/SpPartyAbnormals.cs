using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPartyAbnormals : ASendPacket
    {
        protected Player Player;

        //public SpPartyAbnormals(Player player) // WRONG
        //{
        //    Player = player;
        //}

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0);
            WriteH(writer, (short) Player.Effects.Count);
            WriteH(writer, 0); //first effect shift
            WriteD(writer, 11); //hello AGAIN, fucking 0x0b shit...how are you? -_-
            WriteD(writer, Player.PlayerId);

            writer.Seek(10, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            for (int i = 0; i < Player.Effects.Count; i++)
            {
                short shPos = (short) writer.BaseStream.Position;

                WriteH(writer, shPos);
                WriteH(writer, 0); //next abnormal
                WriteD(writer, 0);
                WriteD(writer, 0);
                WriteC(writer, 1); //possible IsBuff

                if (Player.Effects.Count > i + 1)
                {
                    writer.Seek(shPos + 2, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
            }
        }
    }
}