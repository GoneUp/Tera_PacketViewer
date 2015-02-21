using System.Linq;
using Data;
using Data.Interfaces;
using Data.Structures.Player;
using Utils;

namespace Communication.Logic
{
    public class AccountLogic : Global
    {
        public const int LogoutTimeout = 1; //TODO: 10

        public static void TryAuthorize(IConnection connection, string accountName, string session)
        {
            //TODO: Session check
            AccountService.Authorized(connection, accountName);
            FeedbackService.OnAuthorized(connection);
            InformerService.OnAccountAuthed(accountName);
        }

        public static void GetPlayerList(IConnection connection)
        {
            FeedbackService.SendPlayerList(connection);
        }

        public static void ClientDisconnected(IConnection connection)
        {
            if (connection.Account != null)
                InformerService.OnAccountDiconnected(connection.Account.Name);

            if (connection.Account != null && connection.Player != null)
            {
                Player player = connection.Player;
                new DelayedAction(() => PlayerLogic.PlayerEndGame(player), LogoutTimeout*1000);
            }
        }

        public static void RelogPlayer(IConnection connection)
        {
            AccountService.AbortExitAction(connection);
            FeedbackService.ShowRelogWindow(connection, LogoutTimeout);

            connection.Account.ExitAction = new DelayedAction(
                () =>
                    {
                        FeedbackService.Relog(connection);
                        PlayerLogic.PlayerEndGame(connection.Player);
                    }, LogoutTimeout * 1000);
        }

        public static void RemovePlayer(IConnection connection, int playerId)
        {
            Player p = connection.Account.Players.FirstOrDefault(player => player.PlayerId == playerId);

            if(p == null)
                return;

            if (Cache.UsedNames.Contains(p.PlayerData.Name.ToLower()))
                Cache.UsedNames.Remove(p.PlayerData.Name.ToLower());

            PartyService.LeaveParty(p);
            GuildService.LeaveGuild(p, p.Guild);
            connection.Account.Players.Remove(connection.Account.Players.FirstOrDefault(player => player.PlayerId == playerId));
            FeedbackService.SendCharRemove(connection);
        }

        public static void ExitPlayer(IConnection connection)
        {
            AccountService.AbortExitAction(connection);
            FeedbackService.ShowExitWindow(connection, LogoutTimeout);

            connection.Account.ExitAction = new DelayedAction(
                () =>
                {
                    FeedbackService.Exit(connection);
                    PlayerLogic.PlayerEndGame(connection.Player);
                }, LogoutTimeout * 1000);
        }

        public static void AbortExitAction(IConnection connection)
        {
            if (connection.Account.ExitAction != null)
                connection.Account.ExitAction.Abort();
        }
    }
}