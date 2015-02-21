using Data.Structures.Player;
using Data.Structures.World.Requests;
using System.IO;

namespace Network.Server
{
    public class SpHideRequest : ASendPacket
    {
        protected Request Request;

        public SpHideRequest(Request request)
        {
            Request = request;
        }

        public override void Write(BinaryWriter writer)
        {
            // todo places
            WriteUid(writer, Request.Owner);
            WriteUid(writer, Request.Target);
            WriteD(writer, (int)Request.Type);
            WriteD(writer, Request.UID);
        }
    }
}