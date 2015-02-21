using System.Collections.Generic;
using System.ComponentModel;
using Data.Enums;
using Data.Structures.Template.Item;

namespace Data.Structures.Creature
{
    [ProtoBuf.ProtoContract]
    public class CreatureBaseStats
    {
        [ProtoBuf.ProtoMember(1)]
        public PlayerClass PlayerClass;

        [ProtoBuf.ProtoMember(2)]
        public int NpcId = 0;

        [ProtoBuf.ProtoMember(3)]
        public string NpcName = "";

        [ProtoBuf.ProtoMember(4)]
        public int Level = 1;

        [ProtoBuf.ProtoMember(5)]
        public int NpcHuntingZoneId = 0;

        //HpMp

        [ProtoBuf.ProtoMember(10)]
        [Category("LifeStats")]
        public int HpBase { get; set; }
        [ProtoBuf.ProtoMember(11)]
        [Category("LifeStats")]
        public int HpStamina { get; set; }

        [ProtoBuf.ProtoMember(12)]
        [Category("LifeStats")]
        public int MpBase { get; set; }
        [ProtoBuf.ProtoMember(13)]
        [Category("LifeStats")]
        public int MpStamina { get; set; }

        //Combat

        [ProtoBuf.ProtoMember(20)]
        [Category("Combat")]
        public int Attack { get; set; }
        [ProtoBuf.ProtoMember(21)]
        [Category("Combat")]
        public int Defense { get; set; }
        [ProtoBuf.ProtoMember(22)]
        [Category("Combat")]
        public int Impact { get; set; }
        [ProtoBuf.ProtoMember(23)]
        [Category("Combat")]
        public int Balance { get; set; }
        [ProtoBuf.ProtoMember(24)]
        [Category("Combat")]
        public int CritChanse { get; set; }
        [ProtoBuf.ProtoMember(25)]
        [Category("Combat")]
        public int CritResist { get; set; }
        [ProtoBuf.ProtoMember(26)]
        [Category("Combat")]
        public int CritPower { get; set; }
        
        //Stats

        [ProtoBuf.ProtoMember(30)]
        [Category("Stats")]
        public int Power { get; set; }
        [ProtoBuf.ProtoMember(31)]
        [Category("Stats")]
        public int Endurance { get; set; }
        [ProtoBuf.ProtoMember(32)]
        [Category("Stats")]
        public int ImpactFactor { get; set; }
        [ProtoBuf.ProtoMember(33)]
        [Category("Stats")]
        public int BalanceFactor { get; set; }
        [ProtoBuf.ProtoMember(34)]
        [Category("Stats")]
        public int AttackSpeed { get; set; }
        [ProtoBuf.ProtoMember(35)]
        [Category("Stats")]
        public short Movement { get; set; }
        
        //Resistances

        [ProtoBuf.ProtoMember(40)]
        [Category("Resistances")]
        public int WeakeningResist { get; set; }
        [ProtoBuf.ProtoMember(41)]
        [Category("Resistances")]
        public int PeriodicResist { get; set; }
        [ProtoBuf.ProtoMember(42)]
        [Category("Resistances")]
        public int StunResist { get; set; }


        //Regen

        [ProtoBuf.ProtoMember(50)]
        [Category("LifeStats")]
        public int NaturalMpRegen { get; set; }
        [ProtoBuf.ProtoMember(51)]
        [Category("LifeStats")]
        public int CombatMpRegen { get; set; }
        
        // Additional stats
        public List<Passivity> Passivities = new List<Passivity>();

        public override string ToString()
        {
            if (NpcHuntingZoneId == 0)
                return string.Format("Player: {0}", PlayerClass);

            return string.Format("Npc: {0} [{1}:{2}]", NpcName, NpcHuntingZoneId, NpcId);
        }

        public CreatureBaseStats Clone()
        {
            return (CreatureBaseStats) MemberwiseClone();
        }

        public void CopyTo(CreatureBaseStats gameStats)
        {
            //HpMp
            gameStats.HpBase = HpBase;
            gameStats.HpStamina = HpStamina;
            gameStats.MpBase = MpBase;
            gameStats.MpStamina = MpStamina;

            //Combat
            gameStats.Attack = Attack;
            gameStats.Defense = Defense;
            gameStats.Impact = Impact;
            gameStats.Balance = Balance;
            gameStats.CritChanse = CritChanse;
            gameStats.CritResist = CritResist;
            gameStats.CritPower = CritPower;
        
            //Stats
            gameStats.Power = Power;
            gameStats.Endurance = Endurance;
            gameStats.ImpactFactor = ImpactFactor;
            gameStats.BalanceFactor = BalanceFactor;
            gameStats.AttackSpeed = AttackSpeed;
            gameStats.Movement = Movement;
        
            //Resistances
            gameStats.WeakeningResist = WeakeningResist;
            gameStats.PeriodicResist = PeriodicResist;
            gameStats.StunResist = StunResist;
            
            //Regen
            gameStats.NaturalMpRegen = NaturalMpRegen;
            gameStats.CombatMpRegen = CombatMpRegen;

            gameStats.Passivities = new List<Passivity>();
        }
    }
}