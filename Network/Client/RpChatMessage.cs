using Communication.Logic;
using Data.Enums;

namespace Network.Client
{
    public class RpChatMessage : ARecvPacket
    {
        protected short Length;
        protected ChatType Type;
        protected string Message;

        public override void Read()
        {
            Length = (short) ReadH();
            Type = (ChatType) ReadD();
            Message = ReadS();
        }

        public override void Process()
        {
            PlayerLogic.ProcessChatMessage(Connection, Message, Type);
        }
    }
}