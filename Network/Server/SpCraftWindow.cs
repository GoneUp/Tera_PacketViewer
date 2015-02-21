using System.IO;
using Data.Enums;
using Data.Enums.Craft;

namespace Network.Server
{
    public class SpCraftWindow : ASendPacket
    {
        protected CraftStat CraftStat;

        public SpCraftWindow(CraftStat craftStat)
        {
            CraftStat = craftStat;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, CraftStat.GetHashCode());
        }
    }
}
