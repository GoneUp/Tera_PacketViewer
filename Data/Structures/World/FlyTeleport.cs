namespace Data.Structures.World
{
    [ProtoBuf.ProtoContract]
    public class FlyTeleport
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id;

        [ProtoBuf.ProtoMember(2)]
        public string NpcName = "";

        [ProtoBuf.ProtoMember(3)]
        public int Level;

        [ProtoBuf.ProtoMember(4)]
        public int Cost;

        [ProtoBuf.ProtoMember(5)]
        public int FromNameId;

        [ProtoBuf.ProtoMember(6)]
        public int ToNameId;

        [ProtoBuf.ProtoMember(7)]
        public int Steps1;

        [ProtoBuf.ProtoMember(8)]
        public int Steps2;

        [ProtoBuf.ProtoMember(9)]
        public int BindMapId;

        [ProtoBuf.ProtoMember(10)]
        public float BindX;

        [ProtoBuf.ProtoMember(11)]
        public float BindY;

        [ProtoBuf.ProtoMember(12)]
        public float BindZ;
    }
}