using System.Collections.Generic;
using Data.Structures.SkillEngine;
using Data.Structures.World;

namespace Data.Structures.Player
{
    public class UseSkillArgs
    {
        public int SkillId;

        public bool IsItemSkill = false;

        public bool IsTargetAttack = false;

        public bool IsDelaySkill = false;

        public bool IsChargeSkill = true;

        public bool IsDelayStart;

        public WorldPosition StartPosition = new WorldPosition();
        public WorldPosition TargetPosition = new WorldPosition();

        public List<Creature.Creature> Targets = new List<Creature.Creature>();

        public Skill GetSkill(Player player)
        {
            if (IsItemSkill && Data.Skills[0][9999].ContainsKey(SkillId))
                return Data.Skills[0][9999][SkillId];

            if (Data.Skills[0][player.TemplateId].ContainsKey(SkillId))
                return Data.Skills[0][player.TemplateId][SkillId];

            return null;
        }

        public void AddTarget(long uniqueId)
        {
            Creature.Creature creature = Uid.GetObject(uniqueId) as Creature.Creature;

            if (creature != null)
                Targets.Add(creature);
        }

        public void Release()
        {
            StartPosition = null;
            TargetPosition = null;

            if (Targets != null)
                Targets.Clear();
            Targets = null;
        }
    }
}
