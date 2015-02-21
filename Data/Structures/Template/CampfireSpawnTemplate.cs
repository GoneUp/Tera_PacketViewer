using Data.Structures.World;

namespace Data.Structures.Template
{
    [ProtoBuf.ProtoContract]
    public class CampfireSpawnTemplate
    {
        [ProtoBuf.ProtoMember(1)]
        public int Type { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public WorldPosition Position { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int Status { get; set; }
    }
}