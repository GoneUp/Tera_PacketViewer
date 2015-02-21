using Data.Enums;
using Data.Enums.Player;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Communication.Interfaces
{
    public interface IFeedbackService : IComponent
    {
        void ShowShutdownTicks();
        void OnCheckVersion(IConnection connection, int version);
        void OnAuthorized(IConnection connection);
        void SendPlayerList(IConnection connection);
        void SendCheckNameResult(IConnection connection, string name, short type, CheckNameResult result);
        void SendCheckNameForUseResult(IConnection connection, string name, short type, bool result);
        void SendCreateCharacterResult(IConnection connection, bool result);
        void SendInitialData(IConnection connection);
        void SendBindPoint(IConnection connection);
        void OnPlayerEnterWorld(IConnection connection, Player player);
        void SendCreatureInfo(IConnection connection, Creature creature);
        void SendRemoveCreature(IConnection connection, Creature creature);
        void ShowRelogWindow(IConnection connection, int timeout);
        void Relog(IConnection connection);
        void ShowExitWindow(IConnection connection, int timeout);
        void Exit(IConnection connection);
        void AttackStageEnd(Creature creature);
        void AttackFinished(Creature creature);
        void SendPlayerThings(Player player);
        void HpChanged(Player player, int diff, Creature attacker);
        void MpChanged(Player player, int diff, Creature attacker);
        void StaminaChanged(Player player, int diff);
        void ExpChanged(Player player, long added);
        void StatsUpdated(Player player);
        void PlayerMoved(Player player, float x1, float y1, float z1, short heading, float x2, float y2, float z2, PlayerMoveType moveType, short unk2, short unk3);
        void PlayerLevelUp(Player player);
        void SendCharRemove(IConnection player);
        void SendLearSkillsDialog(Player player);
        void SkillPurchased(Player player, UserSkill skill);
        void PlayerDied(Player player);
    }
}