using System.IO;

namespace Network.Server
{
    public class SpSimpleItemInfo : ASendPacket
    {
        protected int ItemId;

        public SpSimpleItemInfo(int itemId)
        {
            ItemId = itemId;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, ItemId);
            WriteD(writer, 0);
            WriteC(writer, 0);
        }
    }
}