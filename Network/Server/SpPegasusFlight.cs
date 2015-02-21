using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPegasusFlight : ASendPacket
    {
        protected Player Player;
        protected int TeleportId;
        protected int State;
        protected int Time;

        public SpPegasusFlight(Player player, int teleportId, int state, int time)
        {
            Player = player;
            TeleportId = teleportId;
            State = state;
            Time = time;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);
            WriteD(writer, TeleportId);
            WriteD(writer, State);
            WriteD(writer, Time);
        }
    }
}