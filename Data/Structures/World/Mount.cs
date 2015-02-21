namespace Data.Structures.World
{
    [ProtoBuf.ProtoContract]
    public class Mount
    {
        [ProtoBuf.ProtoMember(1)]
        public int SkillId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int MountId { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(50)]
        public int SpeedModificator { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
