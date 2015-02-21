using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpChatInfo : ASendPacket
    {
        protected Player Player;
        protected int Type; // 1 - whisper, friend, block, report; other - whisper, friend, follow

        public SpChatInfo(Player player, int type)
        {
            Player = player;
            Type = type;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //name start shift
            WriteD(writer, Type);
            WriteD(writer, Player.PlayerData.SexRaceClass);
            WriteD(writer, Player.GetLevel());

            WriteH(writer, 1);
            WriteH(writer, 11);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Player.PlayerData.Name);
        }
    }
}