using System.Collections.Generic;
using Data.Interfaces;
using Data.Structures.Guild;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IGuildService : IComponent
    {
        void Init();

        void AddNewGuild(List<Player> players, string guildName);
        void AddMemberToGuild(Player player, Guild guild, Player inviter = null);
        void AddHistoryEvent(Guild guild, HistoryEvent hEvent, Player initiator = null);
        void CreateNewRank(Guild guild, string rankName);
        void ChangeMemberRank(Player initiator, int playerid, int newRank);
        void KickMember(Player initiator, string playerName);
        void LeaveGuild(Player player, Guild guild);
        void ChangeRankPrivileges(Player initiator, int rankId, int newPrivileges, string newName);
        void ChangeGuildLeader(Player initiator, string playerName);
        void ChangeGuildIcon(Player initiator, Guild guild, byte[] newIcon);
        void DisbandGuild(Player initiator, Guild guild);
        void UpdateGuild(Guild guild);
        void ChangeAd(Player player, string newAd);
        void ChangeMotd(Player player, string newMotd);
        void ChangeTitle(Player player, string newTitle);
        void OnPlayerEnterWorld(Player player);

        void SendGuildToPlayer(Player player);
        void SendGuildHistory(Player player);
        void SendPacketToGuildMembers(ISendPacket packet, Guild guild, Player sender = null);
        void SendServerGuilds(Player player, int tabId);

        void HandleChatMessage(Player sender, string message);

        Player GetLeader(Guild guild);
        GuildMemberRank GetPlayerRank(Player player);

        void PraiseGuild(string name);

        bool CanUseName(string name);
    }
}
