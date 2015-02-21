using System.IO;

namespace Network.Server
{
    public class SpHelp : ASendPacket
    {
        protected int MsgId;

        public SpHelp(int msgId)
        {
            MsgId = msgId;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, MsgId);
        }
    }
}