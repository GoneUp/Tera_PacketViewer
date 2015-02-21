using Data.Enums.Item;

namespace Network.Client
{
    public class RpGetInventory : ARecvPacket
    {
        public override void Read()
        {
            ReadD(); //1 //mb type
        }

        public override void Process()
        {
            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, StorageType.Inventory, false);
        }
    }
}