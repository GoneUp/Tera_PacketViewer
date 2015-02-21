using System.Collections.Generic;
using Data.Structures.Geometry;

namespace Data.Structures.World.Continent
{
    [ProtoBuf.ProtoContract]
    public class Area
    {
        [ProtoBuf.ProtoMember(1)]
        public int ContinentId;

        [ProtoBuf.ProtoMember(2)]
        public int NameId;

        [ProtoBuf.ProtoMember(3)]
        public string AreaName;

        [ProtoBuf.ProtoMember(4)]
        public int WorldMapGuardId;

        [ProtoBuf.ProtoMember(5)]
        public int WorldMapWorldId;

        [ProtoBuf.ProtoMember(6)]
        public List<KeyValuePair<int, int>> Zones; // KeyValuePair(x, y)

        [ProtoBuf.ProtoMember(7)]
        public Polygon Polygon;

        [ProtoBuf.ProtoMember(50)]
        public List<Section> Sections;
    }
}
