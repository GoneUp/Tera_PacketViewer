using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpRemoveAbnormal : ASendPacket
    {
        protected Abnormal Abnormal;

        public SpRemoveAbnormal(Abnormal abnormal)
        {
            Abnormal = abnormal;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Abnormal.Creature);
            WriteD(writer, Abnormal.Abnormality.Id);
        }
    }
}