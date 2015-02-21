namespace Network.Client
{
    public class RpQuestTopSwitch : ARecvPacket
    {
        protected int QuestId;
        protected byte VisiblitySwitch;
        protected int Unk1; // 0x01

        public override void Read()
        {
            QuestId = ReadD();
            VisiblitySwitch = (byte) ReadC();
            Unk1 = ReadD();
        }

        public override void Process()
        {
            
        }
    }
}