using System.IO;
using Data.Enums;
using Data.Structures.Player;
using Data.Structures.World.Requests;

namespace Network.Server
{
    public class SpShowWindow : ASendPacket
    {
        public static int TradeConfirm = 3;
        public static int PartyConfirm = 4;
        public static int PartyAcceptConfirm = 5;
        public static int Mailbox = 8;
        public static int Inventory = 9;
        public static int GuildConfirm = 10;
        public static int DuelConfirm = 14;
        public static int WorldTeleport = 17;
        public static int DeathmatchConfirm = 21;
        public static int Inventory2 = 23;
        public static int DeathmatchBet = 27;
        public static int Bank = 28;
        public static int LearnSkills = 29;
        public static int BattleGroupConfirm = 30;
        public static int Extraction = 31;
        public static int SoulbindStatusLine = 34;
        public static int CombiningStatusLine = 35;
        public static int Enchant = 36;
        public static int Negotiating = 38;
        public static int Remodel = 42;
        public static int RestoreAppearance = 43;
        public static int Dye = 44;
        public static int StartGvGBattle = 46;
        public static int GvGSurrender = 47;


        protected Player Player;
        protected int Type;

        /// <summary>
        /// A request, that will be sent by this packet
        /// </summary>
        protected Request Request;

        /// <summary>
        /// Show window
        /// </summary>
        /// <param name="request">Request that will be displayed</param>
        public SpShowWindow(Request request)
        {
            Request = request;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //Player NameShift
            WriteH(writer, 0); //Target NameShift
            WriteH(writer, 0); //Packet Length
            WriteH(writer, (short) (Request.Type == RequestType.Extraction ? 4 : 0));

            WriteUid(writer, Request.Owner);
            WriteUid(writer, Request.Target);

            WriteD(writer, Request.Type.GetHashCode());
            WriteD(writer, Request.UID);
            WriteD(writer, 0);
            WriteD(writer, Request.Timeout);

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Request.Owner.PlayerData.Name);
            WriteH(writer, 0);

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            if (Request.Target != null)
                WriteS(writer, Request.Target.PlayerData.Name);
            else
                WriteH(writer, 0);
            WriteH(writer, 0);

            if (Request.Type == RequestType.Extraction)
                WriteD(writer, 0); // ExtractSubtype

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);
        }
    }
}