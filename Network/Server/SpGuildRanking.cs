using System.IO;
using Data.Structures.Guild;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpGuildRanking : ASendPacket
    {
        protected Player Player;
        protected Guild Guild;

        public SpGuildRanking(Player player)
        {
            Guild = player.Guild;
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Guild.GuildRanks.Count);
            WriteH(writer, 0); //header end shift
            WriteH(writer, 0); //guild name start shift
            WriteH(writer, 0); //guild name end shift
            WriteH(writer, 0); //leader name start
            WriteH(writer, 0); //leader name end
            WriteH(writer, 0); //status name start
            WriteH(writer, 0); //status name end
            WriteB(writer, "D30000000000000000000000");
            WriteD(writer, Communication.Global.GuildService.GetLeader(Guild).PlayerId);
            WriteD(writer, Guild.CreationDate);
            WriteB(writer, "00000000010000000000000000000000FFFFFFFF");

            WriteH(writer, 1); //???

            //20

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Guild.GuildName);

            writer.Seek(10, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Guild.GuildTitle);

            writer.Seek(12, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Communication.Global.GuildService.GetLeader(Guild).PlayerData.Name);

            writer.Seek(14, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Guild.GuildMessage);

            writer.Seek(16, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Communication.Global.GuildService.GetPlayerRank(Player).RankName);

            writer.Seek(18, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Guild.GuildAd);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            for (int i = 0; i < Guild.GuildRanks.Count; i++)
            {
                short sh = (short) writer.BaseStream.Length;

                WriteH(writer, sh);
                WriteH(writer, 0);
                WriteH(writer, 0);
                WriteD(writer, Guild.GuildRanks[i].RankId);

                WriteD(writer, Guild.GuildRanks[i].RankPrivileges);

                writer.Seek(sh + 4, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, Guild.GuildRanks[i].RankName);

                if (Guild.GuildRanks.Count > i + 1)
                {
                    writer.Seek(sh + 2, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
            }
        }

        //BC80 0200 7C003E004C004E00600062007A00D30000000000000000000000FD8D0000359E954F00000000010000000000000000000000FFFFFFFF01004F006E007400650072006100000000004D00650074006100770069006E006400000000004700750069006C0064006D006100730074006500720000000000 7C00 A200 8A00 01000000 00000000 4700750069006C0064006D00610073007400650072000000 A2000000B000020000000000000052006500630072007500690074000000
        //BC80 0200 7C003E004C004E00600062007A00D30000000000000000000000E75A0A00359E954F00000000010000000000000000000000FFFFFFFF01004F006E005400650072006100000000004D00650074006100570069006E006400000000004700750069006C0064006D006100730074006500720000000000 7C00A2008A0001000000000000004700750069006C0064006D006100730074006500720000000000A2000000B000020000000000000052006500630072007500690074000000
    }
}