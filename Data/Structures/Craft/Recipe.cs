using System.Collections.Generic;
using Data.Enums;
using Data.Enums.Craft;

namespace Data.Structures.Craft
{
    [ProtoBuf.ProtoContract]
    public class Recipe
    {
        [ProtoBuf.ProtoMember(1)]
        public int RecipeId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public KeyValuePair<int, int> ResultItem { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public KeyValuePair<int, int> CriticalResultItem { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public byte CriticalChancePercent { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public Dictionary<int, int> NeededItems { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public CraftStat CraftStat { get; set; }

        //[ProtoBuf.ProtoMember(7)]
        public int Level
        {
            get
            {
                if (ReqMin/50 == 0)
                    return 1;

                return ReqMin/50;
            }
        }

        [ProtoBuf.ProtoMember(8)]
        public short ReqMin { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public short ReqMax { get; set; }

        [ProtoBuf.ProtoMember(50)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
