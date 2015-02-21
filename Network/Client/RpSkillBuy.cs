using Communication.Logic;

namespace Network.Client
{
    public class RpSkillBuy : ARecvPacket
    {
        protected int SkillId;
        protected bool IsActive;

        public override void Read()
        {
            ReadD(); //DialogId
            SkillId = ReadD();
            IsActive = ReadC() > 0;
        }

        public override void Process()
        {
            PlayerLogic.BuySkill(Connection.Player, SkillId, IsActive);
        }
    }
}