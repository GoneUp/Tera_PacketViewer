using System.IO;

namespace Network.Server
{
    public class SpQuestComplite : ASendPacket
    {
        protected int QuestId;

        public SpQuestComplite(int questId)
        {
            QuestId = questId;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, QuestId);
            WriteD(writer, QuestId); //QuestUId???
            WriteH(writer, 0);
        }
    }
}