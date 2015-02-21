using System.IO;
using Data.Enums.Player;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterInfo : ASendPacket
    {
        protected Player Player;
        protected PlayerRelation Relation;

        public SpCharacterInfo(Player player, PlayerRelation relation)
        {
            Player = player;
            Relation = relation;
        }

        public override void Write(BinaryWriter writer)
        {

            WriteH(writer, 0); //Name shift
            WriteH(writer, 0); //Legion shift
            WriteH(writer, 0); //Unk1 shift
            WriteH(writer, 0); //Details shift
            WriteH(writer, (short)Player.PlayerData.Details.Length); //2000
            WriteH(writer, 0); //Unk2 shift
            WriteH(writer, 0); //Unk3 shift

            WriteD(writer, 11);
            WriteD(writer, Player.PlayerId);

            WriteUid(writer, Player);

            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Y);
            WriteF(writer, Player.Position.Z);
            WriteH(writer, Player.Position.Heading);

            WriteD(writer, Relation.GetHashCode());
            WriteD(writer, Player.PlayerData.SexRaceClass);

            WriteB(writer, "00004600AA00000000000101"); //???

            WriteB(writer, Player.PlayerData.Data);

            WriteD(writer, Player.Inventory.GetItemId(1) ?? 0); //Item (hands)
            WriteD(writer, Player.Inventory.GetItemId(3) ?? 0); //Item (body)
            WriteD(writer, Player.Inventory.GetItemId(4) ?? 0); //Item (gloves)
            WriteD(writer, Player.Inventory.GetItemId(5) ?? 0); //Item (shoes)

            WriteB(writer, "000000000000000001000000000000000600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            WriteD(writer, Player.GetLevel());
            WriteB(writer, "000000000000000001000000000000000000000000");

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); //Name shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, Player.PlayerData.Name); //Name

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); //Legion shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, Player.Guild != null ? Player.Guild.GuildName : "");

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); //Unk1 shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, ""); //Unk1

            writer.Seek(10, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); //Details shift
            writer.Seek(0, SeekOrigin.End);
            WriteB(writer, Player.PlayerData.Details);

            writer.Seek(12, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); //Unk2 shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, ""); //Unk2

            writer.Seek(14, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); //Unk3 shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, Player.Guild == null ? "" : Player.Guild.GuildTitle); //on top of nick, mb status?

            return;

            //1CDE BD00 D300 D500 D700 2000 F700 F900    0B00 0000    292A0000     460B0B0000800000 34119C47 3099A0C7 00108CC5 541D 01000000 F92A0000 00004600BE00000000000101 650E000200190400 112700009C3A00009D3A00009E3A0000 00000000000000000100000000000000060000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004000000000000000000000001000000000000000000000000 4D006100720079006400610069006C006C0065000000 00000000 09130810000000001E1716001001150010000C0D0000000F1517101517100C09 00000000
            WriteH(writer, 0); //Name shift
            WriteH(writer, 0); //Legion shift
            WriteH(writer, 0); //Unk1 shift
            WriteH(writer, 0); //Details shift
            WriteH(writer, (short) Player.PlayerData.Details.Length); //2000
            WriteH(writer, 0); //Unk2 shift
            WriteH(writer, 0); //Unk3 shift

            WriteD(writer, 11);
            WriteD(writer, Player.PlayerId);

            WriteUid(writer, Player);
            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Y);
            WriteF(writer, Player.Position.Z);
            WriteH(writer, Player.Position.Heading); //ED60
            WriteD(writer, Relation.GetHashCode());
            WriteD(writer, Player.PlayerData.SexRaceClass);

            WriteB(writer, "00004600AA00000000000101"); //???

            WriteB(writer, Player.PlayerData.Data);
            //WriteB(writer, Funcs.HexToBytes("651D040301000500"));

            WriteD(writer, Player.Inventory.GetItemId(1) ?? 0); //Item (hands)
            WriteD(writer, Player.Inventory.GetItemId(3) ?? 0); //Item (body)
            WriteD(writer, Player.Inventory.GetItemId(4) ?? 0); //Item (gloves)
            WriteD(writer, Player.Inventory.GetItemId(5) ?? 0); //Item (shoes)

            WriteB(writer, "00000000000000000100000000000000060000000000000000000000000000000000000000000000000000000000");

            WriteD(writer, Player.Inventory.GetItem(1) != null ? Player.Inventory.GetItem(1).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(3) != null ? Player.Inventory.GetItem(3).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(4) != null ? Player.Inventory.GetItem(4).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(5) != null ? Player.Inventory.GetItem(5).Color : 0);

            WriteB(writer, "00000000000004000000000000000000000001000000000000000000000000");

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length); //Name shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, Player.PlayerData.Name); //Name

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length); //Legion shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, ""); //Legion name //TODO:

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length); //Unk1 shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, ""); //Unk1

            writer.Seek(10, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length); //Details shift
            writer.Seek(0, SeekOrigin.End);
            WriteB(writer, Player.PlayerData.Details);

            writer.Seek(12, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length); //Unk2 shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, ""); //Unk2

            writer.Seek(14, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length); //Unk3 shift
            writer.Seek(0, SeekOrigin.End);
            WriteS(writer, ""); //Unk3
        }
    }
}