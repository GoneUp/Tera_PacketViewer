using Data.Structures.Player;
using Network.Server;

namespace Network.Client
{
    public class RpGetInspectUid : ARecvPacket
    {
        protected string CharacterName;

        public override void Read()
        {
            ReadH(); // 6 Why is it here?
            CharacterName = ReadS();
        }

        public override void Process()
        {
            Player player = Communication.Global.PlayerService.GetPlayerByName(CharacterName);

            if(player == null)
                return;

            new SpInspectUid(player).Send(Connection);
        }
    }
}
