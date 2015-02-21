namespace Network.Client
{
    public class RpDialogSelect : ARecvPacket
    {
        protected int DialogUid;
        protected int SelectedIndex;

        public override void Read()
        {
            DialogUid = ReadD();
            SelectedIndex = ReadD();
            ReadD(); //FFFFFFFF
            ReadD(); //FFFFFFFF
        }

        public override void Process()
        {
            Communication.Logic.PlayerLogic.ProgressDialog(Connection.Player, SelectedIndex, DialogUid);
        }
    }
}