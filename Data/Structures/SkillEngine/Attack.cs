using System;
using Data.Enums;
using Data.Structures.Player;
using Utils;

namespace Data.Structures.SkillEngine
{
    public class Attack : Uid
    {
        public UseSkillArgs Args;

        public int Stage = 0;
        public float Speed = 1f;

        protected AttackStatus Status = AttackStatus.Init;

        public long StartUtc = Funcs.GetCurrentMilliseconds();

        public Creature.Creature Creature;

        protected Action OnStageEnd;
        protected Action OnFinish;

        public Attack(Creature.Creature creature, UseSkillArgs args, Action onStageEnd, Action onFinish)
        {
            if (creature.Attack != null)
                creature.Attack.Release();

            Args = args;

            Creature = creature;
            OnStageEnd = onStageEnd;
            OnFinish = onFinish;
        }

        public bool IsFinished
        {
            get { return Status == AttackStatus.Finished; }
        }

        public AttackStatus GetStatus()
        {
            return Status;
        }

        public void Inited()
        {
            Status = AttackStatus.Inited;
        }

        public void Wait()
        {
            Status = AttackStatus.Wait;
        }

        public void Process()
        {
            Status = /*Handler.IsDelay ? AttackStatus.Delay : */AttackStatus.Process;
        }

        public void Charge()
        {
            Status = AttackStatus.Charge;
        }

        public void NextStage()
        {
            if (OnStageEnd != null)
            {
                Stage++;
                OnStageEnd();

                //if (!Args.IsDelaySkill)
                    //Uid = 0;
            }
        }

        public void Finish()
        {
            if (Status == AttackStatus.Finished)
                return;

            Status = AttackStatus.Finished;

            if (OnFinish != null)
                OnFinish.Invoke();
        }

        public override void Release()
        {
            base.Release();

            if (Creature == null)
                return;

            if (Args != null)
                Args.Release();
            Args = null;

            Creature = null;
            OnStageEnd = null;
            OnFinish = null;
        }
    }
}
