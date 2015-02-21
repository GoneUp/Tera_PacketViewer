using System.IO;
using Data.Structures.Player;
using Data.Structures.World;

namespace Network.Server
{
    public class SpUpdateTrade : ASendPacket
    {
        protected ShoppingCart ShoppingCart;
        protected Player Player;

        public SpUpdateTrade(Player player, ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) ShoppingCart.BuyItems.Count);
            short buyItemShift = (short) writer.BaseStream.Position;
            WriteH(writer, 0); //first buyitem shift

            WriteH(writer, (short) ShoppingCart.SellItems.Count);
            short sellItemShift = (short) writer.BaseStream.Position;
            WriteH(writer, 0); //first sellitem shift

            WriteUid(writer, Player);
            WriteD(writer, ShoppingCart.Uid);
            WriteQ(writer, 0);
            WriteQ(writer, ShoppingCart.GetBuyItemsPrice());
            WriteB(writer, "9A9999999999A93F"); // shit from traidlist
            WriteQ(writer, ShoppingCart.GetSellItemsPrice());

            foreach (var item in ShoppingCart.BuyItems)
            {
                writer.Seek(buyItemShift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) writer.BaseStream.Position);
                buyItemShift = (short) writer.BaseStream.Position;
                WriteH(writer, 0);

                WriteD(writer, item.ItemTemplate.Id);
                WriteD(writer, item.Count);
            }

            foreach (var item in ShoppingCart.SellItems)
            {
                writer.Seek(sellItemShift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) (writer.BaseStream.Length));
                sellItemShift = (short) writer.BaseStream.Position;
                WriteH(writer, 0);

                WriteD(writer, item.ItemTemplate.Id);
                WriteD(writer, item.Count);
                WriteD(writer, 0);
                WriteD(writer, 0);
                WriteH(writer, 0);
            }
        }
    }
}