using System.Collections.Generic;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Objects;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Communication.Interfaces
{
    public interface ISkillEngine : IComponent
    {
        void Init();
        void UseSkill(IConnection connection, UseSkillArgs args);
        void UseSkill(IConnection connection, List<UseSkillArgs> argsList);
        void UseSkill(Npc npc, Skill skill);
        void MarkTarget(IConnection connection, Creature target, int skillId);
        void ReleaseAttack(Player player, int attackUid, int type);
        void UseProjectileSkill(Projectile projectile);
        void AttackFinished(Creature creature);
    }
}