namespace Data.Structures.World
{
    public class Item : Creature.Creature
    {
        public Player.Player Owner;
        public Npc.Npc Npc;

        public int ItemId;
        public int Count;

        public int WorkParam;

        public override int GetLevel()
        {
            return -1;
        }

        public override int GetModelId()
        {
            return -1;
        }
    }
}