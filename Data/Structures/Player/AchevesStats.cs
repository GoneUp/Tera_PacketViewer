namespace Data.Structures.Player
{
    [ProtoBuf.ProtoContract]
    public class AchivesStats
    {
        [ProtoBuf.ProtoMember(1)]
        public int DuelWon;

        [ProtoBuf.ProtoMember(200)]
        public int ItemLooted;
    }
}
