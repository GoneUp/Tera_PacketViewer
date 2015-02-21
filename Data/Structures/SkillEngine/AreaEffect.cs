using System.Collections.Generic;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class AreaEffect
    {
        [ProtoBuf.ProtoMember(1)]
        public int Id { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int PosX { get; set; }
        
        [ProtoBuf.ProtoMember(3)]
        public int PosY { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int PosZ { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int StartTime { get; set; }

        //MoveDistance

        //MoveDuration

        //MovMaxHeight

        [ProtoBuf.ProtoMember(9)]
        public float AbnormalityRate { get; set; }

        [ProtoBuf.ProtoMember(10)]
        public float Atk { get; set; }

        [ProtoBuf.ProtoMember(11)]
        public int HpDiff { get; set; }

        [ProtoBuf.ProtoMember(12)]
        public int MpDiff { get; set; }

        //Teleport

        [ProtoBuf.ProtoMember(14)]
        public List<int> AbnormalityOnCommon { get; set; }

        [ProtoBuf.ProtoMember(15)]
        public int AbnormalityOnPvP { get; set; }
    }
}
