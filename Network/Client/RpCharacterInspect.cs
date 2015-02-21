using Data.Structures;
using Data.Structures.Player;
using Network.Server;

namespace Network.Client
{
    public class RpCharacterInspect : ARecvPacket
    {
        protected long CharacterId;

        public override void Read()
        {
            CharacterId = ReadQ();
        }

        public override void Process()
        {
            Player player = (Player)Uid.GetObject(CharacterId);

            if(player== null)
                return;

            new SpCharacterInspect(player).Send(Connection);
        }
    }
}