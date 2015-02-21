using System.IO;

namespace Network.Server
{
    public class SpPartyVote : ASendPacket
    {
        protected long PlayerUid;

        public SpPartyVote(long playerUid)
        {
            PlayerUid = playerUid;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, PlayerUid);
        }
    }
}