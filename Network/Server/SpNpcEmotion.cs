using System.IO;
using Data.Structures.Creature;

namespace Network.Server
{
    public class SpNpcEmotion : ASendPacket //len 32
    {
        protected Creature Creature;
        protected Creature Target;
        protected int Emotion;

        public SpNpcEmotion(Creature creature, Creature target, int emotion)
        {
            Creature = creature;
            Target = target;
            Emotion = emotion;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Creature);
            WriteUid(writer, Target);

            WriteD(writer, 0);
            WriteD(writer, Emotion);
            WriteD(writer, 0);
        }
    }
}