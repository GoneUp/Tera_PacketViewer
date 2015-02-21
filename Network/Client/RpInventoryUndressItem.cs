namespace Network.Client
{
    public class RpInventoryUndressItem : ARecvPacket
    {
        protected int From;
        protected int To;

        public override void Read()
        {
            ReadD(); //Unk
            ReadD(); //Unk
            From = ReadD();
            To = ReadD();
        }

        public override void Process()
        {
            Communication.Global.StorageService.ReplaceItem(Connection.Player, Connection.Player.Inventory, From, To);
        }
    }
}