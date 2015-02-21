using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpRemoveItem : ASendPacket
    {
        protected Item Item;

        public SpRemoveItem(Item item)
        {
            Item = item;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Item);
        }
    }
}