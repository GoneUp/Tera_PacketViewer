using System.IO;

namespace Network.Server
{
    public class SpItemCooldown : ASendPacket
    {
        protected int ItemId;
        protected int Cooldown;

        public SpItemCooldown(int itemid, int cooldown)
        {
            ItemId = itemid;
            Cooldown = cooldown;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, ItemId);
            WriteD(writer, Cooldown);
        }
    }
}