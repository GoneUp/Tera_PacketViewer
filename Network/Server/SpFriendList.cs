using System.Collections.Generic;
using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpFriendList : ASendPacket
    {
        public List<Player> Friends;

        public SpFriendList(List<Player> friends)
        {
            Friends = friends;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Friends.Count);

            if (Friends.Count > 0)
            {
                WriteH(writer, 8);
                for (int i = 0; i < Friends.Count; i++)
                {
                    WriteH(writer, (short) writer.BaseStream.Position);
                    int shift = (int) writer.BaseStream.Position;
                    WriteH(writer, 0); //end friend shift
                    WriteH(writer, 0); //start name shift
                    WriteH(writer, 0); //end name shift
                    WriteD(writer, Friends[i].PlayerId);
                    WriteD(writer, Friends[i].GetLevel());
                    WriteD(writer, Friends[i].PlayerData.Race.GetHashCode());
                    WriteD(writer, Friends[i].PlayerData.Class.GetHashCode());
                    WriteB(writer, "01000000010000000200000007000000");

                    writer.Seek(shift + 2, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);

                    WriteS(writer, Friends[i].PlayerData.Name);

                    writer.Seek(shift + 4, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);

                    WriteH(writer, 0);

                    if (Friends.Count - 1 > i)
                    {
                        writer.Seek(shift, SeekOrigin.Begin);
                        WriteH(writer, (short) writer.BaseStream.Length);
                        writer.Seek(0, SeekOrigin.End);
                    }
                }
            }
        }
    }
}