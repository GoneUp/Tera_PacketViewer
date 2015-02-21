using Network.Server;
using Utils;

namespace Network.Client
{
    public class RpGuildMemberGuildPraise : ARecvPacket
    {
        protected string GuildName;

        public override void Read()
        {
            ReadH();
            GuildName = ReadS();
        }

        public override void Process()
        {
            if (GuildName == "")
                return;

            if (Connection.Player.LastPraise != -1 && Funcs.GetRoundedUtc() - Connection.Player.LastPraise > 86400)
            {
                Connection.Player.LastPraise = -1;
                Connection.Player.PraiseGiven = 0;
            }


            if (Connection.Player.PraiseGiven >= 3)
            {
                new SpSystemNotice("Sorry, but you've exceeded the limit of 3 praises per day.").Send(Connection);
                return;
            }

            Connection.Player.PraiseGiven++;
            Connection.Player.LastPraise = Funcs.GetRoundedUtc();

            Communication.Global.GuildService.PraiseGuild(GuildName);
            Communication.Global.GuildService.SendServerGuilds(Connection.Player, 1);
            SystemMessages.YouPraiseGuildNowYouHavePraisesLeft(GuildName, 3 - Connection.Player.PraiseGiven).Send(Connection.Player);
        }
    }
}
