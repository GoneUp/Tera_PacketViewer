using System.Collections.Generic;

namespace Data.Structures.World
{
    [ProtoBuf.ProtoContract]
    public class Tradelist
    {
        [ProtoBuf.ProtoMember(1)]
        public int FullId;

        [ProtoBuf.ProtoMember(2)]
        public Dictionary<int, List<int>> ItemsByTabs = new Dictionary<int, List<int>>();
    }
}