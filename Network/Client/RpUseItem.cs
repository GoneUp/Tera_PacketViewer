using Communication;
using Data.Structures.World;

namespace Network.Client
{
    public class RpUseItem : ARecvPacket
    {
        protected long PlayerUid;
        protected int ItemId;
        protected WorldPosition Position = new WorldPosition();
        protected byte[] Unk;

        public override void Read()
        {
            PlayerUid = ReadQ();
            ItemId = ReadD();
            Unk = ReadB(28); //unk, zeros
            Position.X = ReadF();
            Position.Y = ReadF();
            Position.Z = ReadF();
            Position.Heading = (short)ReadH(); //think, that this is item slot
        }

        public override void Process()
        {
            Global.ItemService.ItemUse(Connection.Player, ItemId, Position);
        }
    }
}