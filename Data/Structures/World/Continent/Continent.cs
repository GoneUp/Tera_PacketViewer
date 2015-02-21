using System.Collections.Generic;

namespace Data.Structures.World.Continent
{
    [ProtoBuf.ProtoContract]
    public class Continent
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id;

        [ProtoBuf.ProtoMember(2)]
        public string Description;

        [ProtoBuf.ProtoMember(3)]
        public int OriginZoneX;

        [ProtoBuf.ProtoMember(4)]
        public int OriginZoneY;

        [ProtoBuf.ProtoMember(50)]
        public List<Area> Areas;
    }
}
