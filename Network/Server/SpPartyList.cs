using System.Collections.Generic;
using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpPartyList : ASendPacket
        //1FAD 0200 3000 3000 0000000B0000000C00B503B5030000 901E0C00 01000000030000000000010000000100000000 3000 6300 5300 B5030000 901E0C00 01000000 04000000 01 7E00B50300800000 00000000 64006D00680061006C00790061000000        6300 0000 8600 B5030000 F84B0A00 01000000 00000000 01 E900B50300800000 00000000 460069007200650046006F00780079000000
        //9CBD 0200 3000 3000 0000006416000007000B000B000000 FD8D0000 01000000030000000000010000000100000000 3000 6500 5300 0B000000 FD8D0000 04000000 06000000 014C6C0B0000800001000000004D00650074006100770069006E00640000006500000088000B000000A72500000C00000005000000016C6E0B00008000010000000045006C0061000000
    {
        protected List<Player> PartyPlayers;

        public SpPartyList(List<Player> partyPlayers)
        {
            PartyPlayers = partyPlayers;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) PartyPlayers.Count); //counter of party members
            WriteH(writer, 0); //first name begin shift
            WriteH(writer, 0); //first name begin shift
            WriteB(writer, "0000006416000007000B000B000000");
            WriteD(writer, PartyPlayers[0].PlayerId);
            WriteB(writer, "01000000030000000000010000000100000000");


            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            for (int i = 0; i < PartyPlayers.Count; i++)
            {
                WriteH(writer, (short) writer.BaseStream.Length);
                short nextPlShift = (short) writer.BaseStream.Length;
                WriteH(writer, 0); // next player begin shift
                WriteH(writer, 0); // name begin shift
                WriteD(writer, 11);// -_-
                WriteD(writer, PartyPlayers[i].PlayerId);
                WriteD(writer, PartyPlayers[i].GetLevel());
                WriteD(writer, PartyPlayers[i].PlayerData.Class.GetHashCode());
                WriteC(writer, (byte)Communication.Global.PlayerService.IsPlayerOnline(PartyPlayers[i]).GetHashCode());
                WriteUid(writer, PartyPlayers[i]);
                WriteD(writer, 0);

                writer.Seek(nextPlShift + 2, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, PartyPlayers[i].PlayerData.Name);

                if (PartyPlayers.Count > i + 1)
                {
                    writer.Seek(nextPlShift, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
            }
        }
    }
}