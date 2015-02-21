using Data.Enums.Item;

namespace Network.Client
{
    public class RpWarehouseChangeSection : ARecvPacket
    {
        protected int Offset;

        public override void Read()
        {
            ReadD();
            ReadD();
            ReadD();
            Offset = ReadD();
        }

        public override void Process()
        {
            if(Offset % 72 != 0 || Offset > 216)
                return;

            Connection.Player.CurrentBankSection = Offset / 72;

            Communication.Global.StorageService.ShowPlayerStorage(Connection.Player, StorageType.CharacterWarehouse, false, Offset);
        }
    }
}
