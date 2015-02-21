using System.IO;
using Data.Enums.Gather;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterGatherstats : ASendPacket
    {
        protected PlayerCraftStats GatherStats;

        public SpCharacterGatherstats(PlayerCraftStats gatherStats)
        {
            GatherStats = gatherStats;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, GatherStats.GetGatherStat(TypeName.Energy));
            WriteH(writer, GatherStats.GetGatherStat(TypeName.Herb));
            WriteH(writer, 0); //unk, mb bughunting
            WriteH(writer, GatherStats.GetGatherStat(TypeName.Mine));
            WriteQ(writer, 0);
        }
    }
}