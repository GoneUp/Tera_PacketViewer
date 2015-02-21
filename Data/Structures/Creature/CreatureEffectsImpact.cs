using Data.Enums;

namespace Data.Structures.Creature
{
    public class CreatureEffectsImpact
    {
        public bool IsBlockFrontAttacks;

        //Power
        public int ChangeOfPower { get; private set; }

        //Endurance
        public int ChangeOfEndurance { get; private set; }

        //ImpactFactor
        public short ChangeOfImpactFactor { get; private set; }

        //BalanceFactor
        public short ChangeOfBalanceFactor { get; private set; }

        //Movement
        public short ChangeOfMovement { get; private set; }
        public short MovementModificator;
        public float MovementPercentModificator;

        //AttackSpeed
        public short ChangeOfAttackSpeed { get; private set; }
        public short AttackSpeedModificator;
        public float AttackSpeedPercentModificator;

        public void ResetChanges(Creature creature)
        {
            IsBlockFrontAttacks = false;

            //Power
            ChangeOfPower = 0;

            //Endurance
            ChangeOfEndurance = 0;

            //ImpactFactor
            ChangeOfImpactFactor = 0;

            //BalanceFactor
            ChangeOfBalanceFactor = 0;

            //Movement
            ChangeOfMovement = 0;
            MovementModificator = 0;
            MovementPercentModificator = 0;

            //AttackSpeed
            ChangeOfAttackSpeed = 0;
            AttackSpeedModificator = 0;
            AttackSpeedPercentModificator = 0;

            Player.Player player = creature as Player.Player;
            if (player != null)
            {
                MovementModificator += player.MovementByAdminCommand;

                if (player.PlayerMode != PlayerMode.Armored && player.Mount == 0)
                    MovementModificator += (short) (170 - player.GameStats.Movement);

                if (player.Attack != null && !player.Attack.IsFinished
                    && player.Attack.Args.GetSkill(player).BaseId == 20100
                    && (player.PlayerData.Class == PlayerClass.Berserker || player.PlayerData.Class == PlayerClass.Lancer))
                {
                    IsBlockFrontAttacks = true;
                }
            }

            creature.Effects.ForEach(effect => effect.SetImpact(this));

            ChangeOfMovement = (short)(MovementModificator +
                                        creature.GameStats.Movement * MovementPercentModificator);

            ChangeOfAttackSpeed = (short)(AttackSpeedModificator +
                                           creature.GameStats.AttackSpeed * AttackSpeedPercentModificator);
        }

        public void ApplyChanges(CreatureBaseStats gameStats)
        {
            gameStats.Power += ChangeOfPower;
            gameStats.Endurance += ChangeOfEndurance;
            gameStats.ImpactFactor += ChangeOfImpactFactor;
            gameStats.BalanceFactor += ChangeOfBalanceFactor;
            gameStats.Movement += ChangeOfMovement;
            gameStats.AttackSpeed += ChangeOfAttackSpeed;
        }
    }
}
