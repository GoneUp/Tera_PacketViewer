using Data.Enums;
using Data.Structures.Account;
using Data.Structures.Player;
using System.IO;

namespace Network.Server
{
    public class SpCharacterList : ASendPacket
    {
        protected Account Account;

        public SpCharacterList(Account account)
        {
            Account = account;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Account.Players.Count); //Characters count
            WriteH(writer, (short) (Account.Players.Count == 0 ? 0 : 27));
            WriteB(writer, new byte[9]);
            WriteD(writer, 8); //Max character count
            WriteD(writer, 1);
            WriteH(writer, 0);

            for (int i = 0; i < Account.Players.Count; i++)
            {
                Player player = Account.Players[i];

                short check1 = (short) writer.BaseStream.Position;
                WriteH(writer, check1); //Check1
                WriteH(writer, 0); //Check2
                WriteH(writer, 0); //Name shift
                WriteH(writer, 0); //Details shift
                WriteH(writer, (short) player.PlayerData.Details.Length); //Details length

                WriteD(writer, player.PlayerId); //PlayerId
                WriteD(writer, player.PlayerData.Gender.GetHashCode()); //Gender
                WriteD(writer, player.PlayerData.Race.GetHashCode()); //Race
                WriteD(writer, player.PlayerData.Class.GetHashCode()); //Class
                WriteD(writer, player.GetLevel()); //Level

                WriteB(writer, "260B000087050000"); //A0860100A0860100
                WriteB(writer, player.ZoneDatas ?? new byte[12]);
                WriteD(writer, player.LastOnline);
                WriteB(writer, "00000000008F480900000000006AD376B0"); //Unk
                //WriteB(writer, "000000A0860100A0860100000000000000 00000000 00008F7E 00000000 0000000F B9090000 00000001 91DDB1"); //New character, play start video
                WriteD(writer, player.Inventory.GetItemId(1) ?? 0); //Item (hands)
                WriteD(writer, 0); //Item (earing1?)
                WriteD(writer, 0); //Item (earing2?)
                WriteD(writer, player.Inventory.GetItemId(3) ?? 0); //Item (body)
                WriteD(writer, player.Inventory.GetItemId(4) ?? 0); //Item (gloves)
                WriteD(writer, player.Inventory.GetItemId(5) ?? 0); //Item (boots)
                WriteD(writer, 0); //Item (ring1)
                WriteD(writer, 0); //Item (ring2)
                WriteD(writer, 0); //Item ?
                WriteD(writer, 0); //Item ?
                WriteD(writer, 0); //Item ?

                WriteB(writer, player.PlayerData.Data);
                WriteC(writer, 0); //Offline?
                WriteB(writer, "0000000000000000000000000089E66EB0"); //???
                WriteB(writer, new byte[48]);

                WriteD(writer, player.Inventory.GetItem(1) != null ? player.Inventory.GetItem(1).Color : 0);
                WriteD(writer, player.Inventory.GetItem(3) != null ? player.Inventory.GetItem(3).Color : 0);
                WriteD(writer, player.Inventory.GetItem(4) != null ? player.Inventory.GetItem(4).Color : 0);
                WriteD(writer, player.Inventory.GetItem(5) != null ? player.Inventory.GetItem(5).Color : 0);

                WriteB(writer, new byte[28]); //16 bytes possible colors

                WriteD(writer, 0); //Rested (current)
                WriteD(writer, 10000); //Rested (max)
                                
                WriteC(writer, 1);
                WriteC(writer, (byte) (player.Exp == 0 ? 1 : 0)); //Intro video flag

                WriteD(writer, 0); //Now start only in Island of Dawn
                //WriteD(writer, player.Exp == 0 ? 1 : 0); //Prolog or IslandOfDawn dialog window

                writer.Seek(check1 + 4, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length); //Name shift
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, player.PlayerData.Name);

                writer.Seek(check1 + 6, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length); //Details shift
                writer.Seek(0, SeekOrigin.End);

                WriteB(writer, player.PlayerData.Details);

                if (i != Account.Players.Count - 1)
                {
                    writer.Seek(check1 + 2, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length); //Check2
                    writer.Seek(0, SeekOrigin.End);
                }
            }
        }
    }
}