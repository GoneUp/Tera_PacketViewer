using Data.Enums.Item;

namespace Network.Client
{
    public class RpStorageSort : ARecvPacket
    {
        protected StorageType Type;
        protected int From;
        protected int To;

        public override void Read()
        {
            int storageType = ReadD();

            if(storageType == 0)
                Type = StorageType.Inventory;
            else
            {
                Type = StorageType.CharacterWarehouse;
                From = ReadD();
                To = ReadD();
            }
            // Inventory
            // D (0)
            // D (FF FF FF FF)

            // Warehouse
            // D (1)
            // D From
            // D To
        }

        public override void Process()
        {
            switch (Type)
            {
                case StorageType.Inventory:
                    Connection.Player.Inventory.Sort(20, 60);
                    break;
                case StorageType.CharacterWarehouse:
                    if (From < 72)
                        From = 0;
                    else if (From < 144)
                        From = 72;
                    else if (From < 216)
                        From = 144;
                    else
                        From = 216;
                    Connection.Player.CharacterWarehouse.Sort(From, From + 72);
                    break;
            }
            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, Type, false, From);
        }
    }
}
