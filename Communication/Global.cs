using System;
using System.Threading;
using Communication.Interfaces;
using Data;
using Utils;

namespace Communication
{
    public class Global
    {
        //Services:

        public static IFeedbackService FeedbackService;

        public static IAccountService AccountService;

        public static IPlayerService PlayerService;

        public static IMapService MapService;

        public static IChatService ChatService;

        public static IVisibleService VisibleService;

        public static IControllerService ControllerService;

        public static ICraftService CraftService;

        public static IItemService ItemService;

        public static IAiService AiService;

        public static IGeoService GeoService;

        public static IStatsService StatsService;

        public static IObserverService ObserverService;

        public static IInformerService InformerService;

        public static ITeleportService TeleportService;

        public static IAreaService AreaService;

        public static IPartyService PartyService;

        public static ISkillsLearnService SkillsLearnService;

        public static ICraftLearnService CraftLearnService;

        public static IGuildService GuildService;

        public static IEmotionService EmotionService;

        public static IRelationService RelationService;

        public static IDuelService DuelService;

        public static IStorageService StorageService;

        public static ITradeService TradeService;

        public static IMountService MountService;

        //Engines:

        public static IActionEngine ActionEngine;

        public static IAdminEngine AdminEngine;

        public static ISkillEngine SkillEngine;

        public static IQuestEngine QuestEngine;

        //

        protected static bool ShutdownIsStart = false;

        protected static bool ServerIsWork = true;

        protected static Thread MapServiceLoopThread;

        public static void InitMainLoop()
        {
            MapServiceLoopThread = new Thread(MapServiceLoop);
            MapServiceLoopThread.Start();
        }

        public static void ShutdownServer()
        {
            if (ShutdownIsStart)
                return;

            ShutdownIsStart = true;

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("          Starting shootdown hook");
            Console.WriteLine("-------------------------------------------");

            FeedbackService.ShowShutdownTicks();

            ServerIsWork = false;
        }

        protected static void MainLoop()
        {
            while (ServerIsWork)
            {
                try
                {
                    if(Funcs.GetCurrentMilliseconds() - Cache.LastSaveUts > 1800000)
                    {
                        Cache.LastSaveUts = Funcs.GetCurrentMilliseconds();
                        Cache.SaveData();
                    }
                    //Services:

                    FeedbackService.Action();
                    AccountService.Action();
                    PlayerService.Action();
                    //MapService.Action();
                    ChatService.Action();
                    VisibleService.Action();
                    ControllerService.Action();
                    CraftService.Action();
                    ItemService.Action();
                    AiService.Action();
                    GeoService.Action();
                    StatsService.Action();
                    ObserverService.Action();
                    InformerService.Action();
                    TeleportService.Action();
                    AreaService.Action();
                    PartyService.Action();
                    SkillsLearnService.Action();
                    GuildService.Action();
                    DuelService.Action();

                    //Engines:
                    
                    ActionEngine.Action();
                    AdminEngine.Action();
                    SkillEngine.Action();
                    QuestEngine.Action();

                    //Others:

                    DelayedAction.CheckActions();
                }
                catch(Exception ex)
                {
                    Log.ErrorException("MainLoop:", ex);
                }

                Thread.Sleep(10);
            }
        // ReSharper disable FunctionNeverReturns
        }
        // ReSharper restore FunctionNeverReturns

        protected static void MapServiceLoop()
        {
            while (true)
            {
                try
                {
                    MapService.Action();
                }
                catch (Exception ex)
                {
                    Log.ErrorException("MapServiceLoop:", ex);
                }

                Thread.Sleep(1);
            }
            // ReSharper disable FunctionNeverReturns
        }
        // ReSharper restore FunctionNeverReturns
    }
}