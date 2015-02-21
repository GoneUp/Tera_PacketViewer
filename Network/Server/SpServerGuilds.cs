using System.Collections.Generic;
using System.IO;
using Data.Structures.Guild;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpServerGuilds : ASendPacket
    {
        protected List<Guild> Guilds;
        protected int TabId;
        protected int TotalGuilds;
        protected int TabsCounter;
        //protected Dictionary<int, List<Guild>> Guilds;
        public SpServerGuilds(List<Guild> guilds, int tabId, int totalGuilds, int tabsCounter)
        {
            Guilds = guilds;
            TabId = tabId;
            TotalGuilds = totalGuilds;
            TabsCounter = tabsCounter;
        }
        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0x11);
            WriteH(writer, 0); //First shift
            WriteD(writer, TabId);
            WriteD(writer, TabsCounter);
            WriteD(writer, TotalGuilds);
            WriteD(writer, 1);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            for (int i = 0; i < Guilds.Count; i++)
            {
                Guild g = Guilds[i];

                short shift = (short) writer.BaseStream.Length;

                WriteH(writer, shift); //Now shift
                WriteH(writer, 0); //Next shift

                int namesShift = (int) writer.BaseStream.Position;
                WriteH(writer, 0); //Fuild Name shift
                WriteH(writer, 0); //Guildmaster name shift
                WriteH(writer, 0); //??? shift
                WriteH(writer, 0); //Guild ad shift
                WriteH(writer, 0); //Logo shift

                WriteD(writer, g.Level); //Guild Level
                WriteD(writer, g.CreationDate); //A913E4F //Founded time
                WriteD(writer, 0); //???
                WriteD(writer, g.GuildMembers.Count); //Members
                WriteD(writer, 0); //Connect rate
                WriteD(writer, g.Praises); //Total prise
                WriteC(writer, 0); //Can apply to guild

                writer.Seek(namesShift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, g.GuildName); //Name

                writer.Seek(namesShift + 2, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                Player leader = Communication.Global.GuildService.GetLeader(g);
                WriteS(writer, leader != null ? leader.PlayerData.Name : "No leader"); //Owner

                writer.Seek(namesShift + 4, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, "Owners"); //???

                writer.Seek(namesShift + 6, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, g.GuildAd);

                writer.Seek(namesShift + 8, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, "");
                //WriteS(writer, "guildlogo_11_45_1"); //Logo

                if (Guilds.Count > i + 1)
                {
                    writer.Seek(shift + 2, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
            }
        }
    }
}