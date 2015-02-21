using Data.Enums;
using Data.Structures.Creature;
using Data.Structures.Npc;

namespace Data.Structures.Template
{
    [ProtoBuf.ProtoContract]
    public class NpcTemplate
    {
        [ProtoBuf.ProtoMember(1)]
        public int HuntingZoneId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int Id { get; set; }

        public int FullId
        {
            get { return Id + HuntingZoneId*100000; }
        }

        [ProtoBuf.ProtoMember(3)]
        public float Scale { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public NpcSize Size { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public NpcShape Shape { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public int Level { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public NpcTitle Title { get; set; }

        //resourceSize

        //resourceType

        //class

        [ProtoBuf.ProtoMember(12)]
        public Gender Gender { get; set; }

        [ProtoBuf.ProtoMember(13)]
        public NpcRace Race { get; set; }

        [ProtoBuf.ProtoMember(14)]
        public int ParentId { get; set; }

        //despawnScriptId

        //basicActionId

        [ProtoBuf.ProtoMember(17)]
        public bool CollideOnMove { get; set; }

        [ProtoBuf.ProtoMember(18)]
        public bool CameraPenetratable { get; set; }

        [ProtoBuf.ProtoMember(19)]
        public bool IsHomunculus { get; set; }

        //deathShapeId

        [ProtoBuf.ProtoMember(21)]
        public bool DontTurn { get; set; }

        [ProtoBuf.ProtoMember(22)]
        public bool IsVillager { get; set; }

        [ProtoBuf.ProtoMember(23)]
        public bool IsObject { get; set; }

        [ProtoBuf.ProtoMember(24)]
        public bool IsElite { get; set; }

        [ProtoBuf.ProtoMember(25)]
        public bool IsUnionElite { get; set; }

        [ProtoBuf.ProtoMember(26)]
        public bool IsFreeNamed { get; set; }

        [ProtoBuf.ProtoMember(27)]
        public bool ShowAggroTarget { get; set; }

        //spawnScriptId

        [ProtoBuf.ProtoMember(29)]
        public bool IsSpirit { get; set; }

        [ProtoBuf.ProtoMember(30)]
        public bool IsWideBroadcaster { get; set; }

        //villagerVolumeActiveRange

        //villagerVolumeHalfHeight

        //villagerVolumeInteractionDist

        //villagerVolumeOffset

        [ProtoBuf.ProtoMember(35)]
        public bool ShowShorttermTarget { get; set; }

        //__value__

        //cannotPassThrough

        //vehicleEx

        //NamePlate

        //VehicleType

        //SeatList

        //Shader

        //DeathEffect

        //Stat (Level)

        //AltAnimation

        //Emoticon
        
        //[ProtoBuf.ProtoMember(100)]
        private CreatureBaseStats _gameStats;

        public CreatureBaseStats GameStats
        {
            get { return _gameStats ?? (_gameStats = CalculateGameStats(this)); }
        }

        public NpcTemplate()
        {
            Size = NpcSize.Medium;
            Race = NpcRace.None;
        }

        private static CreatureBaseStats CalculateGameStats(NpcTemplate template)
        {
            float hpRate = (60 + template.Level * 40) / 100f;
            float fullRate = (80 + template.Level*20)/100f;
            float smallRate = (95 + template.Level*5)/100f;

            if (template.Size == NpcSize.Small)
            {
                fullRate *= 0.25f;
                smallRate *= 0.25f;
            }
            else if (template.Size == NpcSize.Large)
            {
                fullRate *= 1.75f;
                smallRate *= 1.75f;
            }

            return
                new CreatureBaseStats
                    {
                        HpBase = (int) (700*hpRate*template.Size.GetHashCode()),
                        MpBase = (int) (1000*fullRate),
                        
                        Attack = (int) (140*fullRate),
                        Defense = (int) (40*fullRate),
                        Impact = (int)(30 * smallRate),
                        Balance = (int)(30 * smallRate),
                        CritChanse = (int) (40*smallRate),
                        CritResist = (int) (20*smallRate),
                        CritPower = 2,

                        Power = (int) (65*smallRate),
                        Endurance = (int) (50*smallRate),
                        ImpactFactor = (int) (50*smallRate),
                        BalanceFactor = (int)(50 * smallRate),
                        AttackSpeed = 100,
                        Movement = 100,

                        WeakeningResist = 40,
                        PeriodicResist = 40,
                        StunResist = 40
                    };
        }

        public override string ToString()
        {
            return Level + " : " + Name;
        }
    }
}