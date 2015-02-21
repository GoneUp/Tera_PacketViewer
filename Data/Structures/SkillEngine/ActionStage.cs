using System.Collections.Generic;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class ActionStage
    {
        [ProtoBuf.ProtoMember(1)]
        public int ScriptId { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public bool Movable { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public List<AnimSeq> AnimationList;

        //Property
    }
}
