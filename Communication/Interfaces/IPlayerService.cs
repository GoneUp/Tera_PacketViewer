using System.Collections.Generic;
using Data.Enums;
using Data.Enums.Player;
using Data.Interfaces;
using Data.Structures;
using Data.Structures.Npc;
using Data.Structures.Player;

namespace Communication.Interfaces
{
    public interface IPlayerService : IComponent
    {
        List<Player> GetOnline();
        void Send(ISendPacket packet);
        void InitPlayer(Player player, bool isProlog);
        void PlayerEnterWorld(Player player);
        void PlayerEndGame(Player player);
        CheckNameResult CheckName(string name, short type);
        bool CheckNameForUse(string name, short type);
        Player CreateCharacter(IConnection connection, PlayerData playerData);
        void PlayerMoved(Player player, float x1, float y1, float z1, short heading, float x2, float y2, float z2, PlayerMoveType moveType, short unk2, short unk3);
        void StartDialog(Player player, TeraObject o);
        void ProgressDialog(Player player, int selectedIndex, int dialogUid);
        void PlayerEnterZone(Player player, byte[] zoneData);
        void AddItemsToNpcSell(Player player, int itemId, int itemCounter, int slot);
        void AddItemsToNpcBuy(Player player, int itemId, int itemCounter);
        void RemoveBuyItemsFromNpcTrade(Player player, int itemId, int itemCount, int dialogUid);
        void RemoveSellItemsFromNpcTrade(Player player, int itemId, int itemCount, int dialogUid);
        void CompleteNpcTraid(Player player, int dialogUid);
        void InterruptNpcTraid(Player player);
        void AddExp(Player player, long add, Npc npc);
        void SetExp(Player player, long add, Npc npc);
        Player GetPlayerByName(string playerName);
        void StartGather(Player player, long uid);
        bool IsPlayerOnline(Player player);
        void UnstuckPlayer(Player player);
    }
}