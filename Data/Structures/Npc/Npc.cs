using System.Collections.Generic;
using Data.Structures.Template;

namespace Data.Structures.Npc
{
    public class Npc : Creature.Creature
    {
        public int NpcId;

        public SpawnTemplate SpawnTemplate;

        public NpcTemplate NpcTemplate;

        public Npc ParentNpc;
        public List<Npc> Childs = new List<Npc>();

        public List<Npc> NamesList;

        public override int GetLevel()
        {
            return NpcTemplate == null ? 1 : NpcTemplate.Level;
        }

        public override int GetModelId()
        {
            return NpcTemplate.Id;
        }

        public override void Release()
        {
            if (NamesList != null)
            {
                NamesList.Remove(this);
                NamesList = null;
            }

            base.Release();
        }

        public Npc Clone()
        {
            Npc clone = new Npc
                            {
                                NpcId = NpcId,
                                SpawnTemplate = SpawnTemplate,
                                NpcTemplate = NpcTemplate,
                                Position = Position.Clone(),
                                BindPoint = BindPoint.Clone(),
                            };

            return clone;
        }
    }
}