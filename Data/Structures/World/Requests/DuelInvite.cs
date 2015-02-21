using Data.Enums;

namespace Data.Structures.World.Requests
{
    /// <summary>
    /// This request is made when player asks someone to start a duel.
    /// </summary>
    public class DuelInvite : Request
    {
        /// <summary>
        /// Create a new duel invite
        /// </summary>
        /// <param name="target">Invited player</param>
        public DuelInvite(Player.Player target = null)
            : base(RequestType.DuelInvite, true)
        {
            Target = target;
        }

        public override bool IsValid()
        {
            return Target != null;
        }
    }
}
