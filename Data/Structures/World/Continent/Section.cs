using System.Collections.Generic;
using Data.Structures.Geometry;

namespace Data.Structures.World.Continent
{
    [ProtoBuf.ProtoContract]
    public class Section
    {
        [ProtoBuf.ProtoMember(1)]
        public int Priority;

        [ProtoBuf.ProtoMember(2)]
        public int HuntingZoneId;

        [ProtoBuf.ProtoMember(3)]
        public int AddMaxZ;

        [ProtoBuf.ProtoMember(4)]
        public int CampId;

        [ProtoBuf.ProtoMember(5)]
        public bool Destext;

        [ProtoBuf.ProtoMember(6)]
        public int NameId;

        [ProtoBuf.ProtoMember(7)]
        public bool PcMoveCylinder;

        [ProtoBuf.ProtoMember(8)]
        public bool PcSafe;

        [ProtoBuf.ProtoMember(9)]
        public bool RestBonus;

        [ProtoBuf.ProtoMember(10)]
        public int SubtractMinZ;

        [ProtoBuf.ProtoMember(11)]
        public bool Vender;

        [ProtoBuf.ProtoMember(12)]
        public int WorldMapSectionId;

        [ProtoBuf.ProtoMember(13)]
        public int Floor;

        [ProtoBuf.ProtoMember(14)]
        public List<Section> Sections;

        [ProtoBuf.ProtoMember(15)]
        public string Name = "Unk";

        [ProtoBuf.ProtoMember(50)]
        public Polygon Polygon;

        public bool IsParent()
        {
            return Sections != null;
        }

    }
}
