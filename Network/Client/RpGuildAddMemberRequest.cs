using Data.Structures;
using Data.Structures.Player;
using Data.Structures.World.Requests;

namespace Network.Client
{
    public class RpGuildAddMemberRequest : ARecvPacket
    {
        protected long TargetUid;

        public override void Read()
        {
            TargetUid = ReadQ();
        }

        public override void Process()
        {
            Player target = (Player)Uid.GetObject(TargetUid);
            if(target != null)
                Communication.Global.ActionEngine.AddRequest(new GuildInvite(target) { Owner = Connection.Player });
        }
    }
}