using Communication.Logic;
using Data.Structures.Player;

namespace Network.Client
{
    public class RpTargetAttack : ARecvPacket
    {
        protected UseSkillArgs Args = new UseSkillArgs {IsTargetAttack = true};

        public override void Read()
        {
            short targetCount = (short) ReadH();
            ReadH(); //Shifts
            ReadD(); //Shifts

            Args.SkillId = ReadD() - 0x4000000;

            Args.StartPosition.X = ReadF();
            Args.StartPosition.Y = ReadF();
            Args.StartPosition.Z = ReadF();
            Args.StartPosition.Heading = (short)ReadH();
            ReadC(); //unk

            if (targetCount-- > 0)
            {
                ReadD(); //shifts
                ReadD();
                Args.AddTarget(ReadQ());
            }

            ReadD(); //shifts
            Args.TargetPosition.X = ReadF();
            Args.TargetPosition.Y = ReadF();
            Args.TargetPosition.Z = ReadF();

            //Other Targets
            while (targetCount-- > 0)
            {
                ReadD(); //shifts
                ReadD();
                ReadQ(); //TargetUid
            }
        }

        public override void Process()
        {
            PlayerLogic.UseSkill(Connection, Args);
        }
    }
}