
namespace Network.Client
{
    class RpWarehouseAddItemToInventory : ARecvPacket
    {
        protected int FromSlot;
        protected int ItemId;
        protected int Count;
        protected int ToSlot;
        protected int Offset;
        protected int Money;

        public override void Read()
        {
            ReadD();//1
            ReadD();//3
            ReadD();//1
            Offset = ReadD();
            Money = ReadD();
            ReadD();//0
            FromSlot = ReadD();//from slot
            ReadD();//
            ReadD();//7
            ItemId = ReadD();//id
            Count = ReadD();//counter
            ToSlot = ReadD();//to slot
        }

        public override void Process()
        {
            if (Offset < 72)
                Offset = 0;
            else if (Offset < 144)
                Offset = 72;
            else if (Offset < 216)
                Offset = 144;
            else
                Offset = 216;

            if (ItemId == -1 && FromSlot == -1 && ToSlot == -1)
            {
                if (Connection.Player.CharacterWarehouse.Money < Money || Money < 0)
                    return;

                Connection.Player.CharacterWarehouse.Money -= Money;
                Connection.Player.Inventory.Money += Money;
            }
            else
            Communication.Global.StorageService.PlaceItemToOtherStorage(Connection.Player, Connection.Player,
                                                                        Connection.Player.CharacterWarehouse, FromSlot,
                                                                        Connection.Player.Inventory, ToSlot, Count);
            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, Data.Enums.Item.StorageType.Inventory);
            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, Data.Enums.Item.StorageType.CharacterWarehouse, false, Offset % 72 != 0 ? 0 : Offset);
        }
    }
}
