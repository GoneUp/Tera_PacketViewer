namespace Network.Client
{
    public class RpChatInfo : ARecvPacket
    {
        protected int Type;
        protected string Name;

        public override void Read()
        {
            ReadH(); //shift
            Type = ReadD();
            ReadD();
            Name = ReadS();
        }

        public override void Process()
        {
            Communication.Global.ChatService.SendChatInfo(Connection, Type, Name);
        }
    }
}