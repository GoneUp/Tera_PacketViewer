using System.IO;
using Data.Enums;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpCharacterEmotions : ASendPacket
    {
        protected Creature Creature;
        protected int EmotionId;
        protected int Duration;

        public SpCharacterEmotions(Creature creature, int emotionId, int duration = 0)
        {
            Creature = creature;
            EmotionId = emotionId;
            Duration = duration;
        }

        public SpCharacterEmotions(Creature creature, PlayerEmotion emotion, int duration = 0)
        {
            Creature = creature;
            EmotionId = emotion.GetHashCode();
            Duration = duration;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteD(writer, EmotionId);
            WriteD(writer, Duration);
            WriteC(writer, 0); //unk
        }
    }
}