using System;
using System.IO;
using Data.Enums;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpChatMessage : ASendPacket
    {
        protected Player Player;
        protected string Message;
        protected ChatType Type;

        public SpChatMessage(Player player, string message, ChatType type)
        {
            Player = player;
            Message = message;
            Type = type;
        }

        public SpChatMessage(string message, ChatType type)
        {
            Player = null;
            Message = " " + message;
            Type = type;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //Sender shift
            WriteH(writer, 0); //Message shift
            WriteD(writer, Type.GetHashCode());

            WriteUid(writer, Player);

            byte isGm = 0;

            if (Player != null)
                isGm = (byte)(Communication.Global.AdminEngine.IsGM(Player) ? 1 : 0);

            WriteC(writer, 0); //Blue shit
            WriteC(writer, isGm); //GM

            if (Player != null)
            {
                writer.Seek(4, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteS(writer, Player.PlayerData.Name);
            }

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Message);

            WriteC(writer, 0);
        }
    }
}