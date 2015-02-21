using Data.Enums;

namespace Network.Client
{
    public class RpGetItemInfo : ARecvPacket
    {
        protected long ItemUid;
        protected int ViewMode;

        public override void Read()
        {
            ReadH(); // 38
            ViewMode = ReadH(); // 20 - inventory, 24 - inspect
            ReadH(); // 0
            ItemUid = ReadQ();
        }

        public override void Process()
        {
            Communication.Global.ItemService.GetItemInfo(Connection.Player, ItemUid);
        }
    }
}