using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpFriendAdd : ASendPacket
    {
        protected Player Friend;

        public SpFriendAdd(Player friend)
        {
            Friend = friend;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //name shift
            WriteD(writer, Friend.PlayerId);
            WriteD(writer, Friend.GetLevel());
            WriteD(writer, Friend.PlayerData.Race.GetHashCode());
            WriteD(writer, Friend.PlayerData.Class.GetHashCode());
            WriteB(writer, "0100000001000000020000000700000000");

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Friend.PlayerData.Name);
        }
    }
}