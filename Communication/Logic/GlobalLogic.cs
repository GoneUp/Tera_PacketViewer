using System;
using System.Diagnostics;
using Data.Interfaces;
using Data.Structures.Account;
using Data.Structures.Creature;

namespace Communication.Logic
{
    public class GlobalLogic : Global
    {
        public static void ServerStart()
        {
            Data.Data.LoadAll();
            Data.Cache.LoadData();

            StatsService.Init();
            GeoService.Init();
            MapService.Init();
            QuestEngine.Init();
            SkillEngine.Init();
            ActionEngine.Init();
            SkillsLearnService.Init();
            AreaService.Init();
            GuildService.Init();

            InitMainLoop();
        }

        public static void OnServerShutdown()
        {
            Data.Cache.SaveData();
        }

        public static void PacketSent(Account account, string name, byte[] buffer)
        {
            if (account == null)
                return;

            const string callStack = "";
            /*StackTrace stackTrace = new StackTrace(true);
            var frames = stackTrace.GetFrames();

            if (frames != null)
                foreach (var frame in frames)
                    callStack += string.Format("{0}\n", frame);*/

            InformerService.PacketSent(account.Name, name, buffer, callStack);
        }

        public static void PacketReceived(Account account, Type type, byte[] buffer)
        {
            if (account == null)
                return;

            StackTrace stackTrace = new StackTrace(true);
            var frames = stackTrace.GetFrames();
            string callStack = "";

            if (frames != null)
                foreach (var frame in frames)
                    callStack += string.Format("{0}\n", frame);

            InformerService.PacketReceived(account.Name, type != null ? type.Name : "unk", buffer, callStack);
        }

        public static void CheckVersion(IConnection connection, int version)
        {
            FeedbackService.OnCheckVersion(connection, version);
        }

        public static void AttackStageEnd(Creature creature)
        {
            FeedbackService.AttackStageEnd(creature);
        }

        public static void AttackFinished(Creature creature)
        {
            FeedbackService.AttackFinished(creature);
            SkillEngine.AttackFinished(creature);
        }
    }
}