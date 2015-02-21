using System.Collections.Generic;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class SkillAction
    {
        [ProtoBuf.ProtoMember(1)]
        public int FrontCancelEndTime { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public int RearCancelStartTime { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public int MoveCancelStartTime { get; set; }

        //MoveInvincible

        //SpecialEffectList

        //HitCylinderList

        //MoveCylinderList

        [ProtoBuf.ProtoMember(8)]
        public List<ActionStage> StageList { get; set; }

        [ProtoBuf.ProtoMember(9)]
        public int PendingStartTime { get; set; }

        //CameraShakeList

        //CameraType
    }
}
