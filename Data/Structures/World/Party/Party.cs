using System.Collections.Generic;

namespace Data.Structures.World.Party
{
    public class Party
    {
        public List<Player.Player> PartyMembers;
        public object MemberLock = new object();
        public long Exp;
    }
}
