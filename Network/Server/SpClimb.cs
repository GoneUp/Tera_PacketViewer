using System.IO;
using Data.Structures.Player;
using Data.Structures.World;

namespace Network.Server
{
    public class SpClimb : ASendPacket
    {
        protected Player Player;
        protected Climb Climb;

        public SpClimb(Player player, Climb climb)
        {
            Player = player;
            Climb = climb;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);

            WriteF(writer, Climb.X1);
            WriteF(writer, Climb.Y1);
            WriteF(writer, Climb.Z1);

            WriteH(writer, Climb.Heading);

            WriteF(writer, Climb.X2);
            WriteF(writer, Climb.Y2);
            WriteF(writer, Climb.Z2);

            WriteC(writer, 0);
        }
    }
}