using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Enums;
using Data.Enums.Player;
using Data.Interfaces;
using Data.Structures;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.SkillEngine;
using Data.Structures.World;

namespace Communication.Logic
{
    public class PlayerLogic : Global
    {
        public static void PlayerSelected(IConnection connection, int playerId, bool isProlog)
        {
            connection.Player = connection.Account.Players.FirstOrDefault(player => player.PlayerId == playerId);

            if(connection.Player == null)
                return;

            connection.Player.Connection = connection;

            PlayerService.InitPlayer(connection.Player, isProlog);
            FeedbackService.SendInitialData(connection);
        }

        public static void PlayerEnterWorld(Player player)
        {
            MapService.PlayerEnterWorld(player);
            PlayerService.PlayerEnterWorld(player);
            ControllerService.PlayerEnterWorld(player);
            FeedbackService.OnPlayerEnterWorld(player.Connection, player);

            PartyService.UpdateParty(player.Party);
            GuildService.OnPlayerEnterWorld(player);

            DuelService.PlayerLeaveWorld(player);
        }

        public static void PlayerEndGame(Player player)
        {
            if (player == null) return;

            PlayerService.PlayerEndGame(player);
            MapService.PlayerLeaveWorld(player);
            ControllerService.PlayerEndGame(player);

            PartyService.UpdateParty(player.Party);

            DuelService.PlayerLeaveWorld(player);
        }

        public static void CheckName(IConnection connection, string name, short type)
        {
            CheckNameResult result = PlayerService.CheckName(name, type);
            FeedbackService.SendCheckNameResult(connection, name, type, result);
        }

        public static void CheckNameForUse(IConnection connection, string name, short type)
        {
            bool result = PlayerService.CheckNameForUse(name, type);
            FeedbackService.SendCheckNameForUseResult(connection, name, type, result);
        }

        public static void CreateCharacter(IConnection connection, PlayerData playerData)
        {
            if (connection.Account.Players.Count >= 6
                || PlayerService.CheckName(playerData.Name, 1) != CheckNameResult.Ok
                || !PlayerService.CheckNameForUse(playerData.Name, 1))
            {
                FeedbackService.SendCreateCharacterResult(connection, false);
                return;
            }

            Player player = PlayerService.CreateCharacter(connection, playerData);
            StorageService.AddStartItemsToPlayer(player);

            FeedbackService.SendCreateCharacterResult(connection, true);

            Cache.UsedNames.Add(playerData.Name.ToLower());
        }

        public static void SendBindPoint(IConnection connection)
        {
            FeedbackService.SendBindPoint(connection);
        }

        public static void InTheVision(Player player, Creature creature)
        {
            FeedbackService.SendCreatureInfo(player.Connection, creature);

            Npc npc = creature as Npc;
            if (npc != null)
                QuestEngine.ShowIcon(player, npc);
        }

        public static void DistanceToCreatureRecalculated(Player player, Creature creature, double distance)
        {
            player.Ai.DistanceToCreatureRecalculated(creature, distance);
        }

        public static void OutOfVision(Player player, Creature creature)
        {
            ObserverService.RemoveObserved(player, creature);
            FeedbackService.SendRemoveCreature(player.Connection, creature);
        }

        public static void PlayerMoved(Player player, float x1, float y1, float z1, short heading, float x2, float y2, float z2, PlayerMoveType moveType, short unk2, short unk3)
        {
            //if (unk1 == 6) //Stop
                //GeoService.FixOffset(player.Position.MapId, x1, y1, z1);

            PlayerService.PlayerMoved(player, x1, y1, z1, heading, x2, y2, z2, moveType, unk2, unk3);
            FeedbackService.PlayerMoved(player, x1, y1, z1, heading, x2, y2, z2, moveType, unk2, unk3);

            PartyService.SendMemberPositionToPartyMembers(player);
        }

        public static void ProcessChatMessage(IConnection connection, string message, ChatType type)
        {
            if (AdminEngine.ProcessChatMessage(connection, message))
                return;

            ChatService.ProcessMessage(connection, message, type);
        }

        public static void UseSkill(IConnection connection, UseSkillArgs args)
        {
            SkillEngine.UseSkill(connection, args);
        }

        public static void UseSkill(IConnection connection, List<UseSkillArgs> argsList)
        {
            SkillEngine.UseSkill(connection, argsList);
        }

        public static void MarkTarget(IConnection connection, Creature target, int skillId)
        {
            SkillEngine.MarkTarget(connection, target, skillId);
        }

        public static void ReleaseAttack(IConnection connection, int attackUid, int type)
        {
            SkillEngine.ReleaseAttack(connection.Player, attackUid, type);
        }

        public static void SendPlayerThings(Player player)
        {
            FeedbackService.SendPlayerThings(player);
        }

        public static void ShowDialog(Player player, TeraObject o)
        {
            PlayerService.StartDialog(player, o);
        }

        public static void ProgressDialog(Player player, int selectedIndex, int dialogUid)
        {
            PlayerService.ProgressDialog(player, selectedIndex, dialogUid);
        }

        public static void PlayerEnterZone(Player player, byte[] zoneDatas)
        {
            PlayerService.PlayerEnterZone(player, zoneDatas);
            QuestEngine.OnPlayerEnterZone(player, AreaService.GetCurrentSection(player));
        }

        public static void LevelUp(Player player)
        {
            FeedbackService.PlayerLevelUp(player);
            StatsService.UpdateStats(player);
            QuestEngine.PlayerLevelUp(player);
        }

        public static void PickUpItem(IConnection connection, Item item)
        {
            if (connection.Player == null)
                return;

            MapService.PickUpItem(connection.Player, item);
        }

        public static void BuySkill(Player player, int skillId, bool isActive)
        {
            if (player == null)
                return;

            SkillsLearnService.BuySkill(player, skillId, isActive);
        }

        public static void SkillPurchased(Player player, UserSkill skill)
        {
            FeedbackService.SkillPurchased(player, skill);
            QuestEngine.OnPlayerLearnSkill(player);
        }

        public static void PleyerDied(Player player)
        {
            CreatureLogic.UpdateCreatureStats(player);
            FeedbackService.PlayerDied(player);
        }

        public static void Ressurect(Player player, int type, int unk)
        {
            ControllerService.TrySetDefaultController(player);
            if (player.ClosestBindPoint == null)
                TeleportService.ForceTeleport(player, TeleportService.GetBindPoint(player));
            else
                TeleportService.ForceTeleport(player, player.ClosestBindPoint);
        }

        public static void Unstuck(IConnection connection)
        {
            if (connection.Player == null)
                return;

            PlayerService.UnstuckPlayer(connection.Player);
        }

        public static void SwitchContinent(Player player, int continentId)
        {
            TeleportService.SwitchContinent(player, continentId);
        }
    }
}