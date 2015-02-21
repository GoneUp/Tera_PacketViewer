namespace Data.Structures.World
{
    public class Campfire : Creature.Creature
    {
        public bool IsStationary = false;

        public int Type;

        public int Status;

        public long DespawnUts;

        public override int GetLevel()
        {
            throw new System.NotImplementedException();
        }

        public override int GetModelId()
        {
            throw new System.NotImplementedException();
        }
    }
}
