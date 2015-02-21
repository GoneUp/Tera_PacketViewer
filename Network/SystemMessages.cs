using Network.Server;

namespace Network
{
    public class SystemMessages
    {
        public static SpSystemMessage NoTerrainFoundPleaseTeleportAnotherArea = new SpSystemMessage(new[] {"@18"});

        public static SpSystemMessage YouCantTeleportRightNow = new SpSystemMessage(new[] {"@19"});

        public static SpSystemMessage YouCannotChangeChannelsDuringCombat = new SpSystemMessage(new[] {"@20"});

        public static SpSystemMessage YouCantDoThatRightNow = new SpSystemMessage(new[] {"@21"});

        public static SpSystemMessage YouGainedExpBonusExpExperience(string exp, string bonusExp)
        {
            return new SpSystemMessage(new[] {"@22", "exp", exp, "bonusExp", bonusExp});
        }

        public static SpSystemMessage SmtBattleHuntingzoneAchieve = new SpSystemMessage(new[] {"@23"});

        public static SpSystemMessage CongratulationsYouAreNowLevel(string level)
        {
            return new SpSystemMessage(new[] {"@24", "level", level});
        }

        public static SpSystemMessage YoureNotInPositionToClimbThat = new SpSystemMessage(new[] {"@25"});

        public static SpSystemMessage YouCantRessurectNow = new SpSystemMessage(new[] {"@26"});

        public static SpSystemMessage ThatItemIsUnavailableToYourRace = new SpSystemMessage(new[] {"@27"});

        public static SpSystemMessage ThatItemIsUnavailableToYourClass = new SpSystemMessage(new[] {"@28"});

        public static SpSystemMessage YouMustBeAHigherLevelToUseThat = new SpSystemMessage(new[] {"@29"});

        public static SpSystemMessage YouAreOutOfThatItem = new SpSystemMessage(new[] {"@30"});

        public static SpSystemMessage YouNeedALinkedCharacterToUseThat = new SpSystemMessage(new[] {"@31"});

        public static SpSystemMessage YouHaveAlreadyMasteredThatSkill = new SpSystemMessage(new[] {"@32"});

        public static SpSystemMessage YouCantLearnAnyMorePassiveSkills = new SpSystemMessage(new[] {"@33"});

        /* MORE??? */

        public static SpSystemMessage YouCannotUseThatSkillAtTheMoment = new SpSystemMessage(new[] {"@36"});

        public static SpSystemMessage NotEnoughMp = new SpSystemMessage(new[] {"@37"});

        public static SpSystemMessage ThatSkillRequiresAnEquippedWeapon = new SpSystemMessage(new[] {"@38"});

        public static SpSystemMessage InventoryIsFull = new SpSystemMessage(new[] {"@39"});

        public static SpSystemMessage YouDontHaveRoomForThatItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@40", "ItemName", itemName});
        }

        public static SpSystemMessage ThatIsntYours = new SpSystemMessage(new[] {"@41"});

        public static SpSystemMessage SmtLootItemBusy = new SpSystemMessage(new[] {"@42"});

        public static SpSystemMessage YouCantEquipOrRemoveItemsRightNow = new SpSystemMessage(new[] {"@43"});

        public static SpSystemMessage YouCantRefineRightNow = new SpSystemMessage(new[] {"@44"});

        /* MORE??? */

        public static SpSystemMessage YouAreNowAllowedMoreItems = new SpSystemMessage(new[] {"@46"});

        public static SpSystemMessage ThatItemIsNotEquppable = new SpSystemMessage(new[] {"@47"});

        public static SpSystemMessage NothingToRemove = new SpSystemMessage(new[] {"@48"});

        public static SpSystemMessage YouCantAttachThisCrystalToYourCurrentlyEquippedGear =
            new SpSystemMessage(new[] {"@49"});

        public static SpSystemMessage YouAlreadyHaveACrystalOfThatTypeEquipped = new SpSystemMessage(new[] {"@50"});

        public static SpSystemMessage AllCrystalSlotsAreFull = new SpSystemMessage(new[] {"@51"});

        public static SpSystemMessage NotAnEnchancementCrystal = new SpSystemMessage(new[] {"@52"});

        public static SpSystemMessage ThatItemCantBeStoredInTheBank = new SpSystemMessage(new[] {"@53"});

        public static SpSystemMessage YouCantPutThatItemInYourInventory = new SpSystemMessage(new[] {"@54"});

        /* MORE??? */

        public static SpSystemMessage YouDontHaveEnoughGold = new SpSystemMessage(new[] {"@59"});

        public static SpSystemMessage YouCantCarryAnyMoreGold = new SpSystemMessage(new[] {"@60"});

        public static SpSystemMessage AnotherPlayerIsAlreadyGatheringThat = new SpSystemMessage(new[] {"@61"});

        public static SpSystemMessage YouCantDoThatRightNowTryAgainInAMoment = new SpSystemMessage(new[] {"@62"});

        public static SpSystemMessage GatheringSuccesful = new SpSystemMessage(new[] {"@63"});

        public static SpSystemMessage GatheringFailed = new SpSystemMessage(new[] {"@64"});

        public static SpSystemMessage GatheringInterrupted = new SpSystemMessage(new[] {"@65"});

        public static SpSystemMessage GatheringCanceled = new SpSystemMessage(new[] {"@66"});

        public static SpSystemMessage YourMiningHasIncreasedToProf(string prof)
        {
            return new SpSystemMessage(new[] {"@67", "prof", prof});
        }

        public static SpSystemMessage YourPlantCollectingIncreasedToProf(string prof)
        {
            return new SpSystemMessage(new[] {"@68", "prof", prof});
        }

        public static SpSystemMessage YourBugHuntingIncreasedToProf(string prof)
        {
            return new SpSystemMessage(new[] {"@69", "prof", prof});
        }

        public static SpSystemMessage YourEssenceGatheringIncreasedToProf(string prof)
        {
            return new SpSystemMessage(new[] {"@70", "prof", prof});
        }

        public static SpSystemMessage SmtColCannotPickNow = new SpSystemMessage(new[] {"@71"});

        public static SpSystemMessage YourPetIsAlreadyOut = new SpSystemMessage(new[] {"@72"});

        public static SpSystemMessage YourPetIsNotOut = new SpSystemMessage(new[] {"@73"});

        public static SpSystemMessage YouCantBringOutAPetHere = new SpSystemMessage(new[] {"@74"});

        public static SpSystemMessage YouHaveAPetOut = new SpSystemMessage(new[] {"@75"});

        public static SpSystemMessage YouCantPutAwayYourPetWhileItsHoldingItems = new SpSystemMessage(new[] {"@76"});

        public static SpSystemMessage ThatFunctionIsntCurrentlyAvailable = new SpSystemMessage(new[] {"@77"});

        public static SpSystemMessage YouCanOnlyImprintAPet = new SpSystemMessage(new[] {"@78"});

        public static SpSystemMessage YouveAlreadyEquippedAPet = new SpSystemMessage(new[] {"@79"});

