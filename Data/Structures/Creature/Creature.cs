using System.Collections.Generic;
using Data.Enums;
using Data.Interfaces;
using Data.Structures.Objects;
using Data.Structures.SkillEngine;
using Data.Structures.World;

namespace Data.Structures.Creature
{
    public abstract class Creature : TeraObject
    {
        public List<Player.Player> VisiblePlayers = new List<Player.Player>();
        public List<Npc.Npc> VisibleNpcs = new List<Npc.Npc>();
        public List<Item> VisibleItems = new List<Item>();
        public List<Gather.Gather> VisibleGathers = new List<Gather.Gather>();
        public List<Projectile> VisibleProjectiles = new List<Projectile>();
        public List<Campfire> VisibleCampfires = new List<Campfire>();

        public List<Player.Player> ObserversList = new List<Player.Player>();

        public IAi Ai;

        private CreatureLifeStats _lifeStats;

        public CreatureLifeStats LifeStats
        {
            get { return _lifeStats ?? (_lifeStats = new CreatureLifeStats(this)); }
        }

        public CreatureBaseStats GameStats;

        public int MaxHp
        {
            get { return (int) (GameStats.HpBase + GameStats.HpStamina*(LifeStats.Stamina/120.0)); }
        }

        public int MaxMp
        {
            get { return (int) (GameStats.MpBase + GameStats.MpStamina*(LifeStats.Stamina/120.0)); }
        }

        public Attack Attack;

        public WorldPosition Position;
        public WorldPosition BindPoint;
        public MapInstance Instance;

        public Creature Target;

        public CreatureState CurrentState = CreatureState.Standing;

        public short AttackAngle;

        public VisualEffect VisualEffect;

        public List<Abnormal> Effects = new List<Abnormal>();

        public object EffectsLock = new object();

        public CreatureEffectsImpact EffectsImpact = new CreatureEffectsImpact();

        public abstract int GetLevel();

        public abstract int GetModelId();

        private int _bodyRadius;

        public int BodyRadius
        {
            get
            {
                if (_bodyRadius == 0)
                {
                    _bodyRadius = 45;

                    var npc = this as Npc.Npc;
                    if (npc != null)
                    {
                        switch (npc.NpcTemplate.Size)
                        {
                            case NpcSize.Small:
                                _bodyRadius = 30;
                                break;
                            case NpcSize.Medium:
                                _bodyRadius = 50;
                                break;
                            case NpcSize.Large:
                                _bodyRadius = 150;
                                break;
                        }
                    }
                }

                return _bodyRadius;
            }
        }

        public override void Release()
        {
            if (ObserversList != null)
                ObserversList.Clear();
            ObserversList = null;

            VisiblePlayers = null;
            VisibleNpcs = null;
            VisibleItems = null;
            VisibleGathers = null;

            if (Ai != null)
                Ai.Release();
            Ai = null;

            if (_lifeStats != null)
                _lifeStats.Release();
            _lifeStats = null;

            GameStats = null;

            Position = null;
            BindPoint = null;
            Instance = null;

            Target = null;

            if (VisualEffect != null)
                VisualEffect.Release();
            VisualEffect = null;

            if (Effects != null)
                for (int i = 0; i < Effects.Count; i++)
                    Effects[i].Release();
            Effects = null;
            EffectsLock = null;

            base.Release();
        }
    }
}