using Communication.Logic;

namespace Network.Client
{
    public class RpCheckVersion : ARecvPacket
    {
        protected int Version;

        public override void Read()
        {
            return;

            // ReSharper disable CSharpWarnings::CS0162
            // ReSharper disable HeuristicUnreachableCode
            int count = ReadH();
            ReadH(); //First shift

            for (int i = 0; i < count; i++)
            {
                ReadD(); //NowShift & NextShift
                ReadD(); //Unk1
                ReadD(); //Unk2
            }
            // ReSharper restore HeuristicUnreachableCode
            // ReSharper restore CSharpWarnings::CS0162
        }

        public override void Process()
        {
            GlobalLogic.CheckVersion(Connection, OpCodes.Version);
        }
    }
}