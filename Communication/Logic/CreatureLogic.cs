using Data.Enums;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Objects;
using Data.Structures.Player;

namespace Communication.Logic
{
    public class CreatureLogic : Global
    {
        public static CreatureBaseStats InitGameStats(Creature creature)
        {
            return StatsService.InitStats(creature);
        }

        public static void UpdateCreatureStats(Creature creature)
        {
            StatsService.UpdateStats(creature);

            Player player = creature as Player;
            if (player != null)
                FeedbackService.StatsUpdated(player);
        }

        public static void HpChanged(Creature creature, int diff, Creature attacker = null)
        {
            if (creature is Player)
            {
                FeedbackService.HpChanged(creature as Player, diff, attacker);
                PartyService.SendLifestatsToPartyMembers(((Player)creature).Party);
            }

            ObserverService.NotifyHpChanged(creature);
        }

        public static void MpChanged(Creature creature, int diff, Creature attacker = null)
        {
            ObserverService.NotifyMpChanged(creature);

            if (creature is Player)
            {
                FeedbackService.MpChanged(creature as Player, diff, attacker);
                PartyService.SendLifestatsToPartyMembers(((Player)creature).Party);
            }
        }

        public static void StaminaChanged(Player player, int diff)
        {
            FeedbackService.StaminaChanged(player, diff);
            UpdateCreatureStats(player);
        }

        public static void NpcDied(Npc npc)
        {
            var player = npc.Ai.GetKiller() as Player;

            if (player != null)
            {
                if (player.Party != null)
                    foreach (Player member in PartyService.GetOnlineMembers(player.Party))
                        QuestEngine.OnPlayerKillNpc(member, npc);
                else
                    QuestEngine.OnPlayerKillNpc(player, npc);

                player.Instance.OnNpcKill(player, npc);
            }

            if (npc.NpcTemplate.Size != NpcSize.Small)
                npc.Ai.DealExp();

            if (player != null)
            {
                MapService.CreateDrop(npc, player);
            }
        }

        public static void CreateProjectile(Creature creature, Projectile projectile)
        {
            AiLogic.InitAi(projectile);
            MapService.SpawnTeraObject(projectile, creature.Instance);
        }

        public static void ReleaseProjectile(Projectile projectile)
        {
            MapService.DespawnTeraObject(projectile);
            projectile.Release();
        }
    }
}
