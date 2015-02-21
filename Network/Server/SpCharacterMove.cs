using System.IO;
using Data.Enums.Player;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterMove : ASendPacket
    {
        protected Player Player;

        protected float X1;
        protected float Y1;
        protected float Z1;
        protected short Heading;

        protected float X2;
        protected float Y2;
        protected float Z2;

        protected short MoveType;
        protected short Unk2;
        protected short Unk3;

        public SpCharacterMove(Player player, float x1, float y1, float z1, short heading,
                               float x2, float y2, float z2, PlayerMoveType moveType, short unk2, short unk3)
        {
            Player = player;

            X1 = x1;
            Y1 = y1;
            Z1 = z1;
            Heading = heading;

            X2 = x2;
            Y2 = y2;
            Z2 = z2;

            MoveType = (short)moveType.GetHashCode();
            Unk2 = unk2;
            Unk3 = unk3;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);

            WriteF(writer, X1);
            WriteF(writer, Y1);
            WriteF(writer, Z1);
            WriteH(writer, Heading);

            WriteH(writer, Player.GameStats.Movement);

            WriteF(writer, X2);
            WriteF(writer, Y2);
            WriteF(writer, Z2);

            WriteH(writer, MoveType);
            WriteH(writer, 0);
            WriteC(writer, 0);
        }
    }
}