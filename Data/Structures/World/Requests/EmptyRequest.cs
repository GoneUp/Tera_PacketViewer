using Data.Enums;

namespace Data.Structures.World.Requests
{
    /// <summary>
    /// Optional request like SkillLearn
    /// </summary>
    public class EmptyRequest : Request
    {
        public EmptyRequest(Player.Player owner, RequestType requestType)
            : base(requestType, false)
        {
            Owner = owner;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
