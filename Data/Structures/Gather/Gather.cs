using Data.Structures.Template;

namespace Data.Structures.Gather
{
    public class Gather : Creature.Creature
    {
        public int Id;
        public int CurrentGatherCounter = 1;
        public bool IsInProcess = false;

        public GatherTemplate GatherTemplate()
        {
            return Data.GatherTemplates[Id];
        }

        public override int GetLevel()
        {
            return 0;
        }

        public override int GetModelId()
        {
            return 0;
        }
    }
}