        public static SpSystemMessage YourPetIsInADifferentWorld = new SpSystemMessage(new[] {"@80"});

        public static SpSystemMessage YouCantUseThatFunction = new SpSystemMessage(new[] {"@81"});

        public static SpSystemMessage YoureTooLowLevelToUseThatFunction = new SpSystemMessage(new[] {"@82"});

        public static SpSystemMessage YourPetCantDoThatWithoutRepairs = new SpSystemMessage(new[] {"@83"});

        public static SpSystemMessage YourPetHasBeenDestroyed = new SpSystemMessage(new[] {"@84"});

        public static SpSystemMessage YourPetWasAttackedByAttackerAndFuncsWereShutDown(string attacker)
        {
            return new SpSystemMessage(new[] {"@85", "attacker", attacker});
        }

        public static SpSystemMessage AttackerDestroyedYourPet(string attacker)
        {
            return new SpSystemMessage(new[] {"@86", "attacker", attacker});
        }

        public static SpSystemMessage AttackerIsAttackingYourPet(string attacker)
        {
            return new SpSystemMessage(new[] {"@87", "attacker", attacker});
        }

        public static SpSystemMessage YoureTooFarAwayToUseYourPetsFuncs = new SpSystemMessage(new[] {"@88"});

        public static SpSystemMessage SmtPetOrmDestroyted = new SpSystemMessage(new[] {"@89"});

        public static SpSystemMessage YourPetNeedsToBeRepaired = new SpSystemMessage(new[] {"@90"});

        public static SpSystemMessage ThatIsNotPetTraining = new SpSystemMessage(new[] {"@91"});

        public static SpSystemMessage YouMustShutDownYourStoreToDoThat = new SpSystemMessage(new[] {"@92"});

        public static SpSystemMessage TheresNoRoomForThatFunction = new SpSystemMessage(new[] {"@93"});

        public static SpSystemMessage TheresNoFunctionToRemove = new SpSystemMessage(new[] {"@94"});

        public static SpSystemMessage AMorePowerfulFunctionIsAlreadyAttached = new SpSystemMessage(new[] {"@95"});

        public static SpSystemMessage ThatFunctionIsForAHigherRarityPet = new SpSystemMessage(new[] {"@96"});

        public static SpSystemMessage YouCantDoThatWileAnEggIsIncubating = new SpSystemMessage(new[] {"@97"});

        public static SpSystemMessage YouCanOnlyDoThatWhenYourPetHasHatched = new SpSystemMessage(new[] {"@98"});

        public static SpSystemMessage ThatsNotAPetEgg = new SpSystemMessage(new[] {"@99"});

        public static SpSystemMessage TheresNoRoomForThatEgg = new SpSystemMessage(new[] {"@100"});

        public static SpSystemMessage YouCantIncubateYet = new SpSystemMessage(new[] {"@101"});

        public static SpSystemMessage YouNeedTheIncubationSkill = new SpSystemMessage(new[] {"@102"});

        public static SpSystemMessage YourPetIsFullyRepaired = new SpSystemMessage(new[] {"@103"});

        /* MORE??? */

        public static SpSystemMessage InvalidTarget = new SpSystemMessage(new[] {"@111"});

        public static SpSystemMessage YoureNotInAParty = new SpSystemMessage(new[] {"@112"});

        public static SpSystemMessage ThatCharacterIsntOnline = new SpSystemMessage(new[] {"@113"});

        public static SpSystemMessage PlayerHasChallengedYouToPvP(string player)
        {
            return new SpSystemMessage(new[] {"@114", "player", player});
        }

        public static SpSystemMessage YouHaveChallegedPlayerToPvP(string player)
        {
            return new SpSystemMessage(new[] {"@115", "player", player});
        }

        public static SpSystemMessage DeclarerHasDeclaredPvPOnTarget(string declarer, string target)
        {
            return new SpSystemMessage(new[] {"@116", "declarer", declarer, "target", target});
        }

        public static SpSystemMessage PvPHasBegun = new SpSystemMessage(new[] {"@117"});

        public static SpSystemMessage PvPHasEnded = new SpSystemMessage(new[] {"@118"});

        public static SpSystemMessage YouKilledPlayer(string player)
        {
            return new SpSystemMessage(new[] {"@119", "player", player});
        }

        public static SpSystemMessage PlayerKilledYou(string player)
        {
            return new SpSystemMessage(new[] {"@120", "player", player});
        }

        public static SpSystemMessage TargetDefeatedByDeclarer(string target, string declarer)
        {
            return new SpSystemMessage(new[] {"@121", "target", target, "declarer", declarer});
        }

        /* MORE??? */

        public static SpSystemMessage YouCantChallengeThatTargetToPvP = new SpSystemMessage(new[] {"@124"});

        public static SpSystemMessage ThatCharacterIsAlreadyEngagedInPvP = new SpSystemMessage(new[] {"@125"});

        public static SpSystemMessage YouDontHaveEnoughGold126 = new SpSystemMessage(new[] {"@126"});

        public static SpSystemMessage TooFarAway = new SpSystemMessage(new[] {"@127"});

        public static SpSystemMessage YouCantGoWhileYoureInPvP = new SpSystemMessage(new[] {"@128"});

        public static SpSystemMessage PvPBeginsInCountsecSeconds(string countsec)
        {
            return new SpSystemMessage(new[] {"@129", "countsec", countsec});
        }

        public static SpSystemMessage YouCantPvPHere = new SpSystemMessage(new[] {"@130"});

        public static SpSystemMessage YouCantPvPWhileDead = new SpSystemMessage(new[] {"@131"});

        public static SpSystemMessage YouCantDoThatRightNow132 = new SpSystemMessage(new[] {"@132"});

        public static SpSystemMessage YoureAlreadyInABattleGroup = new SpSystemMessage(new[] {"@133"});

        public static SpSystemMessage YoureNotInABattleGroup = new SpSystemMessage(new[] {"@134"});

        public static SpSystemMessage BattlegroundIsClosing = new SpSystemMessage(new[] {"@135"});

        public static SpSystemMessage OnlyGuildMembersAreAllowedToJoinBattleGroups = new SpSystemMessage(new[] {"@136"});

        public static SpSystemMessage InvalidRequest = new SpSystemMessage(new[] {"@137"});

        public static SpSystemMessage TheVattleGroupIsFull = new SpSystemMessage(new[] {"@138"});

        public static SpSystemMessage ThatBattleGroupDoesntExist = new SpSystemMessage(new[] {"@139"});

        public static SpSystemMessage TheBattleGroupWasDisbaned = new SpSystemMessage(new[] {"@140"});

        public static SpSystemMessage NotEnoughMembersInTheVattleGroup = new SpSystemMessage(new[] {"@141"});

        public static SpSystemMessage TharesANewLegateInCharge = new SpSystemMessage(new[] {"@142"});

        public static SpSystemMessage TheBattleGroupIsQueuedToEnterTheBattleground = new SpSystemMessage(new[] {"@143"});

