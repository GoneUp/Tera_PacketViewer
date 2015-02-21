namespace Network.Client
{
    public class RpChatPrivate : ARecvPacket
    {
        protected string Name;
        protected string Message;

        public override void Read()
        {
            ReadH(); //0x0800
            ReadH(); //0x2800
            Name = ReadS();
            Message = ReadS();
        }

        public override void Process()
        {
            Communication.Global.ChatService.ProcessPrivateMessage(Connection, Name, Message);
        }
    }
}