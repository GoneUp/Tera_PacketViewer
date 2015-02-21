using System.IO;

namespace Network.Server
{
    public class SpCanSendRequest : ASendPacket
    {
        protected int RequestType;

        public SpCanSendRequest(int requestType)
        {
            RequestType = requestType;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, RequestType);
        }
    }
}