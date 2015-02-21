using System.Collections.Generic;
using Data.Enums;

namespace Data.Structures.Quest
{
    [ProtoBuf.ProtoContract]
    public class QuestData
    {
        [ProtoBuf.ProtoMember(1)]
        public int QuestId;

        [ProtoBuf.ProtoMember(2)]
        public QuestStatus Status = QuestStatus.Start;

        [ProtoBuf.ProtoMember(3)]
        public int Step = 0;

        [ProtoBuf.ProtoMember(4)]
        public List<int> Counters;

        //For ProtoBuf load
        private QuestData()
        {
            
        }

        public QuestData(int questId)
        {
            QuestId = questId;
            Counters = new List<int>(1) { 0 };
        }
    }
}
