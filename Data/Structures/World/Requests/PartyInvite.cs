using Data.Enums;

namespace Data.Structures.World.Requests
{
    /// <summary>
    /// This request is made when player asks someone to join a party.
    /// </summary>
    public class PartyInvite : Request
    {
        /// <summary>
        /// Create a new party invite
        /// </summary>
        /// <param name="target">Invited player</param>
        public PartyInvite(Player.Player target = null) : base(RequestType.PartyInvite, false, 0)
        {
            Target = target;
        }

        public override bool IsValid()
        {
            return Target != null;
        }
    }
}
