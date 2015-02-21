using System.Collections.Generic;
using System.IO;
using Data.Structures.Guild;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpGuildMemberList : ASendPacket
    {
        protected Guild Guild;
        protected bool OpenGuildWindow;

        public SpGuildMemberList(Guild guild)
        {
            Guild = guild;
        }

        public SpGuildMemberList()
        {
        }

        //E090 0200 0B00 01 01 01 0B00 4E00 4400 4C00 A7250000 010000000100000001000000 02000000 0C000000 04000000 05000000 01000000 00000000 889D954F 00000000 00 4500 6C00 61000000                   0000   4E00 0000 8700 9900 FD8D0000010000000100000001000000010000000B00000004000000060000000100000000000000779D954F0000000000 4D00650074006100770069006E0064000000 0000
        public override void Write(BinaryWriter writer)
        {
            if (Guild == null)
            {
                WriteH(writer, 0);
                WriteH(writer, 0x000b);
                WriteC(writer, 1);
                WriteC(writer, 1);
                WriteC(writer, 1);

                return;
            }

            WriteH(writer, (short)Guild.GuildMembers.Count);
            WriteH(writer, 0x000b); //header end shift
            WriteC(writer, 1);
            WriteC(writer, 1);
            WriteC(writer, 1);

            int ch = 0;

            foreach (KeyValuePair<Player, int> guildMember in Guild.GuildMembers)
            {
                WriteH(writer, (short)writer.BaseStream.Length);

                WriteH(writer, 0); // first member end shift

                short nameStartShiftFlag = (short)writer.BaseStream.Length;

                WriteH(writer, 0); //name start shift
                WriteH(writer, 0); //name end shift
                WriteD(writer, guildMember.Key.PlayerId);
                WriteB(writer, "010000000100000001000000"); // unk datas, possible curent zone
                WriteD(writer, guildMember.Value);
                WriteD(writer, guildMember.Key.GetLevel());
                WriteD(writer, guildMember.Key.PlayerData.Race.GetHashCode());
                WriteD(writer, guildMember.Key.PlayerData.Class.GetHashCode());
                WriteD(writer, 1); //possible mapid
                WriteD(writer, Communication.Global.PlayerService.IsPlayerOnline(guildMember.Key) ? 0 : 1);
                WriteD(writer, guildMember.Key.LastOnline);
                WriteD(writer, 0); // unk datas 2
                WriteC(writer, 0); // blue bird near member name

                writer.Seek(nameStartShiftFlag, SeekOrigin.Begin);
                WriteH(writer, (short)writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, guildMember.Key.PlayerData.Name);

                writer.Seek(nameStartShiftFlag + 2, SeekOrigin.Begin);
                WriteH(writer, (short)writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, 0);

                if (Guild.GuildMembers.Count > ch + 1)
                {
                    writer.Seek(nameStartShiftFlag - 2, SeekOrigin.Begin);
                    WriteH(writer, (short)writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
                ch++;
            }
        }
    }
}