        public static SpSystemMessage PlayerIsAttackingStronghold(string player, string stronghold)
        {
            return new SpSystemMessage(new[] {"@144", "player", player, "stronghold", stronghold});
        }

        public static SpSystemMessage PlayerHasSeizedStronghold(string player, string stronghold)
        {
            return new SpSystemMessage(new[] {"@145", "player", player, "stronghold", stronghold});
        }

        public static SpSystemMessage PlayerIsDefendingStronghold(string player, string stronghold)
        {
            return new SpSystemMessage(new[] {"@146", "player", player, "stronghold", stronghold});
        }

        public static SpSystemMessage GuildHasSeizedStronghold(string guild, string stronghold)
        {
            return new SpSystemMessage(new[] {"@147", "guild", guild, "stronghold", stronghold});
        }

        public static SpSystemMessage PossessionOfStrongholdGoesToGuild(string stronghold, string guild)
        {
            return new SpSystemMessage(new[] {"@148", "stronghold", stronghold, "guild", guild});
        }

        public static SpSystemMessage VictoryYourTeamHasWonTheBattleground = new SpSystemMessage(new[] {"@149"});

        public static SpSystemMessage DesertersCantJoinABattleGroup = new SpSystemMessage(new[] {"@150"});

        public static SpSystemMessage PlayerJoinedTheTeam(string player)
        {
            return new SpSystemMessage(new[] {"@151", "player", player});
        }

        public static SpSystemMessage PlayerLeftTheTeam(string player)
        {
            return new SpSystemMessage(new[] {"@152", "player", player});
        }

        public static SpSystemMessage TheBattleBeginsInSecSeconds(string sec)
        {
            return new SpSystemMessage(new[] {"@153", "sec", sec});
        }

        /* MORE??? */

        public static SpSystemMessage TheBaseIsUnderAttack = new SpSystemMessage(new[] {"@155"});

        public static SpSystemMessage TheBaseIsSecure = new SpSystemMessage(new[] {"@156"});

        public static SpSystemMessage BattleHasBegun = new SpSystemMessage(new[] {"@157"});

        public static SpSystemMessage BattleHasEndedLeavingBattlegroundIn2Minutes = new SpSystemMessage(new[] {"@158"});

        /* MORE??? */

        public static SpSystemMessage UserCallsForBackup(string userName)
        {
            return new SpSystemMessage(new[] {"@171", "UserName", userName});
        }

        public static SpSystemMessage YouLegateSkillHasBeenCast(string skillName)
        {
            return new SpSystemMessage(new[] {"@172", "SkillName", skillName});
        }

        /* MORE??? */

        public static SpSystemMessage SmtInvitePartyFailed = new SpSystemMessage(new[] {"@189"});

        public static SpSystemMessage SmtInvitePartySucceed = new SpSystemMessage(new[] {"@190"});

        public static SpSystemMessage SmtLeavePartyFailed = new SpSystemMessage(new[] {"@191"});

        public static SpSystemMessage SmtLeavePartySucceed = new SpSystemMessage(new[] {"@192"});

        public static SpSystemMessage YourPartyHasDisbanded = new SpSystemMessage(new[] {"@193"});

        public static SpSystemMessage SmtSetPartyMsgFailed = new SpSystemMessage(new[] {"@194"});

        public static SpSystemMessage SmtSetPartyMsgSucceed = new SpSystemMessage(new[] {"@195"});

        public static SpSystemMessage SmtChangePartyManagerSucceed = new SpSystemMessage(new[] {"@196"});

        public static SpSystemMessage YouCantGroupWithSomeonePreparingForPvP = new SpSystemMessage(new[] {"@197"});

        public static SpSystemMessage SmtRegistPartySearchFailed = new SpSystemMessage(new[] {"@198"});

        public static SpSystemMessage SmtRegistPartySearchSucceed = new SpSystemMessage(new[] {"@199"});

        public static SpSystemMessage SmtRemovePartySearchFailed = new SpSystemMessage(new[] {"@200"});

        public static SpSystemMessage SmtRemovePartySearchSucceed = new SpSystemMessage(new[] {"@201"});

        public static SpSystemMessage SmtWritePartyPurposeFailed = new SpSystemMessage(new[] {"@202"});

        public static SpSystemMessage SmtWritePartyPurposeSucceed = new SpSystemMessage(new[] {"@203"});

        public static SpSystemMessage ThePartyIsFull = new SpSystemMessage(new[] {"@204"});

        /* MORE??? */

        public static SpSystemMessage
            GuildNamesMustBeASingleStringOfCharactersBetween3And15InLengthAndMustBeDifferentFromAnyExistingGuildName =
                new SpSystemMessage(new[] {"@209"});

        /* MORE??? */

        public static SpSystemMessage NameJoinedTheGuild(string name)
        {
            return new SpSystemMessage(new[] {"@260", "Name", name});
        }

        public static SpSystemMessage NameGuildApplicationWasRejected(string name)
        {
            return new SpSystemMessage(new[] {"@261", "Name", name});
        }

        public static SpSystemMessage Name1AcceptedName2IntoTheGuild(string name1, string name2)
        {
            return new SpSystemMessage(new[] {"@263", "Name1", name1, "Name2", name2});
        }

        public static SpSystemMessage Name1RejectedName2GuildApplication(string name1, string name2)
        {
            return new SpSystemMessage(new[] {"@264", "Name1", name1, "Name2", name2});
        }

        /* MORE??? */

        public static SpSystemMessage YouAreNotInAGuild = new SpSystemMessage(new[] {"@274"});

        public static SpSystemMessage TheGuildmasterCantDoThat = new SpSystemMessage(new[] {"@275"});

        public static SpSystemMessage YouAreNotTheGuildmaster = new SpSystemMessage(new[] {"@276"});

        public static SpSystemMessage YoureAlreadyInAGuild = new SpSystemMessage(new[] {"@277"});

        public static SpSystemMessage YouCantLeaveTheGuild = new SpSystemMessage(new[] {"@278"});

        public static SpSystemMessage YouCantRemoveThatRank = new SpSystemMessage(new[] {"@279"});

        public static SpSystemMessage GuildmasterRankCantBeChanged = new SpSystemMessage(new[] {"@280"});

        public static SpSystemMessage EnterARankNameBetweenMinLengthAndMaxLengthLettersLong(string minLength,
                                                                                            string maxLength)
        {
            return new SpSystemMessage(new[] {"@281", "MinLength", minLength, "MaxLength", maxLength});
        }

        public static SpSystemMessage ThatRankAlreadyExists = new SpSystemMessage(new[] {"@282"});

        public static SpSystemMessage YourPrivilegesDontAllowAouToDoThat = new SpSystemMessage(new[] {"@283"});

        public static SpSystemMessage ThatRankDoesntExist = new SpSystemMessage(new[] {"@284"});

        public static SpSystemMessage YoureNotInAGuild = new SpSystemMessage(new[] {"@285"});

