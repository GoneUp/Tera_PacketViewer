using System.IO;
using Data.Enums;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterInit : ASendPacket // Only for owner!!!
    {
        protected Player Player;

        public SpCharacterInit(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //Name shift
            WriteH(writer, 0); //Details shift
            WriteH(writer, (short) Player.PlayerData.Details.Length); //Details length

            WriteD(writer, Player.PlayerData.SexRaceClass);
            WriteUid(writer, Player);

            WriteD(writer, 11); //???

            WriteD(writer, Player.PlayerId);
            WriteB(writer, "000000000100000000460000006E000000");
            WriteB(writer, Player.PlayerData.Data); //PlayerData
            WriteC(writer, 1); //Online?
            WriteC(writer, 0); //??
            WriteD(writer, Player.GetLevel()); //Level

            WriteB(writer, "00000000000001000000000000000000");
            WriteQ(writer, Player.Exp);
            WriteQ(writer, Player.GetExpShown());
            WriteQ(writer, Player.GetExpNeed());
            WriteB(writer, "0000000000000000461600000000000000000000");

            WriteD(writer, Player.Inventory.GetItemId(1) ?? 0); //Item (hands)
            WriteD(writer, Player.Inventory.GetItemId(3) ?? 0); //Item (body)
            WriteD(writer, Player.Inventory.GetItemId(4) ?? 0); //Item (gloves)
            WriteD(writer, Player.Inventory.GetItemId(5) ?? 0); //Item (shoes)
            WriteD(writer, 0); //Item (???)
            WriteD(writer, 0); //Item (???)

            WriteB(writer, "5E10C101000000000100000000000000000000000000000000000000000000000000000000");

            WriteD(writer, Player.Inventory.GetItem(1) != null ? Player.Inventory.GetItem(1).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(3) != null ? Player.Inventory.GetItem(3).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(4) != null ? Player.Inventory.GetItem(4).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(5) != null ? Player.Inventory.GetItem(5).Color : 0);
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???

            WriteB(writer, "0001000000000000000000000000");

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) (writer.BaseStream.Length)); //Name shift
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Player.PlayerData.Name);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) (writer.BaseStream.Length)); //Details shift
            writer.Seek(0, SeekOrigin.End);

            WriteB(writer, Player.PlayerData.Details);

            //1603
            //C300D5002000 7A270000 87170B0000800002          7D900000000000000100000000460000006E000000650C00070D0F0400010001000000000000000000010000000000000000000100000000000000010000000000000048030000000000000000000000000000461600000000000000000000162700009C3A00009D3A00009E3A0000                  AD3F1C0F00000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                            41006C006500680061006E006400720000000C0B10021710090A151910001006100008100C0C10150C101010160C0E100F15

            //1725
            //DC00E4002000 FE2A0000 D2340B0000800000 0B000000 A7250000000000000100000000460000006E0000006503040102050400010001000000000000000000010000000000000000000100000000000000010000000000000048030000000000000000000000000000A30100000000000000000000162700009C3A00009D3A00009E3A0000 0000000000000000 16DBB70300000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 01000000000000000000000000 45006C00610000000601020700000000180F1A00010000000F0001000000000F1517101019100909
        }
    }
}