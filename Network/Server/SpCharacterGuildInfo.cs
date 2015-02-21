using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterGuildInfo : ASendPacket
    {
        public Player Player;
        public string GuildName;
        public string GuildMemberLevel;

        public SpCharacterGuildInfo(Player player, string guildName, string guildMemberLevel)
        {
            Player = player;
            GuildName = guildName;
            GuildMemberLevel = guildMemberLevel;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0); //guild name start shift
            WriteD(writer, 0); //member level start shift
            WriteD(writer, 0); //member level end shift
            WriteD(writer, 0); //possible guildlogo shift
            WriteUid(writer, Player);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, GuildName);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, GuildMemberLevel);

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteH(writer, 0);

            writer.Seek(10, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteH(writer, 0);
        }
    }
}