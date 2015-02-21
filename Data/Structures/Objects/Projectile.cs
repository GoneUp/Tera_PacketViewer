using System;
using Data.Structures.Creature;
using Data.Structures.SkillEngine;
using Data.Structures.World;

namespace Data.Structures.Objects
{
    public class Projectile : Creature.Creature
    {
        public Skill Skill = null;

        public int SkillId;

        public ProjectileSkill ProjectileSkill;

        public WorldPosition TargetPosition;

        public int Speed = 100;

        public int Lifetime;

        public float AttackDistance = 10;

        public Projectile(Creature.Creature owner, ProjectileSkill projectileSkill)
        {
            Player.Player player = owner as Player.Player;
            Npc.Npc npc = owner as Npc.Npc;

            Parent = owner;
            
            if (npc != null)
            {
                TargetPosition = new WorldPosition();
                npc.Target.Position.CopyTo(TargetPosition);
            }
            else
                TargetPosition = owner.Attack.Args.TargetPosition;

            Position = new WorldPosition
                           {
                               Heading = owner.Position.Heading,
                               X = owner.Position.X,
                               Y = owner.Position.Y,
                               Z = owner.Position.Z + projectileSkill.DetachHeight,
                           };

            double angle = Position.Heading * Math.PI / 32768;

            Position.X += projectileSkill.DetachDistance * (float)Math.Cos(angle);
            Position.Y += projectileSkill.DetachDistance * (float)Math.Sin(angle);

            Instance = owner.Instance;
            ProjectileSkill = projectileSkill;
            GameStats = new CreatureBaseStats {HpBase = 1};

            if (player != null)
            {
                Skill = Data.Skills[0][player.TemplateId][ProjectileSkill.Id];
                SkillId = Skill.Id;
            }
            else if (npc != null)
            {
                Skill = Data.Skills[npc.NpcTemplate.HuntingZoneId][npc.NpcTemplate.Id][ProjectileSkill.Id];
                SkillId = Skill.Id + 0x40000000 + (npc.NpcTemplate.HuntingZoneId << 16);
            }

            Lifetime = Skill.ProjectileData.LifeTime != 0
                           ? Skill.ProjectileData.LifeTime
                           : 1000;

            if (projectileSkill.FlyingDistance <= 0f)
                TargetPosition = null;
            else if (Skill != null)
            {
                if (TargetPosition.IsNull())
                {
                    TargetPosition = Position.Clone();

                    TargetPosition.X += projectileSkill.FlyingDistance * (float)Math.Cos(angle);
                    TargetPosition.Y += projectileSkill.FlyingDistance * (float)Math.Sin(angle);
                }

                Speed = (int) (projectileSkill.FlyingDistance*1000/Lifetime);
            }

            if (Skill != null)
            {
                if (Skill.TargetingList != null)
                {
                    for (int i = 0; i < Skill.TargetingList.Count; i++)
                    {
                        if (Skill.TargetingList[i].AreaList == null)
                            continue;

                        for (int j = 0; j < Skill.TargetingList[i].AreaList.Count; j++)
                        {
                            if (Skill.TargetingList[i].AreaList[j].MaxRadius > AttackDistance)
                            {
                                AttackDistance = Skill.TargetingList[i].AreaList[j].MaxRadius;
                                return;
                            }
                        }
                    }
                }
            }
        }

        public override int GetLevel()
        {
            return 1;
        }

        public override int GetModelId()
        {
            return ((Creature.Creature) Parent).GetModelId();
        }

        public override void Release()
        {
            base.Release();
            ProjectileSkill = null;
            TargetPosition = null;
        }
    }
}