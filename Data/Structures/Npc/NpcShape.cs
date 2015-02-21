namespace Data.Structures.Npc
{
    [ProtoBuf.ProtoContract]
    public class NpcShape
    {
        [ProtoBuf.ProtoMember(1)]
        public int RunSpeed;

        [ProtoBuf.ProtoMember(2)]
        public int TurnSpeed;

        [ProtoBuf.ProtoMember(3)]
        public int WalkSpeed;
    }
}
