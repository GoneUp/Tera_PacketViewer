using System.Collections.Generic;

namespace Data.Structures.SkillEngine
{
    [ProtoBuf.ProtoContract]
    public class ChargingStageList
    {
        //movingAnimName

        //waitAnimName

        [ProtoBuf.ProtoMember(3)]
        public bool Movable { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public int CostTotalHp { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int CostTotalMp { get; set; }

        [ProtoBuf.ProtoMember(6)]
        public List<ChargeStage> ChargeStageList { get; set; }

        [ProtoBuf.ProtoMember(7)]
        public float IntervalCostHpRate { get; set; }

        [ProtoBuf.ProtoMember(8)]
        public float IntervalCostMpRate { get; set; }


        public ChargingStageList()
        {
            ChargeStageList = new List<ChargeStage>();
        }
    }
}
