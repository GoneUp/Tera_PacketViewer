using Communication.Logic;
using Data.Structures.Player;

namespace Network.Client
{
    public class RpAttack : ARecvPacket
    {
        protected UseSkillArgs Args = new UseSkillArgs();

        public override void Read()
        {
            Args.SkillId = ReadD() - 0x4000000;

            Args.StartPosition.Heading = (short)ReadH();
            Args.StartPosition.X = ReadF();
            Args.StartPosition.Y = ReadF();
            Args.StartPosition.Z = ReadF();

            Args.TargetPosition.X = ReadF();
            Args.TargetPosition.Y = ReadF();
            Args.TargetPosition.Z = ReadF();

            ReadC(); //mb target count
            ReadC(); //mb target count
            ReadC(); //???
            ReadQ(); //mb targetid
        }

        public override void Process()
        {
            PlayerLogic.UseSkill(Connection, Args);
        }
    }
}