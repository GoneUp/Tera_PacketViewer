using System.Collections.Generic;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class Animation
    {
        [ProtoBuf.ProtoMember(1)]
        public int Duraction { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int Dir { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public List<float> Distance { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public bool RootMotion { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public bool RootRotate { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public int RotateYaw { get; set; }

        public Animation()
        {
            Distance = new List<float>(7);
        }
    }
}