namespace Network.Client
{
    public class RpCharacterEmotion : ARecvPacket
    {
        protected int EmotionId;

        public override void Read()
        {
            EmotionId = ReadD();
        }

        public override void Process()
        {
            Communication.Global.EmotionService.StartEmotion(Connection.Player, EmotionId);
        }
    }
}