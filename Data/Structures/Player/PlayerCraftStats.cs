using System.Collections.Generic;
using Data.Enums.Craft;
using Data.Enums.Gather;

namespace Data.Structures.Player
{
    [ProtoBuf.ProtoContract]
    public class PlayerCraftStats
    {
        [ProtoBuf.ProtoMember(1)]
        public Dictionary<CraftStat, short> CraftSkillCollection = new Dictionary<CraftStat, short>();

        [ProtoBuf.ProtoMember(2)]
        public Dictionary<CraftStat, short> ExtractSkillCollection = new Dictionary<CraftStat, short>();

        [ProtoBuf.ProtoMember(50)]
        private readonly Dictionary<TypeName, short> _gatherSkillCollection = new Dictionary<TypeName, short>();

        //empty constructor 4 protobuf
        public PlayerCraftStats()
        {
            
        }

        public PlayerCraftStats(short weaponsmithing = 1, short focuscrafting = 1,
                                short armorsmithing = 1, short leatherworking = 1, short tailoring = 1,
                                short alchemy = 1, short clothExtraction = 0, short metalExtraction = 0,
                                short alchemyExtraction = 0, short leatherExtraction = 0, short planting = 1, short mining = 1, short energing = 1, short bughunting = 1)
        {
            CraftSkillCollection.Add(CraftStat.Weaponsmithing, weaponsmithing);
            CraftSkillCollection.Add(CraftStat.Focuscrafting, focuscrafting);
            CraftSkillCollection.Add(CraftStat.Armorsmithing, armorsmithing);
            CraftSkillCollection.Add(CraftStat.Leatherworking, leatherworking);
            CraftSkillCollection.Add(CraftStat.Tailoring, tailoring);
            CraftSkillCollection.Add(CraftStat.Alchemy, alchemy);

            if (clothExtraction > 0)
                ExtractSkillCollection.Add(CraftStat.ClothExtraction, clothExtraction);

            if (metalExtraction > 0)
                ExtractSkillCollection.Add(CraftStat.MetalExtraction, metalExtraction);

            if (alchemyExtraction > 0)
                ExtractSkillCollection.Add(CraftStat.AlchemyExtraction, alchemyExtraction);

            if (leatherExtraction > 0)
                ExtractSkillCollection.Add(CraftStat.LeatherExtraction, leatherExtraction);

            _gatherSkillCollection.Add(TypeName.Herb, planting);
            _gatherSkillCollection.Add(TypeName.Mine, mining);
            _gatherSkillCollection.Add(TypeName.Energy, energing);
            _gatherSkillCollection.Add(TypeName.Bug, bughunting);
        }

        public void ProgressCraftStat(CraftStat stat)
        {
            switch (stat)
            {
                case CraftStat.Weaponsmithing:
                case CraftStat.Focuscrafting:
                case CraftStat.Armorsmithing:
                case CraftStat.Leatherworking:
                case CraftStat.Tailoring:
                case CraftStat.Alchemy:
                    if (CraftSkillCollection[stat] < 410)
                        CraftSkillCollection[stat]++;
                    break;

                case CraftStat.ClothExtraction:
                case CraftStat.MetalExtraction:
                case CraftStat.AlchemyExtraction:
                case CraftStat.LeatherExtraction:
                    if (!ExtractSkillCollection.ContainsKey(stat))
                        ExtractSkillCollection.Add(stat, 0);
                    if (ExtractSkillCollection[stat] < 13)
                        ExtractSkillCollection[stat]++;
                    break;
            }

            //TODO:
            //new SpCharacterCraftStats(Parent).Send(Parent.PState);
        }

        public void ProgressGatherStat(TypeName typeName)
        {
            if(_gatherSkillCollection[typeName] > 300)
                return;

            _gatherSkillCollection[typeName]++;
        }

        public short GetGatherStat(TypeName typeName)
        {
            return _gatherSkillCollection[typeName];
        }

        public short GetCraftSkills(CraftStat craftStat)
        {
            switch (craftStat)
            {
                case CraftStat.Weaponsmithing:
                case CraftStat.Focuscrafting:
                case CraftStat.Armorsmithing:
                case CraftStat.Leatherworking:
                case CraftStat.Tailoring:
                case CraftStat.Alchemy:
                    return CraftSkillCollection[craftStat];
                default:
                    return ExtractSkillCollection[craftStat];
            }
        }
    }
}