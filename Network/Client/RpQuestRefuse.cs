namespace Network.Client
{
    public class RpQuestRefuse : ARecvPacket
    {
        protected int QuestId;

        public override void Read()
        {
            ReadD(); // Unk
            ReadD(); // 8
            QuestId = ReadD();
        }

        public override void Process()
        {
            lock (Connection.Player.QuestsLock)
            {
                if(!Connection.Player.Quests.ContainsKey(QuestId))
                    return;

                Connection.Player.Quests.Remove(QuestId);
            }
        }
    }
}
