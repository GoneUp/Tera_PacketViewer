using Data.Enums;

namespace Data.Structures.World.Requests
{
    /// <summary>
    /// Invite to target player to a guild.
    /// </summary>
    public class GuildInvite : Request
    {
        /// <summary>
        /// Create new request for inviting player to a guild.
        /// </summary>
        /// <param name="target">Who to invite</param>
        public GuildInvite(Player.Player target = null)
            : base(RequestType.GuildInvite, false)
        {
            Target = target;
        }

        public override bool IsValid()
        {
            return Target != null;
        }
    }
}
