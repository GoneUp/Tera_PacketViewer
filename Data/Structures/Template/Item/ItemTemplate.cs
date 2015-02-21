using System;
using System.Collections.Generic;
using Data.Enums;
using Data.Enums.Item;
using Data.Structures.Template.Item.CategorieStats;

namespace Data.Structures.Template.Item
{
    [ProtoBuf.ProtoContract]
    public class ItemTemplate
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id;

        [ProtoBuf.ProtoMember(2)]
        public int Level;

        [ProtoBuf.ProtoMember(3)]
        public string Name;

        [ProtoBuf.ProtoMember(4)]
        public ItemCategory ItemCategory;

        [ProtoBuf.ProtoMember(5)]
        public int Cooltime;

        [ProtoBuf.ProtoMember(6)]
        public int ResourseSize;

        [ProtoBuf.ProtoMember(7)]
        public ItemResourseType ItemResourseType;

        [ProtoBuf.ProtoMember(8)]
        public int BuyPrice;

        [ProtoBuf.ProtoMember(9)]
        public CombatItemType CombatItemType;

        [ProtoBuf.ProtoMember(10)]
        public bool ChangeColorEnable;

        [ProtoBuf.ProtoMember(11)]
        public bool ChangeLook;

        [ProtoBuf.ProtoMember(12)]
        public bool ExtractLook;

        [ProtoBuf.ProtoMember(13)]
        public int MaxStack;

        [ProtoBuf.ProtoMember(14)]
        public int Rank;

        [ProtoBuf.ProtoMember(15)]
        public int RareGrade;

        [ProtoBuf.ProtoMember(16)]
        public RequiredEquipmentType RequiredEquipmentType;

        [ProtoBuf.ProtoMember(17)]
        public int RequiredLevel;

        [ProtoBuf.ProtoMember(18)]
        public bool RequiredSecondCharacter;

        [ProtoBuf.ProtoMember(19)]
        public int SellPrice;

        [ProtoBuf.ProtoMember(20)]
        public bool SkillBookIsActive;

        [ProtoBuf.ProtoMember(21)]
        public int SlotLimit;

        [ProtoBuf.ProtoMember(22)]
        public bool Tradable;

        [ProtoBuf.ProtoMember(23)]
        public bool WarehouseStorable;

        [ProtoBuf.ProtoMember(24)]
        public int UnidentifiedItemGrade;

        [ProtoBuf.ProtoMember(25)]
        public bool UseOnlyTerritory;

        [ProtoBuf.ProtoMember(26)]
        public int CoolTimeGroup;

        [ProtoBuf.ProtoMember(27)]
        public bool StoreSellable;

        [ProtoBuf.ProtoMember(28)]
        public bool EnchantEnable;

        [ProtoBuf.ProtoMember(29)]
        public bool Artisanable;

        [ProtoBuf.ProtoMember(30)]
        public bool GuildWarehouseStorable;

        private string _requiredClasses;

        [ProtoBuf.ProtoMember(31)]
        public string RequiredClasses
        {
            set
            {
                _requiredClasses = value;

                string[] classes = value.Split(';');
                foreach (var sClass in classes)
                {
                    RequiredClassesList.Add((PlayerClass) Enum.Parse(typeof (PlayerClass), sClass, true));
                }
            }
            get { return _requiredClasses; }
        }

        public List<PlayerClass> RequiredClassesList = new List<PlayerClass>();

        [ProtoBuf.ProtoMember(32)]
        public string RequiredUserStatus;

        [ProtoBuf.ProtoMember(33)] public List<Passivity> Passivities;

        [ProtoBuf.ProtoMember(101)]
        public IDefaultCategorieStat CatigorieStat;

        private static readonly ItemTemplate NullTemplate = new ItemTemplate();

        public static ItemTemplate Factory(int id)
        {
            return !Data.ItemTemplates.ContainsKey(id) ? NullTemplate : Data.ItemTemplates[id];
        }
    }
}
