using Data.Structures.Geometry;

namespace Data.Structures.World.Pegasus
{
    [ProtoBuf.ProtoContract]
    public class FlyStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int Time;

        [ProtoBuf.ProtoMember(2)]
        public int[] Rot;

        [ProtoBuf.ProtoMember(3)]
        public Point3D Loc;

        [ProtoBuf.ProtoMember(4)]
        public int State;

        [ProtoBuf.ProtoMember(50)]
        public int StateCounter;

    }
}
