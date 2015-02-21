namespace Data.Structures.Guild
{
    [ProtoBuf.ProtoContract]
    public class HistoryEvent
    {
        [ProtoBuf.ProtoMember(1)]
        public string Initiator;

        [ProtoBuf.ProtoMember(2)]
        public int Date;

        [ProtoBuf.ProtoMember(50)]
        public string[] Args;
    }
}
