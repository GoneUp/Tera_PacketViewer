using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpTradeHideWindow : ASendPacket
    {
        protected Player Player1;
        protected Player Player2;
        protected int TradeId;
        protected int Type;

        public SpTradeHideWindow(Player player1, Player player2, int tradeId, int type = 1)
        {
            Player1 = player1;
            Player2 = player2;
            TradeId = tradeId;
            Type = type;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player1);
            WriteUid(writer, Player2);
            WriteD(writer, TradeId);
            WriteD(writer, Type);
        }
    }
}