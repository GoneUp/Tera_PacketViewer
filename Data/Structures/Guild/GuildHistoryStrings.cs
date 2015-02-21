namespace Data.Structures.Guild
{
    public class GuildHistoryStrings
    {
        public static string[] AddNewRank(string groupName)
        {
            return new[] { "@guild:801", "GroupName", groupName };
        }

        public static string[] UserXInvitedUserY(string invited)
        {
            return new[] { "@guild:798", "UserName", invited };
        }
    }
}
