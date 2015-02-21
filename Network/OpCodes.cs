using System;
using System.Collections.Generic;
using System.Linq;
using Network.Client;
using Network.Server;

namespace Network
{
    public class OpCodes
    {
        public static Dictionary<short, Type> Recv = new Dictionary<short, Type>();
        public static Dictionary<Type, short> Send = new Dictionary<Type, short>();

        public static Dictionary<short, string> SendNames = new Dictionary<short, string>();

        public static int Version = 1725;

        public static void Init()
        {
            #region Client packets

            // ReSharper disable RedundantCast
            Recv.Add(unchecked((short) 0x4DBC), typeof (RpCheckVersion)); //all revs
            Recv.Add(unchecked((short) 0xC644), typeof (RpAuth)); //1725 EU
            Recv.Add(unchecked((short) 0x6CE4), typeof (RpSystemInfo)); //1725 EU
            Recv.Add(unchecked((short) 0x8844), typeof (RpCheckName)); //1725 EU
            Recv.Add(unchecked((short) 0x7B3D), typeof (RpCheckNameForUse)); //1725 EU
            Recv.Add(unchecked((short) 0xE5E4), typeof (RpGetPlayerList)); //1725 EU
            Recv.Add(unchecked((short) 0x6755), typeof (RpCreateCharacter)); //1725 EU
            Recv.Add(unchecked((short) 0x8D6A), typeof (RpPlay)); //1725 EU
            Recv.Add(unchecked((short) 0xB61D), typeof (RpGetBindPoint)); //1725 EU
            Recv.Add(unchecked((short) 0xBCC4), typeof (RpEnterWorld)); //1725 EU
            Recv.Add(unchecked((short) 0xFBE6), typeof (RpChatMessage)); //1725 EU
            Recv.Add(unchecked((short) 0xE932), typeof (RpChatInfo)); //1725 EU
            Recv.Add(unchecked((short) 0xFA08), typeof (RpMove)); //1725 EU
            Recv.Add(unchecked((short) 0x837D), typeof (RpInactive)); //1725 EU
            Recv.Add(unchecked((short) 0xADF4), typeof (RpRelog)); //1725 EU
            Recv.Add(unchecked((short) 0x99EB), typeof (RpAbortRelog)); //1725 EU
            Recv.Add(unchecked((short) 0xF19F), typeof (RpExit)); //1725 EU
            Recv.Add(unchecked((short) 0x878D), typeof (RpDialogShow)); //1725 EU
            Recv.Add(unchecked((short) 0x4EE4), typeof (RpItemPickUp)); //1725 EU
            Recv.Add(unchecked((short) 0xBD08), typeof (RpGetInventory)); //1725 EU
            Recv.Add(unchecked((short) 0xA02D), typeof (RpInventoryRemoveItem)); //1725 EU
            Recv.Add(unchecked((short) 0xFEAD), typeof (RpInventoryReplaceItem)); //1725 EU
            Recv.Add(unchecked((short) 0x63D8), typeof (RpInventoryDressItem)); //1725 EU
            Recv.Add(unchecked((short) 0xB77E), typeof (RpInventoryUndressItem)); //1725 EU
            Recv.Add(unchecked((short) 0xC4BA), typeof (RpStorageSort)); //1725 EU
            Recv.Add(unchecked((short) 0xBED7), typeof (RpDialogSelect)); //1725 EU
            Recv.Add(unchecked((short) 0xBC40), typeof (RpDeleteCharacter)); //1725 EU
            Recv.Add(unchecked((short) 0xA7B1), typeof (RpGetItemInfo)); //1725 EU
            Recv.Add(unchecked((short) 0xB14B), typeof (RpGetSimpleItemInfo)); //1725 EU
            Recv.Add(unchecked((short) 0xC5C6), typeof (RpGetFriendList)); //1603 EU
            Recv.Add(unchecked((short) 0xE020), typeof (RpMoveToBind)); //1603 EU
            //Recv.Add(unchecked((short) 0xE806), typeof (RpGetCharacterEquipment)); //1513
            Recv.Add(unchecked((short) 0xC233), typeof (RpCharacterSettings1)); //1725 EU
            Recv.Add(unchecked((short) 0xA7A5), typeof (RpQuestTopSwitch)); //1603 EU
            Recv.Add(unchecked((short)0xFC7C), typeof(RpQuestRefuse)); //1603 EU
            Recv.Add(unchecked((short)0xAF84), typeof(RpTeleportCharacter)); //1725 EU
            Recv.Add(unchecked((short) 0xED71), typeof (RpAddToTrade)); // 1725 EU
            Recv.Add(unchecked((short) 0x7DD5), typeof (RpAddToExtract)); // 1725 EU
            Recv.Add(unchecked((short) 0xB73C), typeof (RpSellItem)); //1725 EU
            Recv.Add(unchecked((short) 0xF204), typeof (RpRemoveBuyTrade)); //1725 EU
            Recv.Add(unchecked((short) 0xC327), typeof (RpRemoveSellTrade)); //1725 EU
            Recv.Add(unchecked((short) 0x7219), typeof (RpCompleteTraid)); //1725 EU
            Recv.Add(unchecked((short) 0x5879), typeof (RpOwnerCancelRequest)); //1725 EU
            Recv.Add(unchecked((short) 0x5B72), typeof (RpRequestAccept)); // 1725 EU
            Recv.Add(unchecked((short) 0xB32B), typeof (RpRequestCancel)); // 1725 EU
            Recv.Add(unchecked((short) 0xF9A9), typeof (RpSystemRequest)); //1725 EU
            Recv.Add(unchecked((short) 0x6621), typeof (RpSkillBuy)); //1725 EU
            //Recv.Add(unchecked((short) 0x6A09), typeof (RpInviteUnk)); //1606
            Recv.Add(unchecked((short) 0xB2AA), typeof (RpDialogCancelRelog)); //1603 EU
            Recv.Add(unchecked((short) 0x819B), typeof (RpCharacterEmotion)); //1725 EU
            Recv.Add(unchecked((short) 0xA8FA), typeof (RpChatPrivate)); //1725 EU
            Recv.Add(unchecked((short) 0xAF9D), typeof (RpChatBlock)); //1603 EU
            Recv.Add(unchecked((short) 0x8875), typeof (RpGatherStart)); //1725 EU
            Recv.Add(unchecked((short) 0xB351), typeof (RpFriendAdd)); //1603 EU
            Recv.Add(unchecked((short) 0xD500), typeof (RpFriendRemove)); //1603 EU
            Recv.Add(unchecked((short) 0xFC9B), typeof (RpInteruptAction)); //1725 EU
            Recv.Add(unchecked((short) 0xD2E0), typeof (RpRessurect)); //1725 EU
            Recv.Add(unchecked((short) 0x86E2), typeof (RpUnstuck)); //1725 EU

            //Inspect
            Recv.Add(unchecked((short)0xC036), typeof(RpCharacterInspect)); //1725 EU
            Recv.Add(unchecked((short)0x7A8D), typeof(RpGetInspectUid)); //1725 EU
            Recv.Add(unchecked((short)0x91D7), typeof(RpInspectUnk)); //1725 EU

            //Climb
            Recv.Add(unchecked((short) 0xE364), typeof (RpClimb)); //1725 EU
            Recv.Add(unchecked((short) 0x89A4), typeof (RpClimbUp)); //1725 EU
            Recv.Add(unchecked((short) 0xF3CD), typeof (RpClimbEnd)); //1725 EU

            //Skills
            Recv.Add(unchecked((short) 0xBDEE), typeof (RpAttack)); //1725 EU
            Recv.Add(unchecked((short) 0x68CA), typeof (RpTargetAttack)); //1725 EU
            Recv.Add(unchecked((short) 0x8691), typeof (RpUseDelaySkill)); //1725 EU
            Recv.Add(unchecked((short) 0xC8B3), typeof (RpUseSkill)); //1725 EU //Move skills
            Recv.Add(unchecked((short) 0xF34A), typeof (RpUseCrosstargetSkill)); //1725 EU
            Recv.Add(unchecked((short) 0x7E21), typeof (RpUseItem)); // 1725 EU
            Recv.Add(unchecked((short) 0xB16A), typeof (RpMarkTarget)); //1725 EU
            Recv.Add(unchecked((short) 0x77BB), typeof (RpReleaseAttack)); //1725 EU

            //Party
            Recv.Add(unchecked((short)0x86BD), typeof(RpPartyLeave)); //1725 EU
            Recv.Add(unchecked((short) 0x4F34), typeof (RpPartyDisband)); //1603 EU
            Recv.Add(unchecked((short)0xF86C), typeof(RpPartyRemoveMember)); //1725 EU
            Recv.Add(unchecked((short)0x82AE), typeof(RpPartyVote)); //1603 EU
            Recv.Add(unchecked((short)0xBA24), typeof(RpPartyPromoteMember)); //1725 EU

            //Guilds
            Recv.Add(unchecked((short)0x8781), typeof(RpGetServerGuilds)); //1603 EU
            Recv.Add(unchecked((short) 0xDB99), typeof (RpRequestInviteProcess)); //1725 EU
            //Recv.Add(unchecked((short) 0xA7A6), typeof (RpGuildAddMemberRequest)); //1606
            Recv.Add(unchecked((short) 0xEFE0), typeof (RpGuildGetMemberList)); //1725 EU
            //Recv.Add(unchecked((short) 0x6A2B), typeof (RpGuildInvite)); //1606
            Recv.Add(unchecked((short) 0xFF67), typeof (RpGuildGetHistory)); //1725 EU
            Recv.Add(unchecked((short) 0xDD03), typeof (RpGuildRemoveMember)); //1725 EU
            Recv.Add(unchecked((short)0x7029), typeof(RpGuildChangeRankPrivileges)); //1725 EU
            Recv.Add(unchecked((short)0x8A75), typeof(RpGuildRankAdd)); //1725 EU
            Recv.Add(unchecked((short)0x901F), typeof(RpGuildChangeMemberRank)); //1725 EU
            Recv.Add(unchecked((short)0xAEA2), typeof(RpGuildChangeLeader)); //1725 EU
            Recv.Add(unchecked((short)0x968D), typeof(RpGuildMemberLeave)); //1725 EU
            Recv.Add(unchecked((short)0x9DE5), typeof(RpServerGuildsPage)); //1725 EU
            Recv.Add(unchecked((short)0xF494), typeof(RpGuildChangeAd)); //1725 EU
            Recv.Add(unchecked((short)0x9D87), typeof(RpGuildChangeMotd)); //1725 EU
            Recv.Add(unchecked((short)0xBFC1), typeof(RpGuildChangeTitle)); //1725 EU
            Recv.Add(unchecked((short)0xD23D), typeof(RpGuildPraise)); //1725 EU
            Recv.Add(unchecked((short)0xF22B), typeof(RpGuildMemberGuildPraise)); //1725 EU


            //Trade player vs player
            Recv.Add(unchecked((short) 0x6EDF), typeof (RpPlayerTradeAdd)); //1725 EU
            Recv.Add(unchecked((short)0x6AAE), typeof(RpPlayerTradeRemoveItem)); //1725 EU
            Recv.Add(unchecked((short)0x79BA), typeof(RpPlayerTradeLock)); //1725 EU
            Recv.Add(unchecked((short) 0xD457), typeof (RpTradeInterupt)); //1603 EU
            Recv.Add(unchecked((short)0xE3C1), typeof(RpPlayerTradeCancel)); //1725 EU

            //Craft-Extract
            Recv.Add(unchecked((short) 0xC1E3), typeof (RpCraftStart)); //1725 EU
            Recv.Add(unchecked((short) 0x8B9C), typeof (RpExtractStart)); //1725 EU

            //Zone
            Recv.Add(unchecked((short) 0xAB32), typeof (RpZoneChange)); //1725 EU
            Recv.Add(unchecked((short) 0x4F4F), typeof (RpZoneUnk)); //1725 EU
            Recv.Add(unchecked((short) 0xD03F), typeof (RpZoneSwitchContinent)); //1725 EU

            //Warehouse
            Recv.Add(unchecked((short)0xE0D4), typeof(RpWarehouseAddItem)); //1725 EU
            Recv.Add(unchecked((short)0xD7B5), typeof(RpWarehouseAddItemToInventory)); //1725 EU
            Recv.Add(unchecked((short)0xF085), typeof(RpWarehouseChangeSection)); //1725 EU
            Recv.Add(unchecked((short)0xCCEC), typeof(RpWarehouseReplaceItem)); //1725 EU

            //mount
            Recv.Add(unchecked((short)0x4F59), typeof(RpMountUnkQuestion)); //1725 EU

            //User interface
            Recv.Add(unchecked((short)0x7D1B), typeof(RpUISettings));

            #endregion

            #region Server packets

            Send.Add(typeof (SpCheckVersion), unchecked((short) 0x4DBD)); //1725 EU

            //Characters
            Send.Add(typeof (SpCharacterCheckNameResult), unchecked((short) 0xE315)); //1725 EU
            Send.Add(typeof (SpCharacterCreateResult), unchecked((short) 0xC075)); //1725 EU
            Send.Add(typeof (SpCharacterList), unchecked((short) 0xB38E)); //1725 EU
            Send.Add(typeof (SpCharacterInit), unchecked((short) 0xBD48)); //1725 EU
            Send.Add(typeof (SpCharacterStats), unchecked((short) 0xF0EB)); //1725 EU 
            Send.Add(typeof (SpCharacterInfo), unchecked((short) 0xDE1C)); //1725 EU
            Send.Add(typeof (SpCharacterBind), unchecked((short) 0x9487)); //1725 EU
            Send.Add(typeof (SpCharacterPosition), unchecked((short) 0xD146)); //1725 EU
            Send.Add(typeof (SpCharacterThings), unchecked((short) 0xECF0)); //1725 EU
            Send.Add(typeof (SpCharacterEmotions), unchecked((short) 0xE0A0)); //1725 EU
            Send.Add(typeof (SpCharacterState), unchecked((short) 0xEBCD)); //1725 EU
            Send.Add(typeof (SpCharacterDelete), unchecked((short) 0xEFE4)); //1725 EU
            Send.Add(typeof (SpCharacterDeath), unchecked((short) 0x63E7)); //1725 EU
            Send.Add(typeof (SpCharacterMove), unchecked((short) 0xEBE2)); //1725 EU
            Send.Add(typeof (SpCharacterGatherstats), unchecked((short) 0x928F)); //1725 EU
            Send.Add(typeof (SpCharacterGuildInfo), unchecked((short) 0x581E)); //1725 EU
            Send.Add(typeof (SpCharacterRelation), unchecked((short) 0x866A)); //1725 EU
            Send.Add(typeof (SpRemoveCharacter), unchecked((short) 0x6256)); //1725 EU
            Send.Add(typeof (SpCharacterCraftStats), unchecked((short) 0xA046)); //1725 EU
            Send.Add(typeof (SpCharacterRecipes), unchecked((short) 0xCF01)); //1725 EU
            Send.Add(typeof (SpCharacterZoneData), unchecked((short) 0xE7C9)); //1725 EU

            //Chat
            Send.Add(typeof (SpChatMessage), unchecked((short) 0x5703)); //1725 EU
            Send.Add(typeof (SpChatPrivate), unchecked((short) 0xA082)); //1725 EU
            Send.Add(typeof (SpChatInfo), unchecked((short) 0xE321)); //1725 EU

            //Skills
            Send.Add(typeof (SpSkillList), unchecked((short) 0xC1D9)); //1725 EU
            Send.Add(typeof (SpAttack), unchecked((short) 0x69A2)); //1725 EU
            Send.Add(typeof (SpAttackDestination), unchecked((short) 0x56D8)); //1725 EU
            Send.Add(typeof (SpAttackShowBlock), unchecked((short) 0xD0C3)); //1725 EU
            Send.Add(typeof (SpAttackResult), unchecked((short) 0x9D8F)); //1725 EU
            Send.Add(typeof (SpAttackEnd), unchecked((short) 0xBF7C)); //1725 EU
            Send.Add(typeof (SpSkillCooldown), unchecked((short) 0xA848)); //1725 EU
            Send.Add(typeof (SpProjectile), unchecked((short) 0x7D90)); //1725 EU
            Send.Add(typeof (SpRemoveProjectile), unchecked((short) 0x7CD2)); //1725 EU
            Send.Add(typeof (SpItemCooldown), unchecked((short) 0xDDE0)); //1725 EU
            Send.Add(typeof (SpMarkTarget), unchecked((short) 0x8625)); //1725 EU

            //Npc
            Send.Add(typeof (SpNpcInfo), unchecked((short) 0x8AB2)); //1725 EU
            Send.Add(typeof (SpRemoveNpc), unchecked((short) 0x73B1)); //1725 EU
            Send.Add(typeof (SpNpcEmotion), unchecked((short) 0xC7DB)); //1725 EU
            Send.Add(typeof (SpNpcStatus), unchecked((short) 0x68B1)); //1725 EU
            Send.Add(typeof (SpNpcMove), unchecked((short) 0x580E)); //1725 EU
            Send.Add(typeof (SpNpcHpMp), unchecked((short) 0xFB12)); //1725 EU
            Send.Add(typeof (SpNpcHpWindow), unchecked((short) 0xC0B2)); //1725 EU
            Send.Add(typeof (SpNpcIcon), unchecked((short) 0xBF6B)); //1725 EU
            Send.Add(typeof (SpNpcTalk), unchecked((short) 0xD465)); //1603 EU

            //Exit actions
            Send.Add(typeof (SpRelogWindow), unchecked((short) 0xBFFE)); //1725 EU
            Send.Add(typeof (SpExitWindow), unchecked((short) 0xE6D6)); //1725 EU
            Send.Add(typeof (SpRelog), unchecked((short) 0x87C8)); //1725 EU
            Send.Add(typeof (SpExit), unchecked((short) 0xAE39)); //1725 EU

            Send.Add(typeof (SpShowDialog), unchecked((short) 0xD13D)); //1725 EU
            Send.Add(typeof (SpShowWindow), unchecked((short) 0xB797)); //1725 EU
            Send.Add(typeof (SpDropInfo), unchecked((short) 0xE764)); //1725 EU
            Send.Add(typeof (SpShowIcon), unchecked((short) 0x9C9C)); //1725 EU
            Send.Add(typeof (SpRemoveItem), unchecked((short) 0xDDBB)); //1725 EU
            Send.Add(typeof (SpInventory), unchecked((short) 0x92C0)); //1725 EU
            Send.Add(typeof (SpLevelUp), unchecked((short) 0x66A5)); //1725 EU
            Send.Add(typeof (SpUpdateExp), unchecked((short) 0x8FC7)); //1725 EU
            Send.Add(typeof (SpDeathDialog), unchecked((short) 0x5FCE)); //1725 EU
            //Send.Add(typeof (SpCharacterBuffs), unchecked((short) 0xCA86)); //1512
            Send.Add(typeof (SpAbnormal), unchecked((short) 0xC50E)); //1725 EU
            Send.Add(typeof (SpRemoveAbnormal), unchecked((short) 0xE3F4)); //1725 EU
            //Send.Add(typeof (SpHelp), unchecked((short) 0xB330)); //1512
            Send.Add(typeof (SpTradeList), unchecked((short) 0xC849)); //1725 EU
            Send.Add(typeof (SpUpdateTrade), unchecked((short) 0x733D)); //1725 EU
            Send.Add(typeof (SpDropPickup), unchecked((short) 0xAE81)); //1725 EU
            Send.Add(typeof (SpUpdateHp), unchecked((short) 0xD6BE)); //1725 EU
            Send.Add(typeof (SpUpdateMp), unchecked((short) 0xB5DF)); //1725 EU
            Send.Add(typeof (SpUpdateStamina), unchecked((short) 0x5CC4)); //1725 EU
            Send.Add(typeof (SpSystemMessage), unchecked((short) 0xF8D3)); //1725 EU
            Send.Add(typeof (SpDirectionChange), unchecked((short) 0x996F)); //1725 EU
            Send.Add(typeof (SpCampfire), unchecked((short) 0xB0BE)); //1725 EU
            Send.Add(typeof (SpRemoveCampfire), unchecked((short) 0xCB92)); //1725 EU
            Send.Add(typeof(SpRemoveHpBar), unchecked((short)0xD7EE)); //1725 EU

            Send.Add(typeof (SpDuelCounter), unchecked((short) 0xC93C)); //1725 EU

            Send.Add(typeof (SpSkillPurchased), unchecked((short) 0x6235)); //1725 EU
            Send.Add(typeof (SpTraidSkillList), unchecked((short) 0xA774)); //1725 EU
            Send.Add(typeof (SpSystemWindow), unchecked((short) 0xF05B)); //1725 EU
            Send.Add(typeof (SpCanSendRequest), unchecked((short) 0x554E)); //1725 EU ???
            Send.Add(typeof (SpHideRequest), unchecked((short)0xD627)); //1603 EU
            Send.Add(typeof (SpSystemNotice), unchecked((short) 0x5F11)); //1725 EU
            Send.Add(typeof (SpItemInfo), unchecked((short) 0x8E8C)); //1725 EU
            Send.Add(typeof (SpSimpleItemInfo), unchecked((short) 0xB359)); //1725 EU
            Send.Add(typeof (SpCreatureMoveTo), unchecked((short) 0xB983)); //1725 EU

            //Climb
            Send.Add(typeof (SpClimb), unchecked((short) 0xD9A1)); //1725 EU

            //Pegasus
            Send.Add(typeof (SpFlightPoints), unchecked((short) 0xDFDD)); //1725 EU
            Send.Add(typeof (SpPegasusInfo), unchecked((short) 0x953D)); //1725 EU
            Send.Add(typeof (SpPegasusFlight), unchecked((short) 0xC2E6)); //1725 EU
            Send.Add(typeof (SpPegasusFinishFly), unchecked((short) 0x98FD)); //1725 EU

            //Mounts
            Send.Add(typeof (SpMountShow), unchecked((short) 0x888D)); //1725 EU
            Send.Add(typeof (SpMountHide), unchecked((short) 0x888C)); //1725 EU
            Send.Add(typeof(SpMountUnkResponse), unchecked((short)0xC82A)); //1725 EU

            // Inspect
            Send.Add(typeof(SpCharacterInspect), unchecked((short)0xE153)); //1725 EU
            Send.Add(typeof(SpInspectUid), unchecked((short)0x59A9)); //1725 EU
            Send.Add(typeof(SpInspectUnk), unchecked((short)0x77C3)); //1725 EU

            //Quests
            Send.Add(typeof (SpQuest), unchecked((short) 0xE80F)); //1725 EU
            Send.Add(typeof (SpComplitedQuests), unchecked((short) 0xB791)); //1725 EU
            Send.Add(typeof (SpQuestComplite), unchecked((short) 0xA94D)); //1725 EU
            Send.Add(typeof (SpQuestMovie), unchecked((short) 0xFA43)); //1725 EU

            //Party
            Send.Add(typeof (SpPartyList), unchecked((short) 0xBD9C)); //1725 EU
            Send.Add(typeof(SpPartyRemoveMember), unchecked((short)0xE230)); //1725 EU
            Send.Add(typeof (SpPartyStats), unchecked((short) 0xA908)); //1725 EU
            Send.Add(typeof(SpPartyLeave), unchecked((short)0xC5A1)); //1725 EU
            Send.Add(typeof (SpPartyVote), unchecked((short) 0xF5B5)); //1603 EU
            Send.Add(typeof(SpPartyAbnormals), unchecked((short)0xD7EB)); //1725 EU
            Send.Add(typeof(SpPartyMemberPosition), unchecked((short)0xACC1)); //1725 EU

            //Guilds
            Send.Add(typeof(SpServerGuilds), unchecked((short)0x6B0A)); //1725 EU
            Send.Add(typeof (SpRequestInvite), unchecked((short) 0x7EA4)); //1725 EU
            Send.Add(typeof (SpGuildMemberList), unchecked((short) 0x90E0)); //1725 EU
            Send.Add(typeof (SpGuildRanking), unchecked((short) 0x80BC)); //1725 EU
            Send.Add(typeof (SpGuildHistory), unchecked((short) 0xA04E)); //1725 EU

            //Friends
            Send.Add(typeof (SpFriendAdd), unchecked((short) 0x5B48)); //1603 EU
            Send.Add(typeof (SpFriendList), unchecked((short) 0x820A)); //1603 EU
            Send.Add(typeof (SpFriendUpdate), unchecked((short) 0xACAC)); //1603 EU

            //Gathering
            Send.Add(typeof (SpGatherInfo), unchecked((short) 0x7102)); //1725 EU
            Send.Add(typeof (SpRemoveGather), unchecked((short) 0xB372)); //1725 EU
            Send.Add(typeof (SpGatherStart), unchecked((short) 0x61EA)); //1725 EU
            Send.Add(typeof (SpGatherProgress), unchecked((short) 0xC666)); //1725 EU
            Send.Add(typeof (SpGatherEnd), unchecked((short) 0xA769)); //1725 EU
            Send.Add(typeof (SpUpdateGather), unchecked((short) 0x67AE)); //1603 EU

            //Trade
            Send.Add(typeof (SpTradeWindow), unchecked((short) 0xDD9A)); //1725 EU
            Send.Add(typeof(SpPlayerTradeHistory), unchecked((short)0xDF5C)); //1725 EU
            Send.Add(typeof(SpTradeHideWindow), unchecked((short)0x8895)); //1725 EU

            //Craft/Extract
            Send.Add(typeof (SpCraftUpdateWindow), unchecked((short) 0xE876)); //1725 EU
            Send.Add(typeof (SpExtractProgressbar), unchecked((short) 0xF1E2)); //1725 EU
            Send.Add(typeof (SpCraftWindow), unchecked((short) 0x53C7)); //1725 EU
            Send.Add(typeof (SpCraftInitBar), unchecked((short) 0x648C)); //1725 EU
            Send.Add(typeof (SpCraftProgress), unchecked((short) 0xB8FC)); //1725 EU

            //Warehouse
            Send.Add(typeof(SpWarehouseItems), unchecked((short)0x6505)); //1725 EU

            //Zone
            Send.Add(typeof (SpZoneUnkAnswer), unchecked((short) 0x9F91)); //1725 EU
            Send.Add(typeof (SpZoneUnkAnswer2), unchecked((short) 0xB0A1)); //1725 EU

            //UI Settings
            Send.Add(typeof(SpUISettings), unchecked((short)0xE265));

            //AF6B 16000400000000

            // party kick vote
            // party buffs 9E8A04001000010050004F3800001000200034ADE605A05C0800020000002000300008ACE605B0A1030001000000300040006CACE60570AB11000100000040000000D0ACE60578B6080001000000500000007CC400000000000001
            // medal *Party maker*       1055010008000800000007000000EAAA404F00000000
            // medal *Expedition relief* 10550100080008000000890000003C68404F00000000
            // message *party has disbanned* 15D5060040003100390033000000

            Send.Add(typeof (SpForFun), unchecked((short) 0x7777)); //...
            // ReSharper restore RedundantCast

            #endregion

            SendNames = Send.ToDictionary(p => p.Value, p => p.Key.Name);
        }
    }
}