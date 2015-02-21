using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Enums.Pegasus;
using Data.Structures.Craft;
using Data.Structures.Creature;
using Data.Structures.Quest;
using Data.Structures.SkillEngine;
using Data.Structures.Template;
using Data.Structures.Template.Gather;
using Data.Structures.Template.Item;
using Data.Structures.World;
using Data.Structures.World.Continent;
using Data.Structures.World.Pegasus;
using ProtoBuf;
using Utils;

namespace Data
{
    public class Data
    {
        public static string DataPath = Path.GetFullPath("../../../../datapack/gameserver/data/");

        public static List<long> PlayerExperience = new List<long>();

        public static List<long> NpcExperience = new List<long>();

        public static List<CreatureBaseStats> Stats = new List<CreatureBaseStats>();

        public static Dictionary<int, ItemTemplate> ItemTemplates = new Dictionary<int, ItemTemplate>();

        public static Dictionary<int, GatherTemplate> GatherTemplates = new Dictionary<int, GatherTemplate>();

        public static Dictionary<int, List<SpawnTemplate>> Spawns = new Dictionary<int, List<SpawnTemplate>>();

        public static Dictionary<int, List<SpawnTemplate>> DcSpawns = new Dictionary<int, List<SpawnTemplate>>();

        public static Dictionary<int, Dictionary<int, NpcTemplate>> NpcTemplates = new Dictionary<int, Dictionary<int, NpcTemplate>>();

        public static Dictionary<int, Quest> Quests = new Dictionary<int, Quest>();

        public static Dictionary<int, Tradelist> Tradelists = new Dictionary<int, Tradelist>();

        public static Dictionary<int, List<FlyTeleport>> FlyTeleports = new Dictionary<int, List<FlyTeleport>>();

        public static Dictionary<int, List<WorldPosition>> BindPoints = new Dictionary<int, List<WorldPosition>>();

        public static Dictionary<int, List<Climb>> Climbs = new Dictionary<int, List<Climb>>();

        public static Dictionary<int, Recipe> Recipes = new Dictionary<int, Recipe>();

        public static List<GeoLocation> GeoData = new List<GeoLocation>();

        public static Dictionary<int, DefaultSkillSet> DefaultSkillSets = new Dictionary<int, DefaultSkillSet>();

        public static Dictionary<int, Dictionary<int, UserSkill>> UserSkills = new Dictionary<int, Dictionary<int, UserSkill>>();

        public static Dictionary<int, Dictionary<int, Dictionary<int, Skill>>> Skills = new Dictionary<int, Dictionary<int, Dictionary<int, Skill>>>();

        public static Dictionary<int, Abnormality> Abnormalities = new Dictionary<int, Abnormality>();

        public static Dictionary<int, List<Area>> Areas = new Dictionary<int, List<Area>>();

        public static Dictionary<int, Dictionary<PType, PegasusPath>> PegasusPaths = new Dictionary<int, Dictionary<PType, PegasusPath>>();

        public static Dictionary<int, List<int>> Drop = new Dictionary<int, List<int>>();

        public static Dictionary<int, List<int>> CoolDownGroups = new Dictionary<int, List<int>>();
 
        public static List<GSpawnTemplate> DcGatherSpawnTemplates = new List<GSpawnTemplate>();

        public static List<GSpawnTemplate> GatherSpawnTemplates = new List<GSpawnTemplate>();

        public static Dictionary<int, List<CampfireSpawnTemplate>> CampfireTemplates = new Dictionary<int, List<CampfireSpawnTemplate>>();

        public static Dictionary<int, Mount> Mounts = new Dictionary<int, Mount>(); 

        public static Dictionary <int, WorldPosition> StaticTeleports = new Dictionary<int, WorldPosition>();

        protected delegate int Loader();

