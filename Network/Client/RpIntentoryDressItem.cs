using Utils;

namespace Network.Client
{
    public class RpInventoryDressItem : ARecvPacket
    {
        protected int From;
        protected int To;
        protected int Unk1;
        protected int Unk2;

        public override void Read()
        {
            Unk1 = ReadD(); //Unk
            Unk2 = ReadD(); //Unk
            From = ReadD();
            To = ReadD();
        }

        public override void Process()
        {
            Communication.Global.StorageService.ReplaceItem(Connection.Player, Connection.Player.Inventory, From, To, true);
        }
    }
}