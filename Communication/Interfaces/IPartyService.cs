using System.Collections.Generic;
using Data.Interfaces;
using Data.Structures.Player;
using Data.Structures.World.Party;

namespace Communication.Interfaces
{
    public interface IPartyService : IComponent
    {
        void AddNewParty(Player inviter, Player invited);
        void AddNewParty(Player inviter, List<Player> invitedPlayers);
        void AddPlayerToParty(Player invited, ref Party party);
        bool CanPlayerJoinParty(Player player, Party party, bool sendErrors = true);
        void KickPlayerFromParty(Player initiator, int playerId);
        void LeaveParty(Player player);
        void RemoveParty(ref Party party);
        void PromotePlayer(Player promoter, int promotedId);
        void SendPacketToPartyMembers(Party party, ISendPacket packet, Player sender = null);
        void SendLifestatsToPartyMembers(Party party);
        void UpdateParty(Party party);
        void SendEffectsToPartyMembers(Party party);
        void SendMemberPositionToPartyMembers(Player player);
        void AddExp(Player player, long exp);
        void ReleaseExp(Player player);

        List<Player> GetOnlineMembers(Party party);

        void HandleChatMessage(Player player, string message);
    }
}
