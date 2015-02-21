using System.IO;
using System.Text;
using Data.Structures.Guild;

namespace Network.Server
{
    public class SpGuildHistory : ASendPacket
    {
        protected Guild Guild;

        public SpGuildHistory(Guild guild)
        {
            Guild = guild;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Guild.GuildHistory.Count); //possible history events counter
            WriteH(writer, 0); //header end shift
            WriteD(writer, 1);
            WriteD(writer, 1);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            for (int i = 0; i < Guild.GuildHistory.Count; i++)
            {
                short sh = (short) writer.BaseStream.Length;

                WriteH(writer, sh);
                WriteH(writer, 0); //next event shift

                WriteH(writer, 0); //initiator name start shift
                WriteH(writer, 0); //initiator name end shift
                WriteD(writer, Guild.GuildHistory[i].Date);
                WriteD(writer, 0);
                WriteD(writer, 11);

                writer.Seek(sh + 4, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, Guild.GuildHistory[i].Initiator);

                writer.Seek(sh + 6, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                for (int j = 0; j < Guild.GuildHistory[i].Args.Length; j++)
                {
                    if (j != 0)
                        WriteH(writer, 11);

                    writer.Write(Encoding.Unicode.GetBytes(Guild.GuildHistory[i].Args[j]));
                }

                WriteH(writer, 0);

                if (Guild.GuildHistory.Count > i + 1)
                {
                    writer.Seek(sh + 2, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
            }
            
        }
    }

    //4EA0 0500100001000000010000001000660024003600359E954F000000000B000000 4D00650074006100770069006E0064000000 40006700750069006C0064003A003700390038000B0055007300650072004E0061006D0065000B0045006C00610000006600C6007A008C00359E954F000000000B0000004D00650074006100770069006E006400000040006700750069006C0064003A003700390038000B0055007300650072004E0061006D0065000B004D00650074006100770069006E0064000000C6002601DA00EC00359E954F00000000150000004D00650074006100770069006E006400000040006700750069006C0064003A003800300031000B00470072006F00750070004E0061006D0065000B005200650063007200750069007400000026018E013A014C01359E954F00000000150000004D00650074006100770069006E006400000040006700750069006C0064003A003800300031000B00470072006F00750070004E0061006D0065000B004700750069006C0064006D006100730074006500720000008E01 0000 A201 B401 359E954F00000000010000004D00650074006100770069006E006400000040006700750069006C0064003A003700390036000000
    //4EA0 01001000010000000100000010000000240036008BBE9D4F000000000B000000 4D00650074006100570069006E0064000000 060040006700750069006C0064003A003800300031000B00470072006F00750070004E0061006D0065000B0054006500730074000000
}