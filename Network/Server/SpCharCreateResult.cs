using System.IO;

namespace Network.Server
{
    public class SpCharacterCreateResult : ASendPacket
    {
        protected byte IsValid;

        public SpCharacterCreateResult(byte isValid)
        {
            IsValid = isValid;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, IsValid);
        }
    }
}