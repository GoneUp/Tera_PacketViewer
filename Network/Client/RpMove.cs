using Communication.Logic;
using Data.Enums.Player;

namespace Network.Client
{
    public class RpMove : ARecvPacket
    {
        public float X1;
        public float Y1;
        public float Z1;
        protected short Heading;

        protected float X2;
        protected float Y2;
        protected float Z2;

        protected PlayerMoveType MoveType;
        protected short Unk2;
        protected short Unk3;

        public override void Read()
        {
            X1 = ReadF();
            Y1 = ReadF();
            Z1 = ReadF();
            Heading = (short) ReadH();

            X2 = ReadF();
            Y2 = ReadF();
            Z2 = ReadF();

            MoveType = (PlayerMoveType)ReadH();
            Unk2 = (short) ReadH();
            Unk3 = (short) ReadH();
        }

        public override void Process()
        {
            PlayerLogic.PlayerMoved(Connection.Player, X1, Y1, Z1, Heading, X2, Y2, Z2, MoveType, Unk2, Unk3);
        }
    }
}