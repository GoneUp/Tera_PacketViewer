using Communication.Logic;
using Data.Enums;
using Data.Structures.Player;

namespace Network.Client
{
    public class RpCreateCharacter : ARecvPacket
    {
        protected PlayerData PlayerData = new PlayerData();

        public override void Read()
        {
            //shifts
            short nameShift = (short) ReadH();
            short detailsShift = (short) ReadH();
            short detailsLength = (short) ReadH();

            PlayerData.Gender = (Gender) ReadD();
            PlayerData.Race = (Race) ReadD();
            PlayerData.Class = (PlayerClass) ReadD();
            PlayerData.Data = ReadB(8);
            ReadC();
            PlayerData.Name = ReadS();
            PlayerData.Details = ReadB(detailsLength);
        }

        public override void Process()
        {
            PlayerLogic.CreateCharacter(Connection, PlayerData);
        }
    }
}