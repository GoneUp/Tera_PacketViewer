using System;
using Utils;

namespace Data.Structures.World
{
    public class Request
    {
        public Player.Player Requester;
        public Player.Player Requested;
        public int RequestUid = (int)DateTime.Now.Ticks;
        public short RequestType;
        public long Utc = Funcs.GetCurrentMilliseconds();
        public string GuildName;
    }
}