        protected static List<Loader> Loaders = new List<Loader>
                                                    {
                                                        LoadPlayerExperience,
                                                        LoadStats,
                                                        LoadItemTemplates,
                                                        LoadSpawns,
                                                        LoadDcSpawns,
                                                        LoadNpcTemplates,
                                                        LoadGatherTemplates,
                                                        LoadQuests,
                                                        LoadTraidelists,
                                                        LoadFlyTeleports,
                                                        LoadBindPoints,
                                                        LoadClimbs,
                                                        LoadGeoData,
                                                        LoadRecipes,
                                                        LoadDefaultSkillSets,
                                                        LoadUserSkills,
                                                        LoadSkills,
                                                        LoadAbnormalities,
                                                        LoadAreas,
                                                        LoadPegasusPaths,
                                                        LoadDrop,
                                                        LoadCoolDownGroups,
                                                        LoadGatherSpawn,
                                                        LoadDcGatherSpawn,
                                                        LoadCampfires,
                                                        LoadMounts,
                                                        LoadTeleports,
                                                        CalculateNpcExperience,
                                                    };

        public static void LoadAll()
        {
            Parallel.For(0, Loaders.Count, i => LoadTask(Loaders[i]));
        }

        private static void LoadTask(Loader loader)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int readed = loader.Invoke();
            stopwatch.Stop();

            Log.Info("Data: {0,-26} {1,7} values in {2}s"
                , loader.Method.Name
                , readed
                , (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.00"));
        }

        public static int LoadPlayerExperience()
        {
            PlayerExperience = new List<long>();

            using (FileStream stream = File.OpenRead(DataPath + "player_experience.dat"))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    int count = reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                        PlayerExperience.Add(reader.ReadInt64());
                }
            }

            return PlayerExperience.Count;
        }

        public static int LoadStats()
        {
            using (FileStream fs = File.OpenRead(DataPath + "stats.bin"))
            {
                Stats = Serializer.Deserialize<List<CreatureBaseStats>>(fs);
            }

            return Stats.Count;
        }

        public static int LoadTeleports()
        {
            StaticTeleports.Add(21301015, new WorldPosition
                                              {
                                                  Heading = -32651,
                                                  MapId = 9036,
                                                  X =
                                                      BitConverter.ToSingle(
                                                          "00438B47".ToBytes(), 0),
                                                  Y =
                                                      BitConverter.ToSingle(
                                                          "004027C6".ToBytes(), 0),
                                                  Z =
                                                      BitConverter.ToSingle(
                                                          "00002DC3".ToBytes(), 0)
                                              });
            //		FullId	43601501	int

            StaticTeleports.Add(43601501, new WorldPosition
            {
                Heading = -32651,
                MapId = 13,
                X =58839,
                Y = -75263,
                Z = -5727,
            });


            return StaticTeleports.Count;
        }

        public static int LoadMounts()
        {
            using (FileStream fs = File.OpenRead(DataPath + "mounts.bin"))
                foreach (Mount mount in Serializer.Deserialize<List<Mount>>(fs))
                   Mounts.Add(mount.SkillId, mount);

            return Mounts.Count;
        }

        public static int LoadRecipes()
        {
            Recipes = new Dictionary<int, Recipe>();

            using (FileStream stream = File.OpenRead(DataPath + "recipes.bin"))
            {
                while (stream.Position < stream.Length)
                {
                    Recipe r = Serializer.DeserializeWithLengthPrefix<Recipe>(stream, PrefixStyle.Fixed32);
                    Recipes.Add(r.RecipeId, r);
                }
            }

            return Recipes.Count;
        }

        public static int LoadItemTemplates()
        {
            ItemTemplates = new Dictionary<int, ItemTemplate>();

            using (FileStream stream = File.OpenRead(DataPath + "items.bin"))
            {
                while (stream.Position < stream.Length)
                {
                    ItemTemplate template = Serializer.DeserializeWithLengthPrefix<ItemTemplate>(stream, PrefixStyle.Fixed32);
                    ItemTemplates.Add(template.Id, template);
                }
            }

            return ItemTemplates.Count;
        }

        public static int LoadBindPoints()
        {
            BindPoints = new Dictionary<int, List<WorldPosition>>();
            int readed = 0;

            using (FileStream stream = File.OpenRead(DataPath + "bind_points.bin"))
            {
                while (stream.Position < stream.Length)
                {
                    WorldPosition position = Serializer.DeserializeWithLengthPrefix<WorldPosition>(stream, PrefixStyle.Fixed32);
                    readed++;

                    if (!BindPoints.ContainsKey(position.MapId))
                        BindPoints.Add(position.MapId, new List<WorldPosition>());

                    BindPoints[position.MapId].Add(position);
                }
            }

            return readed;
        }

