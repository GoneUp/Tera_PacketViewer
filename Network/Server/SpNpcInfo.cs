using System.IO;
using Data.Structures.Npc;

namespace Network.Server
{
    public class SpNpcInfo : ASendPacket
    {
        protected Npc Npc;
        protected string TestNpcHex;

        public SpNpcInfo(Npc npc)
        {
            Npc = npc;
        }

        public SpNpcInfo(string hex)
        {
            TestNpcHex = hex;
        }

        public override void Write(BinaryWriter writer)
        {
            if (TestNpcHex != null)
            {
                WriteB(writer, TestNpcHex);
                return;
            }

            WriteD(writer, 0); //???
            WriteH(writer, 0); //Shit shift

            WriteUid(writer, Npc);
            WriteUid(writer, Npc.Target);
            WriteF(writer, Npc.Position.X);
            WriteF(writer, Npc.Position.Y);
            WriteF(writer, Npc.Position.Z);
            WriteH(writer, Npc.Position.Heading);
            WriteD(writer, 12); //???
            WriteD(writer, Npc.SpawnTemplate.NpcId);
            WriteH(writer, Npc.SpawnTemplate.Type);
            WriteD(writer, 0); //ModelId
            
            WriteB(writer, "000000000500000001010100000000000000000000000000000000000000");

            WriteUid(writer, Npc.Target); //If 1 agressiv

            WriteB(writer, "000000000000000000");

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length); //Shit shift
            writer.Seek(0, SeekOrigin.End);

            WriteB(writer, "45C5C8B958C72000E4C2D8D5B4CC0000"); //Shit
        }
    }
}