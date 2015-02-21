using System.Collections.Generic;
using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpFriendUpdate : ASendPacket
    {
        protected List<Player> Friends = new List<Player>();

        public SpFriendUpdate(List<Player> friends)
        {
            for (int i = 0; i < friends.Count; i++)
            {
                if (Communication.Global.PlayerService.IsPlayerOnline(friends[i]) && friends[i].Connection != null)
                    Friends.Add(friends[i]);
            }
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Friends.Count);

            var shift = (int) writer.BaseStream.Position;
            WriteH(writer, 0);

            for (int i = 0; i < Friends.Count; i++)
            {
                writer.Seek(shift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) writer.BaseStream.Position);
                shift = (int) writer.BaseStream.Position;
                WriteH(writer, 0); //next friend shift
                WriteD(writer, Friends[i].PlayerId);
                WriteD(writer, Friends[i].GetLevel());
                WriteB(writer, "00000000010000000200000007000000");
                WriteH(writer, 0);
            }
        }
    }
}