using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskEscort : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public int TargetFullid;

        [ProtoBuf.ProtoMember(2)]
        public int[] TargetArea; //like 488,48800355

        [ProtoBuf.ProtoMember(3)]
        public short CounterOfEscort;

        [ProtoBuf.ProtoMember(4)]
        public string JournalText { get; set; }

        [ProtoBuf.ProtoMember(5)]
        public int[] Time { get; set; }

        [ProtoBuf.ProtoMember(101)]
        public bool IsDebug { get; set; }
    }
}
