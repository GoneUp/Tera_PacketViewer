using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpAbnormal : ASendPacket
    {
        protected Abnormal Abnormal;

        public SpAbnormal(Abnormal abnormal)
        {
            Abnormal = abnormal;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Abnormal.Creature);
            WriteUid(writer, Abnormal.Caster);

            WriteD(writer, Abnormal.Abnormality.Id);
            WriteD(writer, Abnormal.Abnormality.Time);
            WriteD(writer, 1); //Type?
        }
    }
}