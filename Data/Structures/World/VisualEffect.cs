using System.Collections.Generic;
using Data.Enums;

namespace Data.Structures.World
{
    public class VisualEffect
    {
        public VisualEffectType Type;

        public List<int> Times = new List<int>();

        public WorldPosition Position;

        public void Release()
        {
            Position = null;
        }
    }
}