using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Data.Structures.Account;
using Data.Structures.Guild;
using Data.Structures.Player;
using ProtoBuf;
using Utils;

namespace Data
{
    public class Cache
    {
        protected static Dictionary<string, Account> Accounts;
        public static Dictionary<int, Guild> Guilds; 

        public static List<string> UsedNames = new List<string>();
        public static List<string> UsedGuildNames = new List<string>();

        public static long LastSaveUts = Funcs.GetCurrentMilliseconds();

        public static void LoadData()
        {
            LoadAccounts();
            LoadGuilds();
        }

        public static void LoadAccounts()
        {
            if (!File.Exists("cache.bin"))
            {
                Log.Warn("Data: Cache file not found!");
                Accounts = new Dictionary<string, Account>();
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            using (FileStream fs = File.OpenRead("cache.bin"))
            {
                Accounts = Serializer.DeserializeWithLengthPrefix<Dictionary<string, Account>>(fs, PrefixStyle.Fixed32);
            }
            if (Accounts == null)
                Accounts = new Dictionary<string, Account>();
            stopwatch.Stop();

            foreach (KeyValuePair<string, Account> account in Accounts)
                foreach (Player player in account.Value.Players)
                    UsedNames.Add(player.PlayerData.Name.ToLower());

            Log.Info("Cache: Loaded {0} accounts in {1}s"
                     , Accounts.Count
                     , (stopwatch.ElapsedMilliseconds/1000.0).ToString("0.00"));
        }

        public static void LoadGuilds()
        {
            if (!File.Exists("guilds_cache.bin"))
            {
                Log.Warn("Data: guilds_cache file not found!");
                Guilds = new Dictionary<int, Guild>();
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            using (FileStream fs = File.OpenRead("guilds_cache.bin"))
            {
                Guilds = Serializer.DeserializeWithLengthPrefix<Dictionary<int, Guild>>(fs, PrefixStyle.Fixed32);
            }
            if (Guilds == null)
                Guilds = new Dictionary<int, Guild>();
            stopwatch.Stop();

            foreach (KeyValuePair<int, Guild> guild in Guilds)
                UsedGuildNames.Add(guild.Value.GuildName.ToLower());

            Log.Info("Cache: Loaded {0} guilds in {1}s"
                     , Guilds.Count
                     , (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.00"));

            RestorePlayerGuilds();

        }

        public static void SaveData()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            if (!Directory.Exists("cache_backup"))
                Directory.CreateDirectory("cache_backup");

            string dirName = "backup_" + Funcs.GetRoundedUtc();

            Directory.CreateDirectory("cache_backup/" + dirName);
            // ReSharper disable EmptyGeneralCatchClause
            try { File.Copy("cache.bin", "cache_backup/" + dirName + "/cache.bin"); }
            catch{}
            try { File.Copy("guilds_cache.bin", "cache_backup/" + dirName + "/guilds_cache.bin"); }
            catch { }
            // ReSharper restore EmptyGeneralCatchClause


            using (FileStream fs = File.Create("cache.bin"))
                Serializer.SerializeWithLengthPrefix(fs, Accounts, PrefixStyle.Fixed32);

            using (FileStream fs = File.Create("guilds_cache.bin"))
                Serializer.SerializeWithLengthPrefix(fs, Guilds, PrefixStyle.Fixed32);

            stopwatch.Stop();

            Log.Info("Cache: Saved {0} accounts and {2} guilds in {1}s"
                , Accounts.Count
                , (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.00"), Guilds.Count);
        }

        public static Account GetAccount(string accountName)
        {
            string key = accountName.ToLower();

            if (!Accounts.ContainsKey(key))
                Accounts.Add(key, new Account {Name = accountName});

            return Accounts[key];
        }

        public static void RestorePlayerGuilds()
        {
            foreach (KeyValuePair<string, Account> account in Accounts)
                foreach (var pl in account.Value.Players)
                    if (pl.GuildIdAndRank.Key != 0 && Guilds.ContainsKey(pl.GuildIdAndRank.Key))
                    {
                        Guilds[pl.GuildIdAndRank.Key].GuildMembers.Add(pl, pl.GuildIdAndRank.Value);
                        pl.Guild = Guilds[pl.GuildIdAndRank.Key];
                    }
        }
    }
}