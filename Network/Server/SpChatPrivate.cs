using System.IO;

namespace Network.Server
{
    public class SpChatPrivate : ASendPacket //send only 4 self
    {
        protected string Sender;
        protected string Sended;
        protected string Message;

        public SpChatPrivate(string sender, string targetName, string message)
        {
            Sender = sender;
            Sended = targetName;
            Message = message;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //first name shift
            WriteH(writer, 0); //second name shift
            WriteH(writer, 0); //message shift
            WriteC(writer, 0);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Sender);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Sended);

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Message);
        }
    }
}