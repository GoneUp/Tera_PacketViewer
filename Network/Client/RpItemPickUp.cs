using Communication.Logic;
using Data.Structures;
using Data.Structures.World;

namespace Network.Client
{
    public class RpItemPickUp : ARecvPacket
    {
        protected long ItemUid;

        public override void Read()
        {
            ItemUid = ReadQ();
        }

        public override void Process()
        {
            Item item = TeraObject.GetObject(ItemUid) as Item;

            if (item != null)
                PlayerLogic.PickUpItem(Connection, item);
        }
    }
}