using Data.Enums.Item;

namespace Network.Client
{
    class RpWarehouseAddItem : ARecvPacket
    {
        protected int ToSlot;
        protected int Counter;
        protected int ItemId;
        protected int FromSlot;
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
            FromSlot = ReadD();
            ItemId = ReadD();
            ReadD();//2
            ReadD();//7
            Counter = ReadD();
            ToSlot = ReadD();
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
                if(Connection.Player.Inventory.Money < Money || Money < 0)
                    return;

                Connection.Player.Inventory.Money -= Money;
                Connection.Player.CharacterWarehouse.Money += Money;
            }
            else
                Communication.Global.StorageService.PlaceItemToOtherStorage(Connection.Player, Connection.Player,
                                                            Connection.Player.Inventory, FromSlot,
                                                            Connection.Player.CharacterWarehouse, ToSlot,
                                                            Counter);

            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, StorageType.CharacterWarehouse, false, Offset % 72 != 0 ? 0 : Offset);
            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, StorageType.Inventory);
        }
    }
}