        public static SpSystemMessage YouCantCreateAnyMoreRanks = new SpSystemMessage(new[] {"@286"});

        public static SpSystemMessage TheGuildHasBeenDisbanded(string guildName)
        {
            return new SpSystemMessage(new[] {"@287", "GuildName", guildName});
        }

        public static SpSystemMessage PlayerHasBeenRemovedFromTheGuild(string name)
        {
            return new SpSystemMessage(new[] {"@288", "Name", name});
        }

        public static SpSystemMessage PlayerIsNowGuildmaster(string name)
        {
            return new SpSystemMessage(new[] {"@289", "Name", name});
        }

        public static SpSystemMessage AcceptorAcceptedAccepteeToTheGuildWelcomeGuild(string acceptor, string acceptee,
                                                                                     string guildName)
        {
            return
                new SpSystemMessage(new[] {"@290", "Acceptor", acceptor, "Acceptee", acceptee, "GuildName", guildName});
        }

        public static SpSystemMessage AcceptorRejectedTheApplicationFromAccepteeToJoinGuild(string acceptor,
                                                                                            string acceptee,
                                                                                            string guildName)
        {
            return
                new SpSystemMessage(new[] {"@291", "Acceptor", acceptor, "Acceptee", acceptee, "GuildName", guildName});
        }

        public static SpSystemMessage GuildHasBeenCreated(string guildName)
        {
            return new SpSystemMessage(new[] {"@292", "GuildName", guildName});
        }

        public static SpSystemMessage OlayerDeclinedTheGuildCreationGuildWasNotCreated(string name, string guildName)
        {
            return new SpSystemMessage(new[] {"@293", "Name", name, "GuildName", guildName});
        }

        public static SpSystemMessage YouLeftTheGuild(string guildName)
        {
            return new SpSystemMessage(new[] {"@294", "GuildName", guildName});
        }

        public static SpSystemMessage NoSuchGuildExists = new SpSystemMessage(new[] {"@295"});

        public static SpSystemMessage SpecialCharactersAreNotAllowedInGuildNames = new SpSystemMessage(new[] {"@296"});

        public static SpSystemMessage PartOfThatGuildNameIsNotAllowed = new SpSystemMessage(new[] {"@297"});

        public static SpSystemMessage SpacesAreNotAllowedInGuildNames = new SpSystemMessage(new[] {"@298"});

        /* MORE??? */

        public static SpSystemMessage PartOfThatNameIsNotAllowed = new SpSystemMessage(new[] {"@300"});

        public static SpSystemMessage GuildCreationFailedPleaseTryAgain = new SpSystemMessage(new[] {"@301"});

        public static SpSystemMessage YouFailedToLearnThatSkill = new SpSystemMessage(new[] {"@302"});

        public static SpSystemMessage ThatItemIsNotInYourBank = new SpSystemMessage(new[] {"@303"});

        public static SpSystemMessage YouCantPutThatItemInYourBank = new SpSystemMessage(new[] {"@304"});

        public static SpSystemMessage YouCantPutGoldInYourBank = new SpSystemMessage(new[] {"@305"});

        /* MORE??? */

        public static SpSystemMessage YouBoughtAGuildHall = new SpSystemMessage(new[] {"@316"});

        public static SpSystemMessage YouCantBuyAGuildHall = new SpSystemMessage(new[] {"@317"});

        public static SpSystemMessage YouCantBuyAGuildHallYoureNotTheGuildmaster = new SpSystemMessage(new[] {"@318"});

        public static SpSystemMessage YouCantBuyAGuildHallYouAreNotAGuildmaster = new SpSystemMessage(new[] {"@319"});

        public static SpSystemMessage YourGuildAlreadyOwnsAGuildHall = new SpSystemMessage(new[] {"@320"});

        public static SpSystemMessage TheGuildHallIsNotForSale = new SpSystemMessage(new[] {"@321"});

        public static SpSystemMessage SmtCriticalSucks = new SpSystemMessage(new[] {"@322"});

        public static SpSystemMessage SmtCriticalHolySucks = new SpSystemMessage(new[] {"@323"});

        public static SpSystemMessage DiscoveredSection(string sectionName)
        {
            return new SpSystemMessage(new[] {"@324", "sectionName", sectionName});
        }

        public static SpSystemMessage SmtKickPartySucceed = new SpSystemMessage(new[] {"@325"});

        public static SpSystemMessage SmtKickPartyFailed = new SpSystemMessage(new[] {"@326"});

        public static SpSystemMessage SmtDismissPartyFailed = new SpSystemMessage(new[] {"@327"});

        public static SpSystemMessage SmtChangePartyManagerFailed = new SpSystemMessage(new[] {"@328"});

        public static SpSystemMessage YouWillBeTeleportedOutMomentarily = new SpSystemMessage(new[] {"@329"});

        public static SpSystemMessage YoureTooFarAway = new SpSystemMessage(new[] {"@330"});

        public static SpSystemMessage CantFindTargetOrTheyCouldNotReplyCheckSpellingAoTryAgainLater =
            new SpSystemMessage(new[] {"@331"});

        public static SpSystemMessage SelectADifferentCharacter = new SpSystemMessage(new[] {"@332"});

        public static SpSystemMessage YoureBusy = new SpSystemMessage(new[] {"@333"});

        public static SpSystemMessage TargetIsBusy = new SpSystemMessage(new[] {"@334"});

        public static SpSystemMessage NotLongerAvailable = new SpSystemMessage(new[] {"@335"});

        public static SpSystemMessage YouCantUseThatNow = new SpSystemMessage(new[] {"@336"});

        public static SpSystemMessage YouCantDiscardThatNow = new SpSystemMessage(new[] {"@337"});

        public static SpSystemMessage NothingThere = new SpSystemMessage(new[] {"@338"});

