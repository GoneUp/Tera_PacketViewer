namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class ProjectileSkill
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int DetachAngle { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int DetachDistance { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int DetachHeight { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public float FlyingDistance { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public int ShootAngle { get; set; }
    }
}
