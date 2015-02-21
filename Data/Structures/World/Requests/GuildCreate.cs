using Data.Enums;

namespace Data.Structures.World.Requests
{
    /// <summary>
    /// Create a guild.
    /// </summary>
    public class GuildCreate : Request
    {
        public string GuildName;

        /// <summary>
        /// Create new request for creating a guild.
        /// </summary>
        /// <param name="guildName"> </param>
        /// <param name="target">Who to invite</param>
        public GuildCreate(string guildName, Player.Player target = null)
            : base(RequestType.GuildCreate, true, 0)
        {
            Target = target;
            GuildName = guildName;
        }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(GuildName))
                return false;

            if (Owner.Inventory.Money < 3000)
                return false;

            if (Owner.Party == null || Owner.Party.PartyMembers.Count == 0)
                return false;

            return true;
        }
    }
}
