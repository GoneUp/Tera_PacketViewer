using System.IO;

namespace Network.Server
{
    public class SpDropPickup : ASendPacket
    {
        protected long PlayerUid;
        protected long ItemUid;
        protected byte Unk;

        public SpDropPickup(long playerUid, long itemUid, byte unk = (byte) 0x01)
        {
            PlayerUid = playerUid;
            ItemUid = itemUid;
            Unk = unk;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, PlayerUid);
            WriteQ(writer, ItemUid);
            WriteC(writer, Unk);
        }
    }
}