        public static int LoadGatherTemplates()
        {
            GatherTemplates = new Dictionary<int, GatherTemplate>();

            using (FileStream stream = File.OpenRead(DataPath + "gather_templates.bin"))
                GatherTemplates = Serializer.Deserialize<Dictionary<int, GatherTemplate>>(stream);

            return GatherTemplates.Count;
        }

        public static int LoadGatherSpawn()
        {
            using (FileStream fs = File.OpenRead(DataPath + "spawn/gather_spawns.bin"))
                GatherSpawnTemplates = Serializer.Deserialize<List<GSpawnTemplate>>(fs);

            return GatherSpawnTemplates.Count;
        }

        public static int LoadDcGatherSpawn()
        {
            using (FileStream fs = File.OpenRead(DataPath + "spawn/dc_gather_spawns.bin"))
                DcGatherSpawnTemplates = Serializer.Deserialize<List<GSpawnTemplate>>(fs);

            return DcGatherSpawnTemplates.Count;
        }

        public static int LoadTraidelists()
        {
            Tradelists = new Dictionary<int, Tradelist>();

            using (FileStream stream = File.OpenRead(DataPath + "tradelists.bin"))
            {
                while (stream.Position < stream.Length)
                {
                    Tradelists = Serializer.DeserializeWithLengthPrefix<Dictionary<int, Tradelist>>(stream, PrefixStyle.Fixed32);
                }
            }

            return Tradelists.Count;
        }

        public static int LoadQuests()
        {
            using (FileStream fs = File.OpenRead(DataPath + "quests.bin"))
                Quests = Serializer.Deserialize<Dictionary<int, Quest>>(fs);

            return Quests.Count;
        }

        public static int LoadSpawns()
        {
            Spawns = new Dictionary<int, List<SpawnTemplate>>();
            int readed = 0;

            foreach (string fileName in Directory.GetFiles(DataPath + "spawn"))
            {
                if (fileName.Contains("_spawn.bin"))
                {
                    using (FileStream stream = File.OpenRead(fileName))
                    {
                        while (stream.Position < stream.Length)
                        {
                            SpawnTemplate spawnTemplate = Serializer.DeserializeWithLengthPrefix<SpawnTemplate>(stream, PrefixStyle.Fixed32);

                            if (!Spawns.ContainsKey(spawnTemplate.MapId))
                                Spawns.Add(spawnTemplate.MapId, new List<SpawnTemplate>());

                            Spawns[spawnTemplate.MapId].Add(spawnTemplate);

                            readed++;
                        }
                    }
                }
            }

            return readed;
        }

        public static int LoadDcSpawns()
        {
            using (FileStream fs = File.OpenRead(DataPath + "dc_spawn.bin"))
            {
                DcSpawns = Serializer.Deserialize<Dictionary<int, List<SpawnTemplate>>>(fs);
            }

            int count = 0;

            foreach (var v1 in DcSpawns)
                count += v1.Value.Count;

            return count;
        }

        public static int LoadNpcTemplates()
        {
            using (FileStream fs = File.OpenRead(DataPath + "npc_templates.bin"))
            {
                NpcTemplates = Serializer.Deserialize<Dictionary<int, Dictionary<int, NpcTemplate>>>(fs);
            }

            int count = 0;

            foreach (var v1 in NpcTemplates)
                count += v1.Value.Count;

            return count;
        }

        public static int LoadFlyTeleports()
        {
            FlyTeleports = new Dictionary<int, List<FlyTeleport>>();

            using (FileStream fs = File.OpenRead(DataPath + "fly_teleports.bin"))
                FlyTeleports = Serializer.Deserialize<Dictionary<int, List<FlyTeleport>>>(fs);

            return FlyTeleports.Count;
        }

        public static int LoadClimbs()
        {
            Climbs = new Dictionary<int, List<Climb>>();

            /*using (FileStream stream = File.OpenRead(DataPath + "climbs.dat"))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    count = reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        Climb climb = Climb.ReadFromBinary(reader, new Climb());

                        if (!Climbs.ContainsKey(climb.MapId))
                            Climbs.Add(climb.MapId, new List<Climb>());

                        Climbs[climb.MapId].Add(climb);
                    }
                }
            }*/

            return Climbs.Count;
        }

