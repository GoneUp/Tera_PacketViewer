using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpDropInfo : ASendPacket // len 61
    {
        protected Item Item;

        public SpDropInfo(Item item)
        {
            Item = item;
        }

        public SpDropInfo(int itemId, WorldPosition worldPosition)
        {
            Item = new Item
                       {
                           Position = worldPosition,
                           Count = 1,
                           ItemId = itemId,
                           //20000000
                       };
        }

        public override void Write(BinaryWriter writer)
        {
            WriteB(writer, "01003100"); //Shifts
            WriteUid(writer, Item);
            WriteF(writer, Item.Position.X);
            WriteF(writer, Item.Position.Y);
            WriteF(writer, Item.Position.Z);
            WriteD(writer, Item.ItemId);
            WriteD(writer, Item.Count);
            WriteB(writer, "C0D4010001"); //??? 57
            WriteUid(writer, Item.Npc);
            WriteB(writer, "31000000"); //Shifts
            WriteUid(writer, Item.Owner);
        }
    }
}