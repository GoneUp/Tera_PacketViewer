namespace Data.Structures.Template
{
    [ProtoBuf.ProtoContract]
    public class SpawnTemplate
    {
        [ProtoBuf.ProtoMember(1)]
        public int NpcId;
        [ProtoBuf.ProtoMember(2)]
        public short Type;

        [ProtoBuf.ProtoMember(3)]
        public int MapId;
        [ProtoBuf.ProtoMember(4)]
        public float X;
        [ProtoBuf.ProtoMember(5)]
        public float Y;
        [ProtoBuf.ProtoMember(6)]
        public float Z;
        [ProtoBuf.ProtoMember(7)]
        public short Heading;

        public int FullId
        {
            get { return NpcId + Type * 100000; }
        }

        public SpawnTemplate Clone()
        {
            return (SpawnTemplate) MemberwiseClone();
        }
    }
}