        public static SpSystemMessage YouCantDiscardItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@339", "ItemName", itemName});
        }

        public static SpSystemMessage YouCantTradeItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@340", "ItemName", itemName});
        }

        public static SpSystemMessage YouCantPurchaseItemThroughTheBrokerage(string itemName)
        {
            return new SpSystemMessage(new[] {"@341", "ItemName", itemName});
        }

        public static SpSystemMessage YouCantPutItemInInventory(string itemName)
        {
            return new SpSystemMessage(new[] {"@342", "ItemName", itemName});
        }

        public static SpSystemMessage YouCantEquipItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@343", "ItemName", itemName});
        }

        /* MORE??? */

        public static SpSystemMessage DiscardedItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@345", "ItemName", itemName});
        }

        public static SpSystemMessage UsedItemNameXItemAmount(string itemName, string itemAmount)
        {
            return new SpSystemMessage(new[] {"@346", "ItemName", itemName, "ItemAmount", itemAmount});
        }

        public static SpSystemMessage ThatItemIsSoulbound = new SpSystemMessage(new[] {"@347"});

        public static SpPlayerTradeHistory YouOfferedMoney(long money)
        {
            return new SpPlayerTradeHistory(new[] { "@348", "Money", money.ToString() });
        }

        public static SpPlayerTradeHistory YouAddedItemNameXItemAmountToTrade(int itemId, int count)
        {
            return new SpPlayerTradeHistory(new[] { "@349", "ItemName", "@item:" + itemId, "ItemAmount", count.ToString() });
        }

        public static SpPlayerTradeHistory YouRemovedItemNameXItemAmountToTrade(int itemId, int count)
        {
            return new SpPlayerTradeHistory(new[] { "@350", "ItemName", "@item:" + itemId, "ItemAmount", count.ToString() });
        }
        /* MORE??? */

        public static SpSystemMessage TradeCanceled = new SpSystemMessage(new[] {"@353"});

        public static SpSystemMessage OpponentCanceledTheTrade(string opponent)
        {
            return new SpSystemMessage(new[] {"@354", "Opponent", opponent});
        }

        public static SpSystemMessage TradeCompleted = new SpSystemMessage(new[] {"@355"});

        public static SpSystemMessage TradeHasBegun = new SpSystemMessage(new[] {"@356"});

        public static SpSystemMessage TooFarAway357 = new SpSystemMessage(new[] {"@357"});

        public static SpSystemMessage TargetDidntRespond = new SpSystemMessage(new[] {"@358"});

        public static SpSystemMessage TargetIsInCombat = new SpSystemMessage(new[] {"@359"});

        public static SpSystemMessage TargetIsBusy360 = new SpSystemMessage(new[] {"@360"});

        public static SpSystemMessage TradeListLocked = new SpSystemMessage(new[] {"@361"});
        public static SpPlayerTradeHistory TradeHasChangedPleaseCheckItAgain = new SpPlayerTradeHistory(new[] { "@362" });
        /* MORE??? */

        public static SpSystemMessage YouCantTradeThat = new SpSystemMessage(new[] {"@363"});

        public static SpSystemMessage YouCantTradeEquippedItems = new SpSystemMessage(new[] {"@364"});

        public static SpPlayerTradeHistory OpponentAddedItemNameItemAmount(string opponent, int itemId, int count)
        {
            return new SpPlayerTradeHistory(new[] { "@365", "Opponent", opponent, "ItemName", "@item:" + itemId, "ItemAmount", count.ToString() });
        }

        public static SpPlayerTradeHistory OpponentRemovedItemNameItemAmount(string opponent, int itemId, int count)
        {
            return new SpPlayerTradeHistory(new[] { "@366", "Opponent", opponent, "ItemName", "@item:" + itemId, "ItemAmount", count.ToString() });
        }

        public static SpPlayerTradeHistory OpponentOfferedMoney(string opponent, long money)
        {
            return new SpPlayerTradeHistory(new[] { "@367", "Opponent", opponent, "Money", money.ToString() });
        }

        public static SpPlayerTradeHistory OpponentLockedTradeList(string opponent)
        {
            return new SpPlayerTradeHistory(new[] { "@368", "Opponent", opponent });
        }

        public static SpSystemMessage UserRequestedATrade(string userName)
        {
            return new SpSystemMessage(new[] {"@372", "UserName", userName});
        }

        public static SpSystemMessage UserRejectedATrade(string userName)
        {
            return new SpSystemMessage(new[] {"@373", "UserName", userName});
        }

        public static SpSystemMessage OpponentRejectedATrade(string opponent)
        {
            return new SpSystemMessage(new[] {"@374", "Opponent", opponent});
        }

        /* MORE??? */

        public static SpSystemMessage YouCantPickUpItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@377", "ItemName", itemName});
        }

        public static SpSystemMessage YouCannotAttachItemAsAParcel(string itemName)
        {
            return new SpSystemMessage(new[] {"@378", "ItemName", itemName});
        }

        public static SpSystemMessage YouReceiveItemXItemAmount(string playerName, string itemName, int itemAmount)
        {
            return
                new SpSystemMessage(new[]
                                        {
                                            "@379", "UserName", playerName, "ItemAmount", itemAmount.ToString(), "ItemName"
                                            , itemName
                                        });
        }

        public static SpSystemMessage YouReceiveMoney(string money)
        {
            return new SpSystemMessage(new[] {"@380", "Money", money});
        }

        public static SpSystemMessage ItemIsntForYou(string itemName)
        {
            return new SpSystemMessage(new[] {"@381", "ItemName", itemName});
        }

        public static SpSystemMessage YouAreNotAVanarch = new SpSystemMessage(new[] {"@382"});

        public static SpSystemMessage YouCantChangeTaxesNow = new SpSystemMessage(new[] {"@383"});

        public static SpSystemMessage ThatAreaDoesntExist = new SpSystemMessage(new[] {"@384"});

        public static SpSystemMessage ThareIsNoElectionRightNow = new SpSystemMessage(new[] {"@385"});

        public static SpSystemMessage YouCantVoteWithThat = new SpSystemMessage(new[] {"@386"});

        public static SpSystemMessage AVanarchCantBeACandidateInAnotherProvince = new SpSystemMessage(new[] {"@387"});

        public static SpSystemMessage YouAreBerredFromThatAction = new SpSystemMessage(new[] {"@388"});

        public static SpSystemMessage YouCantDoThatHere = new SpSystemMessage(new[] {"@389"});

        public static SpSystemMessage NotACandidate = new SpSystemMessage(new[] {"@390"});

        /* MORE??? */

        //TODO: @396 not full args
        /*
        public static SpSystemMessage Sell\nSelling_price:_{sellPrice@money}\nCommission:_{sellCommision@money}\n_etc()
        {
            return new SpSystemMessage(new[] { "@396" });
        }
        */

        public static SpSystemMessage YouCantBuyAGuildHallYouAreNotInAGuild = new SpSystemMessage(new[] {"@397"});

        public static SpSystemMessage OnlyGuildmasterCanSellAGuildHall = new SpSystemMessage(new[] {"@398"});

        public static SpSystemMessage YourGuildDoesntOwnAGuildHall = new SpSystemMessage(new[] {"@399"});

        public static SpSystemMessage YouCantSellAGuildHallRightNow = new SpSystemMessage(new[] {"@400"});

        public static SpSystemMessage YouCantDoThatNow = new SpSystemMessage(new[] {"@401"});

        /* MORE??? */

        public static SpSystemMessage NoSuchPlayer = new SpSystemMessage(new[] {"@430"});

        public static SpSystemMessage PlayersNustBeOnlineToBeAddedToYourFriendsList = new SpSystemMessage(new[] {"@431"});

        public static SpSystemMessage YouAddedUserToYoutFriendsList(string userName)
        {
            return new SpSystemMessage(new[] {"@432", "UserName", userName});
        }

        public static SpSystemMessage YouveBeenAddedToUserFriendsList(string userName)
        {
            return new SpSystemMessage(new[] {"@433", "UserName", userName});
        }

        public static SpSystemMessage YouCanAnlySendThreeFriendInvitesToAnyOnePersonEachDay =
            new SpSystemMessage(new[] {"@434"});

        public static SpSystemMessage ThatPlayerBlockedYou = new SpSystemMessage(new[] {"@435"});

        public static SpSystemMessage YouRemovedUserFromYourFriendsList(string userName)
        {
            return new SpSystemMessage(new[] {"@436", "UserName", userName});
        }

        public static SpSystemMessage UserRemovedYouFromTheirFriendsList(string userName)
        {
            return new SpSystemMessage(new[] {"@437", "UserName", userName});
        }

        public static SpSystemMessage ThatPlayerIsAlreadyOnYourFriendsList = new SpSystemMessage(new[] {"@438"});

        public static SpSystemMessage ThatPlayerIsNotInYourFriendsList = new SpSystemMessage(new[] {"@439"});

        public static SpSystemMessage YourFriendsListIsFull = new SpSystemMessage(new[] {"@440"});

        public static SpSystemMessage InvalidTarget441 = new SpSystemMessage(new[] {"@441"});

        public static SpSystemMessage UserHasComeOnline(string userName)
        {
            return new SpSystemMessage(new[] {"@442", "UserName", userName});
        }

        public static SpSystemMessage UserHasEnteredArea(string userName, string areaName)
        {
            return new SpSystemMessage(new[] {"@443", "UserName", userName, "AreaName", areaName});
        }

        public static SpSystemMessage PostDelivered = new SpSystemMessage(new[] {"@444"});

        /* MORE??? */

        public static SpSystemMessage TargetIsAlreadyInAnotherParty = new SpSystemMessage(new[] {"@455"});

        public static SpSystemMessage YouCantEnchantThatItem = new SpSystemMessage(new[] {"@456"});

        public static SpSystemMessage TheresAlreadySomethingInThatSlot = new SpSystemMessage(new[] {"@457"});

        public static SpSystemMessage ThatsNotAnEnchantingMaterial = new SpSystemMessage(new[] {"@458"});

        public static SpSystemMessage YouCanOnlyUseAlkahestThere = new SpSystemMessage(new[] {"@459"});

        public static SpSystemMessage ThatsTheWrongTypeOfItem = new SpSystemMessage(new[] {"@460"});

        public static SpSystemMessage YouCantEnchantAnEquippedItem = new SpSystemMessage(new[] {"@461"});

        public static SpSystemMessage YouveSuccessfullyEnchantedItem(string added, string itemName)
        {
            return new SpSystemMessage(new[] {"@462", "Added", added, "ItemName", itemName});
        }

        public static SpSystemMessage FailedToEnchantItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@463", "ItemName", itemName});
        }

        public static SpSystemMessage UserHasSuccessfullyEnchantedItem(string userName, string added, string itemName)
        {
            return new SpSystemMessage(new[] {"@464", "UserName", userName, "Added", added, "ItemName", itemName});
        }

        /* MORE??? */

        public static SpSystemMessage YouCantClimbRightNow = new SpSystemMessage(new[] {"@473"});

        /* MORE??? */

        public static SpSystemMessage CanceledTimeIsUp = new SpSystemMessage(new[] {"@486"});

        /* MORE??? */

        public static SpSystemMessage RequestorChallengesYouToDuel(string requestor)
        {
            return new SpSystemMessage(new[] {"@489", "requestor", requestor});
        }

        public static SpSystemMessage TargetRejectedTheDuel(string target)
        {
            return new SpSystemMessage(new[] {"@490", "target", target});
        }

        public static SpSystemMessage TargetAcceptedTheDuel(string target)
        {
            return new SpSystemMessage(new[] {"@491", "target", target});
        }

        public static SpSystemMessage StartingDuelIn(string countsec)
        {
            return new SpSystemMessage(new[] {"@492", "countsec", countsec});
        }

        public static SpSystemMessage Duel = new SpSystemMessage(new[] {"@493"});

        public static SpSystemMessage YouAreInADuelNow = new SpSystemMessage(new[] {"@494"});

        public static SpSystemMessage TargetIsBusy495 = new SpSystemMessage(new[] {"@495"});

        public static SpSystemMessage YouCantDuelWithSomeoneInPvP = new SpSystemMessage(new[] {"@496"});

        public static SpSystemMessage DuelTargetDoesntExist = new SpSystemMessage(new[] {"@497"});

        public static SpSystemMessage YouAreTooFarAwayToDuel = new SpSystemMessage(new[] {"@498"});

        public static SpSystemMessage DuelingIsNotAllowedHere = new SpSystemMessage(new[] {"@499"});

        public static SpSystemMessage DuelAutomaticalleEndIn(string countsec)
        {
            return new SpSystemMessage(new[] {"@500", "countsec", countsec});
        }

        public static SpSystemMessage WinnerDefeatedLoserInADuel(string winner, string loser)
        {
            return new SpSystemMessage(new[] {"@501", "winner", winner, "loser", loser});
        }

        public static SpSystemMessage DuelWon = new SpSystemMessage(new[] {"@502"});

        public static SpSystemMessage DuelLost = new SpSystemMessage(new[] {"@503"});

        public static SpSystemMessage ItsADraw = new SpSystemMessage(new[] {"@504"});

        public static SpSystemMessage DuelEndedPvPBeginning = new SpSystemMessage(new[] {"@505"});

        public static SpSystemMessage DuelEndedInADraw = new SpSystemMessage(new[] {"@506"});

        public static SpSystemMessage DuelAutomaticallyEnded = new SpSystemMessage(new[] {"@507"});

        public static SpSystemMessage TheDuelHasEnded = new SpSystemMessage(new[] {"@508"});

        /* MORE??? */

        public static SpSystemMessage YouCanOnlyUseEngineOfMischiefWhileNearCampfire513 =
            new SpSystemMessage(new[] {"@513"});

        public static SpSystemMessage YouCanOnlyUseEngineOfMischiefWhileNearCampfire514 =
            new SpSystemMessage(new[] {"@514"});

        public static SpSystemMessage YoureAlreadyUsingAnEngineOfMischief = new SpSystemMessage(new[] {"@515"});

        public static SpSystemMessage ThatItemCantBePutInTheEngineOfMischief = new SpSystemMessage(new[] {"@516"});

        public static SpSystemMessage IfYourCampfireGoesOutTheEngineOfMischiefWillVanish =
            new SpSystemMessage(new[] {"@517"});

        public static SpSystemMessage UserPutItemInAnEnfineOfMischiefAndWon(string userName, string itemName,
                                                                            string inAmount, string outAmount)
        {
            return
                new SpSystemMessage(new[]
                                        {
                                            "@518", "UserName", userName, "ItemName", itemName, "InAmount", inAmount,
                                            "OutAmount", outAmount
                                        });
        }

        public static SpSystemMessage MoreMayhemThanMischief = new SpSystemMessage(new[] {"@519"});

        /* MORE??? */

        public static SpSystemMessage SmtLoanContractAcceptLoaner = new SpSystemMessage(new[] {"@524"});

        public static SpSystemMessage SmtLoanContractAcceptLoanee = new SpSystemMessage(new[] {"@525"});

        /* MORE??? */

        public static SpSystemMessage SmtLoanRegisterLoanMoney = new SpSystemMessage(new[] {"@527"});

        public static SpSystemMessage SmtLoanRegisterLoanInterestRate = new SpSystemMessage(new[] {"@528"});

        public static SpSystemMessage SmtLoanRegisterMortgageFailed = new SpSystemMessage(new[] {"@529"});

        public static SpSystemMessage SmtLoanContractCanceled = new SpSystemMessage(new[] {"@530"});

        public static SpSystemMessage SmtLoanContractTerm = new SpSystemMessage(new[] {"@531"});

        public static SpSystemMessage SmtLoanConfirm = new SpSystemMessage(new[] {"@532"});

        public static SpSystemMessage SmtLoanContractAccepted = new SpSystemMessage(new[] {"@533"});

        public static SpSystemMessage SmtLoanInterestPaymentLoaner = new SpSystemMessage(new[] {"@534"});

        public static SpSystemMessage SmtLoanInterestPaymentLoanee = new SpSystemMessage(new[] {"@535"});

        public static SpSystemMessage SmtLoanInterestPaymentFailedLoaner = new SpSystemMessage(new[] {"@536"});

        public static SpSystemMessage SmtLoanInterestPaymentFailedLoanee = new SpSystemMessage(new[] {"@537"});

        public static SpSystemMessage SmtLoanMortgageSeizedLoaner = new SpSystemMessage(new[] {"@538"});

        public static SpSystemMessage SmtLoanMortgageSeizedLoanee = new SpSystemMessage(new[] {"@539"});

        public static SpSystemMessage SmtLoanInterestPeriodExtendedLoaner = new SpSystemMessage(new[] {"@540"});

        public static SpSystemMessage SmtLoanInterestPeriodExtendedLoanee = new SpSystemMessage(new[] {"@541"});

        public static SpSystemMessage SmtLoanPrincipalPaymentLoaner = new SpSystemMessage(new[] {"@542"});

        public static SpSystemMessage SmtLoanPrincipalPaymentLoanee = new SpSystemMessage(new[] {"@543"});

        public static SpSystemMessage SmtLoanPrincipalPaymentFailedLoaner = new SpSystemMessage(new[] {"@544"});

        public static SpSystemMessage SmtLoanPrincipalPaymentFailedLoanee = new SpSystemMessage(new[] {"@545"});

        public static SpSystemMessage SmtLoanContractEnd = new SpSystemMessage(new[] {"@546"});

        public static SpSystemMessage SmtLoanManagementWindowOpened = new SpSystemMessage(new[] {"@547"});

        public static SpSystemMessage SmtLoanManagementWindowClosed = new SpSystemMessage(new[] {"@548"});

        public static SpSystemMessage SmtLoanContractTermExtendedLoaner = new SpSystemMessage(new[] {"@549"});

        public static SpSystemMessage SmtLoanContractTermExtendedLoanee = new SpSystemMessage(new[] {"@550"});

        public static SpSystemMessage YouCantDoThatToCollateral = new SpSystemMessage(new[] {"@551"});

        public static SpSystemMessage YouCantUseThatAsCollateral = new SpSystemMessage(new[] {"@552"});

        public static SpSystemMessage YouCantUseSkillsWhileFlying = new SpSystemMessage(new[] {"@553"});

        public static SpSystemMessage InvalidRecipe = new SpSystemMessage(new[] {"@554"});

        public static SpSystemMessage YouDontHaveEnoughSkillInSkill(string skill)
        {
            return new SpSystemMessage(new[] {"@555", "Skill", skill});
        }

        public static SpSystemMessage YouCantExtractAnythingFromThatItem = new SpSystemMessage(new[] {"@556"});

        public static SpSystemMessage YourExtractionLevelIsTooLowForThatItem = new SpSystemMessage(new[] {"@557"});

        public static SpSystemMessage SkillLevelIncreased = new SpSystemMessage(new[] {"@558"});

        public static SpSystemMessage SkillIncreasedByProf(string skillName, string prof)
        {
            return new SpSystemMessage(new[] {"@559", "SkillName", skillName, "SkillProf", prof});
        }

        public static SpSystemMessage YouLearnedToMakeRecipe(string recipe)
        {
            return new SpSystemMessage(new[] {"@560", "Recipe", recipe});
        }

        public static SpSystemMessage YouDontHaveEnoughCraftingMaterials = new SpSystemMessage(new[] {"@561"});

        public static SpSystemMessage CraftedItem(string item)
        {
            return new SpSystemMessage(new[] {"@562", "ItemName", item});
        }

        public static SpSystemMessage FailedToCraftItem(string item)
        {
            return new SpSystemMessage(new[] {"@563", "Item", item});
        }

        public static SpSystemMessage SkillIsNowLevelRank(string skill, string rank)
        {
            return new SpSystemMessage(new[] {"@564", "Skill", skill, "Rank", rank});
        }

        public static SpSystemMessage NothingToExtract = new SpSystemMessage(new[] {"@565"});

        public static SpSystemMessage SuccessfullyExtractedItem(string itemName)
        {
            return new SpSystemMessage(new[] {"@566", "ItemName", itemName});
        }

        public static SpSystemMessage SmtBuyerrandGoing = new SpSystemMessage(new[] {"@567"});

        public static SpSystemMessage SmtBuyerrandRequestFix = new SpSystemMessage(new[] {"@568"});

        public static SpSystemMessage SmtBuyerrandSuccess = new SpSystemMessage(new[] {"@569"});

        public static SpSystemMessage SmtBuyerrandFail = new SpSystemMessage(new[] {"@570"});

        public static SpSystemMessage SmtBuyerrandAbandon = new SpSystemMessage(new[] {"@571"});

        public static SpSystemMessage SmtBuyerrandTemp = new SpSystemMessage(new[] {"@572"});

        public static SpSystemMessage SmtBuyerrandBuying = new SpSystemMessage(new[] {"@573"});

        public static SpSystemMessage SmtBuyerrandBuydone = new SpSystemMessage(new[] {"@574"});

        /* MORE??? */

        public static SpSystemMessage SmtCancelBuyerrand = new SpSystemMessage(new[] {"@579"});

        /* MORE??? */

        public static SpSystemMessage YouCantTeleportRightNow581 = new SpSystemMessage(new[] {"@581"});

        public static SpSystemMessage YouDontHaveEnoughEp = new SpSystemMessage(new[] {"@582"});

        public static SpSystemMessage YouCantBookmarkAnyMoreLocations = new SpSystemMessage(new[] {"@583"});

        public static SpSystemMessage YouCantBookmarkALocationsRightNow = new SpSystemMessage(new[] {"@584"});

        /* MORE??? */

        public static SpSystemMessage CharWillBeSummonedMomentarily(string charName)
        {
            return new SpSystemMessage(new[] {"@589", "CharName", charName});
        }

        /* MORE??? */

        public static SpSystemMessage YouCantTradeEquippedItems593 = new SpSystemMessage(new[] {"@593"});

        public static SpSystemMessage YouCantTrade = new SpSystemMessage(new[] {"@594"});

        public static SpSystemMessage SmtAskdialogTel = new SpSystemMessage(new[] {"@595"});

        public static SpSystemMessage SmtAskdialogOr = new SpSystemMessage(new[] {"@596"});

        public static SpSystemMessage SmtAskdialogTelEnd = new SpSystemMessage(new[] {"@597"});

        /* MORE??? */

        public static SpSystemMessage BattleBegan = new SpSystemMessage(new[] {"@600"});

        public static SpSystemMessage BattleEnded = new SpSystemMessage(new[] {"@601"});

        public static SpSystemMessage PartyPlayerIsDead(string partyPlayerName)
        {
            return new SpSystemMessage(new[] {"@602", "PartyPlayerName", partyPlayerName});
        }

        public static SpSystemMessage PartyPlayerHasBeenResurrected(string partyPlayerName)
        {
            return new SpSystemMessage(new[] {"@603", "PartyPlayerName", partyPlayerName});
        }

        /* MORE??? */

        public static SpSystemMessage YouCantSetUpShopHereYoureTooCloseToAnotherShop =
            new SpSystemMessage(new[] {"@605"});

        public static SpSystemMessage YouCantSetUpShopHere = new SpSystemMessage(new[] {"@606"});

        public static SpSystemMessage YouCantPlaceThatItemThere = new SpSystemMessage(new[] {"@607"});

        public static SpSystemMessage YouCantOpenAShopRightNowYouHaveNoItemsToSell = new SpSystemMessage(new[] {"@608"});

        public static SpSystemMessage YouCantSellItemsThatArentInYourShop = new SpSystemMessage(new[] {"@609"});

        public static SpSystemMessage TheSellerHasInterruptedTheSale = new SpSystemMessage(new[] {"@610"});

        public static SpSystemMessage YouHaveTooMuchGold = new SpSystemMessage(new[] {"@611"});

        public static SpSystemMessage SoldItemFromYourShop(string itemName, string count)
        {
            return new SpSystemMessage(new[] {"@612", "ItemName", itemName, "Count", count});
        }

        public static SpSystemMessage YourPetNeedsRepairAllItemsStockedInYourShopWillBeDestroyedIfYourPetBreaksDown =
            new SpSystemMessage(new[] {"@613"});

        public static SpSystemMessage YouDontHaveEnoughGold614 = new SpSystemMessage(new[] {"@614"});

        public static SpSystemMessage YouCantBuyItemsThatArentInTheBuyingList = new SpSystemMessage(new[] {"@615"});

        public static SpSystemMessage TheBuyerHasInterruptedTheSale = new SpSystemMessage(new[] {"@616"});

        public static SpSystemMessage YouBoughtItemFromThePet(string itemName, string count)
        {
            return new SpSystemMessage(new[] {"@617", "ItemName", itemName, "Count", count});
        }

        public static SpSystemMessage OnlyAvailableAsAPurchasingShop = new SpSystemMessage(new[] {"@618"});

        public static SpSystemMessage OnlyAvailableAsASalesShop = new SpSystemMessage(new[] {"@619"});

        /* MORE??? */

        public static SpSystemMessage NewQuest(string questName)
        {
            return new SpSystemMessage(new[] {"@624", "QuestName", questName});
        }

        public static SpSystemMessage QuestCompleted(string questName)
        {
            return new SpSystemMessage(new[] {"@625", "QuestName", questName});
        }

        public static SpSystemMessage QuestFailed(string questName)
        {
            return new SpSystemMessage(new[] {"@626", "QuestName", questName});
        }

        public static SpSystemMessage QuestAbandoned(string questName)
        {
            return new SpSystemMessage(new[] {"@627", "QuestName", questName});
        }

        public static SpSystemMessage YouCantMakeACampfireRightNow = new SpSystemMessage(new[] {"@628"});

        public static SpSystemMessage TheresAnotherCampfireNearHere = new SpSystemMessage(new[] {"@629"});

        public static SpSystemMessage TooManyItemsAreBeingUsedInThisCampfireTryAgainLater =
            new SpSystemMessage(new[] {"@630"});

        public static SpSystemMessage CharmsCanOnlyBeUsedNearACampfire = new SpSystemMessage(new[] {"@631"});

        public static SpSystemMessage YouAreRechargingStamina = new SpSystemMessage(new[] {"@632"});

        public static SpSystemMessage YouAreNoLongerRechargingStamina = new SpSystemMessage(new[] {"@633"});

        public static SpSystemMessage YourStamnaIsNotFullToIncreaseYourStaminaStayNearCampfire =
            new SpSystemMessage(new[] {"@634"});

        public static SpSystemMessage YourStaminaIsSpentYouShouldRechargeByACampfire =
            new SpSystemMessage(new[] {"@635"});

        public static SpSystemMessage YouHaveAbundantStamina = new SpSystemMessage(new[] {"@636"});

        public static SpSystemMessage CharmEffectAffectsYourAbilities(string charmEffectName)
        {
            return new SpSystemMessage(new[] {"@637", "CharmEffectName", charmEffectName});
        }

        public static SpSystemMessage TheEngineOfMischiefCanAnlyBeUsedNearACampfire = new SpSystemMessage(new[] {"@638"});

        public static SpSystemMessage YouCantUseAnEngineOfMerschiefWhileYpurInventoryIsFull =
            new SpSystemMessage(new[] {"@639"});

        public static SpSystemMessage YouCanOnlyUseAnEngineOfMerschiefWhileNearACampfire =
            new SpSystemMessage(new[] {"@640"});

        public static SpSystemMessage IfYourCampfireGoesOutTheEngineOfMerschiefWillVanish =
            new SpSystemMessage(new[] {"@641"});

        public static SpSystemMessage ThisItemCannotBeUsedInThisBox = new SpSystemMessage(new[] {"@642"});

        public static SpSystemMessage YoureAlreadyUsingAnEngineOfMerschief = new SpSystemMessage(new[] {"@643"});

        public static SpSystemMessage YouAreDead(string name)
        {
            return new SpSystemMessage(new[] { "@655", "UserName", name});
        }

        public static SpSystemMessage Extracting(string itemIdString)
        {
            return new SpSystemMessage(new[] {"@821", "ItemName", itemIdString});
        }

        public static SpSystemMessage YouPraiseGuildNowYouHavePraisesLeft(string guildName, int remainCount)
        {
            return new SpSystemMessage(new[] { "@1370", "GuildName", guildName, "RemainCount", remainCount.ToString()});
        }

        public static SpSystemMessage AskingYourPartyMembersToAproveCreationOfThisGuild =
            new SpSystemMessage(new[] {"@1605"});

        //TODO: ADD OTHERS
    }
}