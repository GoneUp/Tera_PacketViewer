using Data.Structures.Creature;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Communication.Logic
{
    public class AiLogic : Global
    {
        public static void InitAi(Creature creature)
        {
            creature.Ai = AiService.CreateAi(creature);
            creature.Ai.Init(creature);
        }

        public static void OnUseSkill(Creature creature, Skill skill)
        {
            creature.Ai.OnUseSkill(skill);
        }

        public static void OnAttack(Creature creature, Creature target)
        {
            creature.Ai.OnAttack(target);

            Player player = creature as Player;
            if (player != null)
                ObserverService.AddObserved(player, target);
        }

        public static void OnAttacked(Creature creature, Creature attacker, int damage)
        {
            creature.Ai.OnAttacked(attacker, damage);
        }
    }
}