        public static int LoadGeoData()
        {
            GeoData = new List<GeoLocation>();

            using (FileStream stream = File.OpenRead(DataPath + "geo.bin"))
            {
                while (stream.Position < stream.Length)
                    GeoData.Add(Serializer.DeserializeWithLengthPrefix<GeoLocation>(stream, PrefixStyle.Fixed32));
            }

            return GeoData.Count;
        }

        public static int LoadDefaultSkillSets()
        {
            using (FileStream fs = File.OpenRead(DataPath + "default_skill_sets.bin"))
            {
                DefaultSkillSets = Serializer.Deserialize<Dictionary<int, DefaultSkillSet>>(fs);
            }

            return DefaultSkillSets.Count;
        }

        public static int LoadUserSkills()
        {
            using (FileStream fs = File.OpenRead(DataPath + "user_skills.bin"))
            {
                UserSkills = Serializer.Deserialize<Dictionary<int, Dictionary<int, UserSkill>>>(fs);
            }

            int count = 0;

            foreach (var userSkill in UserSkills)
                count += userSkill.Value.Count;

            return count;
        }

        public static int LoadSkills()
        {
            using (FileStream fs = File.OpenRead(DataPath + "skills.bin"))
            {
                Skills = Serializer.Deserialize<Dictionary<int, Dictionary<int, Dictionary<int, Skill>>>>(fs);
            }

            int count = 0;

            foreach (var huntingZone in Skills)
                foreach (var template in huntingZone.Value)
                    count += template.Value.Count;

            return count;
        }

        private static int LoadAbnormalities()
        {
            using (FileStream fs = File.OpenRead(DataPath + "abnormalities.bin"))
            {
                Abnormalities = Serializer.Deserialize<Dictionary<int, Abnormality>>(fs);
            }

            return Abnormalities.Count;
        }

        private static int LoadAreas()
        {
            using (FileStream fs = File.OpenRead(DataPath + "areas.bin"))
                Areas = Serializer.Deserialize<Dictionary<int, List<Area>>>(fs);

            return Areas.Sum(keyValuePair => keyValuePair.Value.Count);
        }

        private static int LoadPegasusPaths()
        {
            using (FileStream fs = File.OpenRead(DataPath + "pegasus_paths.bin"))
                PegasusPaths = Serializer.Deserialize<Dictionary<int, Dictionary<PType, PegasusPath>>>(fs);

            return PegasusPaths.Sum(keyValuePair => keyValuePair.Value.Count);
        }

        private static int LoadDrop()
        {
            using (FileStream fs = File.OpenRead(DataPath + "drop.bin"))
            {
                Drop = Serializer.Deserialize<Dictionary<int, List<int>>>(fs);
            }

            return Drop.Count;
        }

        private static int LoadCoolDownGroups()
        {
            using (FileStream fs = File.OpenRead(DataPath + "item_cooldown_groups.bin"))
                CoolDownGroups = Serializer.Deserialize<Dictionary<int, List<int>>>(fs);

            return CoolDownGroups.Count;
        }

        private static int LoadCampfires()
        {
            using (FileStream fs = File.OpenRead(DataPath + "campfires.bin"))
                CampfireTemplates = Serializer.Deserialize<Dictionary<int, List<CampfireSpawnTemplate>>>(fs);

            int count = 0;
            foreach (var templates in CampfireTemplates)
                count += templates.Value != null
                             ? templates.Value.Count
                             : 0;

            return count;
        }

        private static int CalculateNpcExperience()
        {
            NpcExperience = new List<long>();

            const double x1 = 1, y1 = 131,
                         x2 = 5, y2 = 207,
                         x3 = 36, y3 = 2854;

            const double a = (y3 - ((x3*(y2 - y1) + x2*y1 - x1*y2)/(x2 - x1)))/(x3*(x3 - x1 - x2) + x1*x2);
            const double b = (y2 - y1)/(x2 - x1) - a*(x1 + x2);
            const double c = ((x2*y1 - x1*y2)/(x2 - x1)) + a*x1*x2;

            for (int i = 0; i < 100; i++)
                NpcExperience.Add((long) (a * i * i + b * i + c));

            return NpcExperience.Count;
        }
    }
}