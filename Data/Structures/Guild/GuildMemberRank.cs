namespace Data.Structures.Guild
{
    [ProtoBuf.ProtoContract]
    public class GuildMemberRank
    {
        [ProtoBuf.ProtoMember(1)]
        public int RankId;

        [ProtoBuf.ProtoMember(2)]
        public int RankPrivileges;

        [ProtoBuf.ProtoMember(50)]
        public string RankName;
    }
}
