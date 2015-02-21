using Utils;

namespace Network.Client
{
    public class RpInventoryRemoveItem : ARecvPacket
    {
        protected int Slot;
        protected int Counter;
        protected int Unk1;
        protected int Unk2;

        public override void Read()
        {
            Unk1 = ReadD(); //Unk
            Unk2 = ReadD(); //Unk
            Slot = ReadD();
            Counter = ReadD();
        }

        public override void Process()
        {
            Communication.Global.StorageService.RemoveItem(Connection.Player, Connection.Player.Inventory, Slot, Counter);
        }
    }
}