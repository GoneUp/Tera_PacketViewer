namespace Data.Structures.World
{
    [ProtoBuf.ProtoContract]
    public class GeoPoint
    {
        [ProtoBuf.ProtoMember(1)]
        public float X;
        [ProtoBuf.ProtoMember(2)]
        public float Y;
        [ProtoBuf.ProtoMember(3)]
        public float Z;
    }
}