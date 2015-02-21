using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCraftUpdateWindow : ASendPacket
    {
        protected StorageItem Item;

        public SpCraftUpdateWindow(StorageItem item)
        {
            Item = item;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Item);
            WriteD(writer, Item.ItemId);
            WriteD(writer, /*Item.ItemTemplate.Extraction*/ 0); // in original "Tier" and i don't know, what that mean
            WriteD(writer, 0);
            WriteC(writer, 0);
        }
    }
}