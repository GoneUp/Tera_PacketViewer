using System.Collections.Generic;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Communication.Interfaces
{
    public interface ISkillsLearnService : IComponent
    {
        void Init();
        List<UserSkill> GetSkillLearnList(Player player);
        void BuySkill(Player player, int skillId, bool isActive);
        void LearnMountSkill(Player player, int skillId);
        void UseSkillBook(Player player, int bookId);
    }
}