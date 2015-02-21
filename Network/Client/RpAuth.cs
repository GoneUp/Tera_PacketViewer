using System.Text;

namespace Network.Client
{
    public class RpAuth : ARecvPacket
    {
        protected string AccountName;
        protected string Session;

        public override void Read()
        {
            ReadH(); //unk1
            ReadH(); //unk2
            int length = ReadH();
            ReadB(5); //unk3
            ReadD(); //unk4
            ReadS(); //AccountName !!! ???

            string ticket = Encoding.ASCII.GetString(ReadB(length));
            AccountName = ticket.Substring(0, ticket.IndexOf('='));
            Session = ticket.Substring(AccountName.Length + 1);
        }

        public override void Process()
        {
            Communication.Logic.AccountLogic.TryAuthorize(Connection, AccountName, Session);
        }
    }
}