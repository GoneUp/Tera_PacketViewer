using Data.Enums.Item;

namespace Network.Client
{
    public class RpWarehouseReplaceItem : ARecvPacket
    {
        protected int From;
        protected int To;
        protected int Offset;

        public override void Read()
        {
            ReadD(); // 1
            ReadD(); // 3
            ReadD(); // 1
            ReadD();
            ReadD();
            From = ReadD();
            To = ReadD();
            Offset = ReadD();
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

            Communication.Global.StorageService.ReplaceItem(Connection.Player, Connection.Player.CharacterWarehouse, From, To, false, false);
            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, StorageType.CharacterWarehouse, false, Offset);
        }
    }
}
