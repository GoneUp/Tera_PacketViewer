using System.IO;
using Data.Structures.World.Requests;

namespace Network.Server
{
    //9AD7 1600 2800 0601 0A000000 E5CF0600 3F020000 4D00650074006100770069006E00640000004E00650077007400650072006100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004700750069006C0064006D0061007300740065007200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005200650063007200750069007400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
    public class SpRequestInvite : ASendPacket
    {
        protected Request Request;

        public SpRequestInvite(Request request)
        {
            Request = request;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //name start shift
            WriteH(writer, 0); //name end shift
            WriteH(writer, 0); //???
            WriteD(writer, Request.Type.GetHashCode());
            WriteUid(writer, Request);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Request.Owner.PlayerData.Name);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End); //76

            if(Request is GuildCreate)
                WriteS(writer, ((GuildCreate)Request).GuildName);
            else if(Request is GuildInvite)
                WriteS(writer, Request.Owner.Guild != null ? Request.Owner.Guild.GuildName : "Unknown guild");
            else
                WriteS(writer, Request.Target.PlayerData.Name);

            short shift = (short) (writer.BaseStream.Length + 76);

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, shift);
            writer.Seek(0, SeekOrigin.End);

            if (Request is GuildCreate)
                WriteB(writer,
                       "250A87020000001A250A0C1A250A58E4380000CD89DB001A250AD0E6DDE300CD89DB0C1A250A80E4380028B44A000C1A250A5F864700750069006C0064006D006100730074006500720000000000A0E438003DC25200650063007200750069007400000043D600CD89DB908F6EE0BCE4380004C3");
        }
    }
}