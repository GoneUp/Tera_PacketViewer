namespace Data.Structures.Creature
{
    public class CreatureLifeStats
    {
        public Creature Creature;

        public bool SendUpdate = true;

        private int _hp;

        public int Hp
        {
            get { return _hp; }
        }

        private int _mp;

        public int Mp
        {
            get { return _mp; }
        }

        public int Stamina = 100;

        public bool IsDead()
        {
            if (Hp <= 0)
                return true;

            return false;
        }

        public CreatureLifeStats(Creature creature)
        {
            _hp = creature.GameStats.HpBase + creature.GameStats.HpStamina;
            _mp = creature.GameStats.MpBase + creature.GameStats.MpStamina;

            Creature = creature;
        }

        public int PlusHp(int value)
        {
            _hp += value;

            if (_hp > Creature.MaxHp)
            {
                value -= _hp - Creature.MaxHp;
                _hp = Creature.MaxHp;
            }

            return value;
        }

        public int GetHpDiffResult(int value)
        {
            return _hp - value;
        }

        public int MinusHp(int value)
        {
            _hp -= value;

            if (_hp < 0)
            {
                value += _hp;
                _hp = 0;
            }

            return -value;
        }

        public int PlusMp(int value)
        {
            _mp += value;

            if (_mp > Creature.MaxMp)
            {
                value -= _mp - Creature.MaxMp;
                _mp = Creature.MaxMp;
            }

            return value;
        }

        public int MinusMp(int value)
        {
            _mp -= value;

            if (_mp < 0)
            {
                value += _mp;
                _mp = 0;
            }

            return -value;
        }

        public int PlusStamina(int value)
        {
            Stamina += value;

            if (Stamina > 120)
            {
                value -= Stamina - 120;
                Stamina = 120;
            }

            return value;
        }

        public int MinusStamina(int value)
        {
            Stamina -= value;

            if (Stamina < 0)
            {
                value += Stamina;
                Stamina = 0;
            }

            return -value;
        }

        public void Kill()
        {
            _hp = 0;
            _mp = 0;
            if(Stamina >= 10)
                Stamina -= 10;
            else
                Stamina = 0;
        }

        public void Rebirth()
        {
            _hp = Creature.GameStats.HpBase + Creature.GameStats.HpStamina;
            _mp = Creature.GameStats.MpBase + Creature.GameStats.MpStamina;

            if (Creature is Npc.Npc)
                return;

            _hp /= 10;
            _mp /= 10;
        }

        public CreatureLifeStats Clone()
        {
            return (CreatureLifeStats) MemberwiseClone();
        }

        public void Release()
        {
            Creature = null;
        }
    }
}