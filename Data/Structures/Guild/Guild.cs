using System;
using System.Collections.Generic;
using Data.Enums.Item;
using Data.Structures.Player;

namespace Data.Structures.Guild
{
    [ProtoBuf.ProtoContract]
    public class Guild
    {
        [ProtoBuf.ProtoMember(1)]
        public int GuildId = (int)DateTime.Now.Ticks;

        [ProtoBuf.ProtoMember(2)]
        public string GuildName;

        [ProtoBuf.ProtoMember(3)]
        public List<GuildMemberRank> GuildRanks;

        [ProtoBuf.ProtoMember(4)]
        public string GuildLogo;

        [ProtoBuf.ProtoMember(5)]
        public List<HistoryEvent> GuildHistory;

        [ProtoBuf.ProtoMember(6)]
        public Storage GuildWarehouse = new Storage{StorageType = StorageType.GuildWarehouse};

        [ProtoBuf.ProtoMember(7)]
        public int Level = 1;

        [ProtoBuf.ProtoMember(8)]
        public string GuildAd = "";

        [ProtoBuf.ProtoMember(9)]
        public string GuildTitle = "";

        [ProtoBuf.ProtoMember(10)]
        public string GuildMessage = "";

        [ProtoBuf.ProtoMember(11)]
        public int Praises = 0;

        [ProtoBuf.ProtoMember(50)]
        public int CreationDate;

        public Dictionary<Player.Player, int> GuildMembers = new Dictionary<Player.Player, int>();



        public object MembersLock = new object();
    }

}
