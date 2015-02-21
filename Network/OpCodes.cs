using System;
using System.Collections.Generic;
using System.Linq;

namespace Network
{
    public class OpCodes
    {
        public static Dictionary<ushort, String> Recv = new Dictionary<ushort, String>();
        public static Dictionary<ushort, String> Send = new Dictionary<ushort, String>();

        public static Dictionary<short, string> SendNames = new Dictionary<short, string>();

        public static int Version = 1725;

        public static void Init()
        {
            #region Client packets

            //From jenova by angelis86, should be 2405
            //https://code.google.com/p/tera-jenova/source/browse/trunk/src/TeraGame/src/main/java/com/angelis/tera/game/presentation/network/packet/ClientPacketHandler.java?r=61
            // AUTH
            Recv.Add((ushort)0x4DBC, "CM_CHECK_VERSION"); // OK
            Recv.Add((ushort)0xB114, "CM_ACCOUNT_AUTH"); // OK
            Recv.Add((ushort)0xA204, "CM_HARDWARE_INFO"); // OK

            // CHARACTER
            Recv.Add((ushort)0x96F1, "CM_CHARACTER_LIST"); // OK
            Recv.Add((ushort)0xFBC3, "CM_CHARACTER_CREATE_ALLOWED"); // OK
            Recv.Add((ushort)0x7F90, "CM_CHARACTER_CREATE_NAME_PATTERN_CHECK"); // OK
            Recv.Add((ushort)0xAE1B, "CM_CHARACTER_CREATE_NAME_USED_CHECK"); // OK
            Recv.Add((ushort)0xD932, "CM_CHARACTER_CREATE"); // OK
            Recv.Add((ushort)0xAD7C, "CM_CHARACTER_DELETE"); // OK
            Recv.Add((ushort)0xDA2D, "CM_CHARACTER_RESTORE"); // OK

            // ENTER WORLD
            Recv.Add((ushort)0xA5B7, "CM_ENTER_WORLD"); // OK
            Recv.Add((ushort)0xDE8B, "CM_TRADEBROKER_HIGHEST_ITEM_LEVEL"); // OK
            Recv.Add((ushort)0x910B, "CM_LOAD_TOPO_FIN"); // Not sure
            Recv.Add((ushort)0x96A5, "CM_UPDATE_CONTENTS_PLAYTIME");
            Recv.Add((ushort)0xB135, "CM_SIMPLE_TIP_REPEATED_CHECK"); // OK
            Recv.Add((ushort)0xD99E, "CM_PLAYER_CLIMB_START");
            Recv.Add((ushort)0x7957, "CM_USER_SETTINGS_SAVE");
            Recv.Add((ushort)0x74F3, "CM_MOVIE_END");

            // REQUEST
            Recv.Add((ushort)0xE952, "CM_REQUEST_CONTRACT"); // OK
            Recv.Add((ushort)0xD870, "CM_REQUEST_ANSWER"); // OK
            Recv.Add((ushort)0xC09A, "CM_REQUEST_GAMESTAT_PING");

            // MOUNT
            Recv.Add((ushort)0xB118, "CM_PLAYER_UNMOUNT");

            // OPTIONS
            Recv.Add((ushort)0xAD59, "CM_OPTION_SHOW_MASK");
            Recv.Add((ushort)0x6CCD, "CM_OPTION_SET_VISIBILITY_DISTANCE"); // OK

            // CHAT
            Recv.Add((ushort)0xA951, "CM_CHAT"); // OK
            Recv.Add((ushort)0x5F0E, "CM_CHAT_INFO"); // OK
            Recv.Add((ushort)0x5042, "CM_LOOKING_FOR_GROUP_CHAT_INFO"); // OK
            Recv.Add((ushort)0xECF7, "CM_WHISP"); // OK

            // DIALOG
            Recv.Add((ushort)0x94BE, "CM_NPC_CONTACT"); // OK
            Recv.Add((ushort)0x9A93, "CM_DIALOG_EVENT"); // OK
            Recv.Add((ushort)0xA308, "CM_DIALOG"); // OK

            // ALLIANCE
            Recv.Add((ushort)0x7E06, "CM_ALLIANCE_INFO"); // OK

            // GAMEOBJECT
            Recv.Add((ushort)0x89F9, "CM_GAMEOBJECT_REMOVE");

            // SKILL
            Recv.Add((ushort)0xF8DD, "CM_SKILL_START"); // OK
            Recv.Add((ushort)0x70AB, "CM_SKILL_INSTANCE_START"); // OK
            Recv.Add((ushort)0x76A8, "CM_SKILL_CANCEL");
            Recv.Add((ushort)0x738A, "CM_GLYPH_REINIT");

            // PLAYER
            Recv.Add((ushort)0x4E90, "CM_PLAYER_MOVE"); // OK
            Recv.Add((ushort)0x6797, "CM_PLAYER_ZONE_CHANGE"); // OK
            Recv.Add((ushort)0xC6D1, "CM_LOOKING_FOR_BATTLEGROUND_WINDOW_OPEN"); // OK
            Recv.Add((ushort)0xC590, "CM_LOOKING_FOR_INSTANCE_WINDOW_OPEN"); // OK
            Recv.Add((ushort)0xE8A2, "CM_PLAYER_REPORT"); // TODO
            Recv.Add((ushort)0x8DA7, "CM_PLAYER_COMPARE_ACHIEVEMENTS");
            Recv.Add((ushort)0xADCF, "CM_PLAYER_INSPECT"); // Not sure // TODO
            Recv.Add((ushort)0x9520, "CM_PLAYER_SELECT_CREATURE"); // OK
            Recv.Add((ushort)0xE195, "CM_PLAYER_DONJON_CLEAR_COUNT_LIST");

            // GATHER
            Recv.Add((ushort)0x885F, "CM_GATHER_START");

            // PROFIL
            Recv.Add((ushort)0x96A4, "CM_PLAYER_SET_TITLE");
            Recv.Add((ushort)0x7653, "CM_PLAYER_DESCRIPTION");
            Recv.Add((ushort)0x6DF5, "CM_PLAYER_REINIT_INSTANCES");
            Recv.Add((ushort)0xE9BC, "CM_PLAYER_DONJON_STATS_PVP"); // TODO

            // INVENTORY
            Recv.Add((ushort)0xF9FD, "CM_INVENTORY_SHOW"); // OK
            Recv.Add((ushort)0x7EEF, "CM_ITEM_MOVE"); // OK
            Recv.Add((ushort)0xB139, "CM_ITEM_USE"); // OK
            Recv.Add((ushort)0xD1F6, "CM_ITEM_SIMPLE_INFO");
            Recv.Add((ushort)0x83A1, "CM_INVENTORY_ORDER"); // OK
            Recv.Add((ushort)0xBE5B, "CM_ITEM_UNEQUIP"); // OK
            Recv.Add((ushort)0xF8D3, "CM_ITEM_EQUIP");
            Recv.Add((ushort)0xF772, "CM_PLAYER_EQUIPEMENT_ITEM_INFO"); // OK
            Recv.Add((ushort)0xACA1, "CM_PLAYER_DUNGEON_COOLTIME_LIST");
            Recv.Add((ushort)0xB106, "CM_PLAYER_ITEM_TRASH");
            Recv.Add((ushort)0x9DE4, "CM_PLAYER_DROP_ITEM_PICKUP"); // OK

            // EXCHANGE
            Recv.Add((ushort)0xFCEB, "CM_EXCHANGE_ITEM_ADD_BUY"); // OK
            Recv.Add((ushort)0xF1C5, "CM_EXCHANGE_ITEM_REMOVE_BUY");
            Recv.Add((ushort)0xF624, "CM_EXCHANGE_ITEM_ADD_SELL");
            Recv.Add((ushort)0xAE84, "CM_EXCHANGE_ITEM_REMOVE_SELL");
            Recv.Add((ushort)0xFBCD, "CM_EXCHANGE_COMPLETE");
            Recv.Add((ushort)0x8D7A, "CM_EXCHANGE_CANCEL");

            // MAP
            Recv.Add((ushort)0x8D02, "CM_MAP_SHOW"); // TODO

            // ACTIVITIES
            Recv.Add((ushort)0x88B2, "CM_PLAYER_EMOTE"); // OK
            Recv.Add((ushort)0x5761, "CM_ENCHANT_WINDOW_OPEN");
            Recv.Add((ushort)0xB5E3, "CM_INSTANCERANK_WINDOW_OPEN");
            Recv.Add((ushort)0x62EB, "CM_BATTLEGROUND_WINDOW_OPEN");

            // STOCK EXCHANGE ITEM
            Recv.Add((ushort)0xCE53, "CM_STOCK_EXCHANGE_ITEM_UNIQUE_LIST"); // OK
            Recv.Add((ushort)0xD7AD, "CM_STOCK_EXCHANGE_ITEM_UNIQUE_REQUEST"); // OK
            Recv.Add((ushort)0x70E7, "CM_STOCK_EXCHANGE_ITEM_ACCOUNT_LIST"); // OK
            Recv.Add((ushort)0x6913, "CM_STOCK_EXCHANGE_ITEM_ACCOUNT_REQUEST"); // OK
            Recv.Add((ushort)0xD960, "CM_STOCK_EXCHANGE_ITEM_INFO"); // OK
            Recv.Add((ushort)0x518F, "CM_STOCK_EXCHANGE_ITEM_UNK"); // OK

            // GUILD
            Recv.Add((ushort)0xCCE7, "CM_GUILD_MEMBER_LIST"); // OK
            Recv.Add((ushort)0xFF6A, "CM_GUILD_INFO"); // OK
            Recv.Add((ushort)0xBEB7, "CM_GUILD_APPLICATION"); // OK
            Recv.Add((ushort)0xD387, "CM_GUILD_VERSUS_STATUS"); // OK
            Recv.Add((ushort)0xC409, "CM_GUILD_LEAVE");
            Recv.Add((ushort)0xD2DE, "CM_GUILD_SERVER_LIST"); // OK
            Recv.Add((ushort)0xCF05, "CM_GUILD_LOGO"); // OK

            // SOCIAL
            Recv.Add((ushort)0x9577, "CM_PLAYER_FRIEND_LIST"); // OK
            Recv.Add((ushort)0xDA73, "CM_PLAYER_FRIEND_ADD"); // OK
            Recv.Add((ushort)0xDC58, "CM_PLAYER_FRIEND_REMOVE");
            Recv.Add((ushort)0x63AE, "CM_PLAYER_FRIEND_NOTE");
            Recv.Add((ushort)0xB1BA, "CM_PLAYER_BLOCK_ADD");
            Recv.Add((ushort)0x50A3, "CM_PLAYER_BLOCK_REMOVE");
            Recv.Add((ushort)0x63B0, "CM_PLAYER_BLOCK_NOTE");
            Recv.Add((ushort)0xE726, "CM_REIGN_INFO");
            Recv.Add((ushort)0x8D10, "CM_GUARD_PK_POLICY"); // OK

            // GROUP
            Recv.Add((ushort)0xBD26, "CM_GROUP_LEAVE");
            Recv.Add((ushort)0xFDFB, "CM_GROUP_KICK");
            Recv.Add((ushort)0xA5E6, "CM_GROUP_CONFIRM_KICK");
            Recv.Add((ushort)0xA995, "CM_GROUP_CONFIRM_LEADER_CHANGE"); // OK
            Recv.Add((ushort)0xA8BB, "CM_GROUP_DESTROY");

            Recv.Add((ushort)0x8D48, "CM_PLAYER_TRADE_HISTORY");

            // TERA SHOP
            Recv.Add((ushort)0xEEDF, "CM_SHOP_WINDOW_OPEN"); // OK

            // SYSTEM
            Recv.Add((ushort)0x74DF, "CM_WELCOME_MESSAGE"); // OK
            Recv.Add((ushort)0xCDBD, "CM_QUIT_TO_CHARACTER_LIST"); // OK
            Recv.Add((ushort)0xA765, "CM_QUIT_TO_CHARACTER_LIST_CANCEL"); // OK
            Recv.Add((ushort)0xD250, "CM_QUIT_GAME"); // OK
            Recv.Add((ushort)0xBEE0, "CM_QUIT_GAME_CANCEL"); // OK

            // PEGASUS
            Recv.Add((ushort)0x8122, "CM_PEGASUS_START"); // OK

            // CHANNEL
            Recv.Add((ushort)0xFB75, "CM_CHANNEL_LIST"); // OK

            #endregion

            #region Server packets

            //From jenova by angelis86, should be 2405
            //https://code.google.com/p/tera-jenova/source/browse/trunk/src/TeraGame/src/main/java/com/angelis/tera/game/presentation/network/packet/ServerPacketHandler.java?r=61

            // AUTH
            Send.Add((ushort)0x4DBD, "SM_CHECK_VERSION"); // OK
            Send.Add((ushort)0xDC28, "SM_LOADING_SCREEN_CONTROL_INFO"); // OK
            Send.Add((ushort)0x521E, "SM_REMAIN_PLAY_TIME"); // OK
            Send.Add((ushort)0xE9DE, "SM_LOGIN_ARBITER"); // OK
            Send.Add((ushort)0xACC6, "SM_LOGIN_ACCOUNT_INFO"); // OK
            Send.Add((ushort)0x8093, "SM_ACCOUNT_PACKAGE_LIST"); // OK
            Send.Add((ushort)0xC8A8, "SM_SYSTEM_INFO"); // OK

            // CHARACTER
            Send.Add((ushort)0x65C6, "SM_CHARACTER_LIST"); // OK
            Send.Add((ushort)0x6779, "SM_CHARACTER_CREATE_ALLOWED"); // OK
            Send.Add((ushort)0xB743, "SM_CHARACTER_CREATE_NAME_PATTERN_CHECK"); // OK
            Send.Add((ushort)0xB5C4, "SM_CHARACTER_CREATE_NAME_USED_CHECK"); // OK
            Send.Add((ushort)0x89C6, "SM_CHARACTER_CREATE"); // OK
            Send.Add((ushort)0xF9E8, "SM_CHARACTER_DELETE"); // OK
            Send.Add((ushort)0xCCE0, "SM_CHARACTER_RESTORE"); // OK

            // ENTER WORLD
            Send.Add((ushort)0x5CCF, "SM_ENTER_WORLD"); // OK
            Send.Add((ushort)0xD61A, "SM_LOGIN"); // OK
            Send.Add((ushort)0xDD66, "SM_CURRENT_ELECTION_STATE"); // OK
            Send.Add((ushort)0x9274, "SM_AVAILABLE_SOCIAL_LIST"); // OK
            Send.Add((ushort)0x969C, "SM_NPC_GUILD_LIST"); // OK
            Send.Add((ushort)0xA33A, "SM_VIRTUAL_LATENCY"); // OK
            Send.Add((ushort)0x539D, "SM_MOVE_DISTANCE_DELTA"); // OK
            Send.Add((ushort)0xAC2B, "SM_F2P_PREMIUM_USER_PERMISSION"); // OK
            Send.Add((ushort)0x86B7, "SM_PLAYER_EQUIP_ITEM_CHANGER"); // Not
            // sure
            Send.Add((ushort)0xD85D, "SM_FESTIVAL_LIST"); // OK
            Send.Add((ushort)0xF1AD, "SM_MASSTIGE_STATUS"); // OK
            Send.Add((ushort)0x792B, "SM_LOAD_TOPO"); // OK
            Send.Add((ushort)0xA953, "SM_LOAD_HINT"); // OK
            Send.Add((ushort)0xA2D8, "SM_SIMPLE_TIP_REPEATED_CHECK"); // OK
            Send.Add((ushort)0x8F16, "SM_USER_SETTINGS_LOAD"); // OK
            Send.Add((ushort)0xA7DE, "SM_MOVIE_PLAY");
            Send.Add((ushort)0x96BD, "SM_VISITED_SECTION_LIST");
            Send.Add((ushort)0x5EB0, "SM_TRADEBROKER_HIGHEST_ITEM_LEVEL"); // OK
            Send.Add((ushort)0x8A2B, "SM_ACHIEVEMENT_PROGRESS_UPDATE"); // OK

            // PEGASUS
            Send.Add((ushort)0xCAB4, "SM_PEGASUS_START"); // OK
            Send.Add((ushort)0xC0E7, "SM_PEGASUS_UPDATE"); // OK
            Send.Add((ushort)0xCA3E, "SM_PEGASUS_END"); // OK
            Send.Add((ushort)0xDB85, "SM_PEGASUS_MAP_SHOW"); // OK

            // MOUNT
            Send.Add((ushort)0xBF48, "SM_PLAYER_MOUNT"); // OK
            Send.Add((ushort)0xAEB8, "SM_PLAYER_UNMOUNT"); // OK

            // GUILD
            Send.Add((ushort)0xE489, "SM_GUILD_MEMBER_LIST"); // OK
            Send.Add((ushort)0xA942, "SM_GUILD_VERSUS_STATUS"); // OK
            Send.Add((ushort)0x5606, "SM_GUILD_SERVER_LIST"); // OK)

            // PET
            Send.Add((ushort)0xDD08, "SM_PET_INCUBATOR_INFO_CHANGE"); // OK
            Send.Add((ushort)0x8908, "SM_PET_INFO_CLEAR"); // OK

            // ALLIANCE
            Send.Add((ushort)0xEB1B, "SM_ALLIANCE_INFO"); // OK

            // ATTACK
            Send.Add((ushort)0xCF42, "SM_ACTION_STAGE"); // OK
            Send.Add((ushort)0xD2E1, "SM_ACTION_END"); // OK
            Send.Add((ushort)0xFF1F, "SM_CREATURE_INSTANCE_ARROW"); // OK
            Send.Add((ushort)0xA71F, "SM_PLAYER_EXPERIENCE_UPDATE"); // OK

            // OPTIONS
            Send.Add((ushort)0xB4C9, "SM_OPTION_SHOW_MASK");

            // SKILL
            Send.Add((ushort)0x80CE, "SM_SKILL_START_COOLTIME"); // OK
            Send.Add((ushort)0x0001, "SM_SKILL_PERIOD");
            Send.Add((ushort)0x9F0C, "SM_SKILL_RESULTS"); // OK
            Send.Add((ushort)0xDEC3, "SM_PLAYER_SKILL_LIST"); // OK

            // CHAT
            Send.Add((ushort)0xC4DE, "SM_CHAT"); // OK
            Send.Add((ushort)0x8CD3, "SM_CHAT_LOOKING_FOR_GROUP"); // OK
            Send.Add((ushort)0xA856, "SM_CHAT_LOOKING_FOR_GROUP_INFO"); // OK
            Send.Add((ushort)0x8A9F, "SM_CHAT_INFO"); // OK<
            Send.Add((ushort)0x9F6E, "SM_WHISP"); // OK

            // PLAYER
            Send.Add((ushort)0x7064, "SM_PLAYER_FRIEND_LIST"); // OK
            Send.Add((ushort)0x840C, "SM_OWN_PLAYER_SPAWN"); // OK
            Send.Add((ushort)0xCD87, "SM_PLAYER_STATS_UPDATE"); // OK
            Send.Add((ushort)0xE3F9, "SM_PLAYER_MOVE"); // OK
            Send.Add((ushort)0xD371, "SM_PLAYER_ZONE_CHANGE");
            Send.Add((ushort)0xB8C0, "SM_PLAYER_SELECT_CREATURE"); // OK
            Send.Add((ushort)0xBEFE, "SM_PLAYER_STATE"); // OK
            Send.Add((ushort)0xA3C0, "SM_RESPONSE_GAMESTAT_PONG");
            Send.Add((ushort)0x6022, "SM_PLAYER_DONJON_CLEAR_COUNT_LIST");
            Send.Add((ushort)0x5390, "SM_PLAYER_SPAWN"); // OK
            Send.Add((ushort)0x8668, "SM_PLAYER_DESPAWN"); // OK
            Send.Add((ushort)0xC7A3, "SM_PLAYER_CLIMB_START");
            Send.Add((ushort)0xDFDC, "SM_PLAYER_DESCRIPTION"); // OK
            Send.Add((ushort)0xF5B4, "SM_PLAYER_UNK1"); // OK
            Send.Add((ushort)0xF169, "SM_PLAYER_UNK2"); // OK
            Send.Add((ushort)0xA3C6, "SM_PLAYER_DEATH");
            Send.Add((ushort)0x8CB7, "SM_PLAYER_REVIVE");
            Send.Add((ushort)0x862C, "SM_PLAYER_DEATH_WINDOW");
            Send.Add((ushort)0xC99E, "SM_PLAYER_GATHER_STATS"); // OK

            // OBJECT
            Send.Add((ushort)0x5DB2, "SM_GAMEOBJECT_SPAWN");
            Send.Add((ushort)0xC7A2, "SM_GAMEOBJECT_DESPAWN");

            // CRAFT
            Send.Add((ushort)0x97F1, "SM_CRAFT_STATS"); // OK
            Send.Add((ushort)0xA3DF, "SM_CRAFT_RECIPE_LIST"); // OK

            // ABNORMALITY
            Send.Add((ushort)0xDFA9, "SM_ABNORMALITY_BEGIN"); // OK
            Send.Add((ushort)0x9E24, "SM_ABNORMALITY_END"); // OK

            // CREATURE
            Send.Add((ushort)0xBD20, "SM_CREATURE_HP_UPDATE");
            Send.Add((ushort)0xDD71, "SM_CREATURE_UNK"); // OK
            Send.Add((ushort)0xC8B0, "SM_CREATURE_MP_UPDATE");
            Send.Add((ushort)0x68C2, "SM_CREATURE_SPAWN"); // OK
            Send.Add((ushort)0xEA0B, "SM_CREATURE_DESPAWN"); // OK
            Send.Add((ushort)0xAA64, "SM_CREATURE_MOVE");
            Send.Add((ushort)0xEC17, "SM_CREATURE_ROTATE");
            Send.Add((ushort)0xC2EA, "SM_CREATURE_TARGET_PLAYER");
            Send.Add((ushort)0x95B4, "SM_CREATURE_SHOW_HP");

            // DROP
            Send.Add((ushort)0x95CC, "SM_DROP_ITEM_LOOT"); // OK
            Send.Add((ushort)0xD68B, "SM_DROP_ITEM_DESPAWN"); // OK
            Send.Add((ushort)0xEB8B, "SM_DROP_ITEM_SPAWN"); // OK

            // DIALOG
            Send.Add((ushort)0x5A8A, "SM_DIALOG"); // OK
            Send.Add((ushort)0xEFBC, "SM_DIALOG_CLOSE"); // OK
            Send.Add((ushort)0xFD90, "SM_DIALOG_EVENT"); // OK
            Send.Add((ushort)0x819E, "SM_DIALOG_MENU_SELECT"); // OK
            Send.Add((ushort)0x9E7A, "SM_DIALOG_TRADELIST_SHOW"); // OK

            // CAMPFIRE
            Send.Add((ushort)0xCCE4, "SM_CAMPFIRE_SPAWN");
            Send.Add((ushort)0xB5EF, "SM_CAMPFIRE_DESPAWN");

            // GROUP
            Send.Add((ushort)0xB848, "SM_GROUP_MEMBER_LIST"); // OK
            Send.Add((ushort)0xED19, "SM_GROUP_QUEST_SHARE"); // OK
            Send.Add((ushort)0xBB1C, "SM_GROUP_MEMBER_STATS"); // OK
            Send.Add((ushort)0xE82F, "SM_GROUP_ABNORMALS");
            Send.Add((ushort)0xB314, "SM_GROUP_UNK"); // OK
            Send.Add((ushort)0x4FD6, "SM_GROUP_MEMBER_HP_UPDATE"); // OK
            Send.Add((ushort)0x6DBE, "SM_GROUP_MEMBER_MP_UPDATE");
            Send.Add((ushort)0xEF84, "SM_GROUP_MEMBER_MOVE"); // OK
            Send.Add((ushort)0x8378, "SM_GROUP_LEAVE"); // OK
            Send.Add((ushort)0xCD5C, "SM_GROUP_LEADER_CHANGED"); // OK
            Send.Add((ushort)0xF1E5, "SM_GROUP_CONFIRM_KICK_WINDOW_SHOW");

            // PROFIL
            Send.Add((ushort)0xF8E2, "SM_PLAYER_SET_TITLE");
            Send.Add((ushort)0xB8C4, "SM_PLAYER_DONJON_STATS_PVP"); // TODO

            // QUEST
            Send.Add((ushort)0xE3AE, "SM_QUEST_CLEAR_INFO"); // OK
            Send.Add((ushort)0xCCA7, "SM_QUEST_INFO"); // OK
            Send.Add((ushort)0xC7D9, "SM_QUEST_DAILY_COMPLETE_COUNT"); // OK
            Send.Add((ushort)0x95BF, "SM_MISSION_COMPLETE_INFO"); // Not sure
            Send.Add((ushort)0xF929, "SM_QUEST_BALLOON");
            Send.Add((ushort)0x8F45, "SM_QUEST_VILLAGER_INFO");
            Send.Add((ushort)0xFB81, "SM_QUEST_WORLD_VILLAGER_INFO");
            Send.Add((ushort)0x5714, "SM_QUEST_WORLD_VILLAGER_INFO_CLEAR");
            Send.Add((ushort)0xB433, "SM_QUEST_UPDATE");

            // INVENTORY
            Send.Add((ushort)0x8034, "SM_INVENTORY"); // OK
            Send.Add((ushort)0xC6A9, "SM_ITEM_INFO"); // OK
            Send.Add((ushort)0xD3D7, "SM_ITEM_SIMPLE_INFO");
            Send.Add((ushort)0xE040, "SM_PLAYER_INVENTORY_SLOT_CHANGED"); // OK
            Send.Add((ushort)0x8890, "SM_PLAYER_APPEARANCE_CHANGE"); // OK
            Send.Add((ushort)0x5601, "SM_ITEM_START_COOLTIME");
            Send.Add((ushort)0xE62F, "SM_EXCHANGE_WINDOW_UPDATE");

            // STOCK EXCHANGE ITEM
            Send.Add((ushort)0xACBE, "SM_STOCK_EXCHANGE_ITEM_HINT"); // OK

            Send.Add((ushort)0xB28D, "SM_STOCK_EXCHANGE_ITEM_UNIQUE_LIST"); // OK
            Send.Add((ushort)0xF3A8, "SM_STOCK_EXCHANGE_ITEM_UNIQUE_ADD"); // OK

            Send.Add((ushort)0xFD9D, "SM_STOCK_EXCHANGE_ITEM_ACCOUNT_LIST"); // OK
            Send.Add((ushort)0xBD6E, "SM_STOCK_EXCHANGE_ITEM_ACCOUNT_ADD"); // OK
            Send.Add((ushort)0x6B70, "SM_STOCK_EXCHANGE_ITEM_INFO"); // OK
            Send.Add((ushort)0xDC8F, "SM_STOCK_EXCHANGE_ITEM_UNK"); // OK

            // TRADE
            Send.Add((ushort)0xCCD6, "SM_TRADE_WINDOW_SHOW");

            // MAP
            Send.Add((ushort)0x9860, "SM_MAP"); // TODO

            // SOCIAL
            Send.Add((ushort)0x6B3F, "SM_SOCIAL"); // OK
            Send.Add((ushort)0xC18B, "SM_PLAYER_FRIEND_LIST");
            Send.Add((ushort)0x9547, "SM_PLAYER_FRIEND_ADD_SUCCESS");
            Send.Add((ushort)0x9946, "SM_PLAYER_FRIEND_REMOVE_SUCCESS");
            Send.Add((ushort)0xC156, "SM_REIGN_INFO");
            Send.Add((ushort)0x6425, "SM_GUARD_PK_POLICY"); // OK

            // SHOP
            Send.Add((ushort)0xE6AF, "SM_SHOP_WINDOW_OPEN"); // TODO

            // SYSTEM
            Send.Add((ushort)0xDD29, "SM_SYSTEM_MESSAGE"); // OK
            Send.Add((ushort)0xAB23, "SM_WELCOME_MESSAGE"); // OK
            Send.Add((ushort)0xC54E, "SM_QUIT_TO_CHARACTER_LIST_WINDOW"); // OK
            Send.Add((ushort)0xF348, "SM_QUIT_TO_CHARACTER_LIST_CANCEL"); // OK
            Send.Add((ushort)0x8BA9, "SM_QUIT_TO_CHARACTER_LIST"); // OK
            Send.Add((ushort)0xB5E4, "SM_QUIT_GAME_WINDOW"); // OK
            Send.Add((ushort)0xDD59, "SM_QUIT_GAME_CANCEL"); // OK
            Send.Add((ushort)0xA594, "SM_QUIT_GAME"); // OK

            // REQUEST
            Send.Add((ushort)0xAF1A, "SM_REQUEST_CONTRACT"); // OK
            Send.Add((ushort)0xAF0C, "SM_REQUEST_CONTRACT_REPLY"); // OK
            Send.Add((ushort)0xA249, "SM_REQUEST_CONTRACT_CANCEL");
            Send.Add((ushort)0xBA1A, "SM_REQUEST_COMPLETE"); // OK
            Send.Add((ushort)0xCECD, "SM_REQUEST_WINDOW_SHOW"); // OK
            Send.Add((ushort)0x55B9, "SM_REQUEST_WINDOW_HIDE");

            // CHANNEL
            Send.Add((ushort)0xF32B, "SM_PLAYER_ENTER_CHANNEL"); // TODO
            Send.Add((ushort)0x907B, "SM_PLAYER_CHANNEL_INFO"); // OK
            Send.Add((ushort)0xF419, "SM_PLAYER_CHANNEL_LIST"); // OK

            // GATHER
            Send.Add((ushort)0xC775, "SM_GATHER_START"); // OK
            Send.Add((ushort)0x949B, "SM_GATHER_PROGRESS"); // OK
            Send.Add((ushort)0xD0F5, "SM_GATHER_END"); // OK
            Send.Add((ushort)0xDB23, "SM_GATHER_SPAWN"); // OK
            Send.Add((ushort)0xC86C, "SM_GATHER_DESPAWN"); // OK
            Send.Add((ushort)0x6AB5, "SM_GATHERCRAFT_POINT"); // OK

            // UNK
            Send.Add((ushort)0x670A, "SM_PLAYER_UNK"); // OK


            #endregion

            //SendNames = Send.ToDictionary(p => p.Value, p => p.Key.Name);
        }
    }
}