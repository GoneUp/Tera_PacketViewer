using System.Collections.Generic;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.SkillEngine;
using Utils;

namespace Data.Structures.World
{
    public class Abnormal
    {
        public Creature.Creature Creature;
        public Creature.Creature Caster;

        public Abnormality Abnormality;

        public long TimeoutUts;
        
        public List<IEffect> Effects = new List<IEffect>();

        public int TimeRemain
        {
            get
            {
                int remain = (int) (TimeoutUts - Funcs.GetCurrentMilliseconds());
                if (remain < 0)
                    remain = 0;

                return remain;
            }
        }

        public Abnormal(Creature.Creature creature, Abnormality abnormality, Creature.Creature caster = null)
        {
            Creature = creature;
            Caster = caster ?? creature;
            Abnormality = abnormality;
            TimeoutUts = Funcs.GetCurrentMilliseconds() + abnormality.Time;
        }

        public void Release()
        {
            for (int i = 0; i < Effects.Count; i++)
                Effects[i].Release();
            Effects.Clear();
            Effects = null;

            Creature = null;
            Caster = null;
        }

        public void SetImpact(CreatureEffectsImpact impact)
        {
            Effects.ForEach(effect => effect.SetImpact(impact));
        }
    }
}
