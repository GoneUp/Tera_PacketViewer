using Data.Interfaces;

namespace Data.Structures.Quest.Tasks
{
    [ProtoBuf.ProtoContract]
    public class QTaskNotImpliment : IQuestStep
    {
        [ProtoBuf.ProtoMember(1)]
        public string Description { get; set; }
    }
}
