using System.IO;

namespace Network.Server
{
    public class SpDeathDialog : ASendPacket
    {
        protected int CurrentSection;

        public SpDeathDialog(int currentSection)
        {
            CurrentSection = currentSection;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 30); //Timeout in minutes
            WriteD(writer, CurrentSection);
            WriteD(writer, 0);
            WriteH(writer, 0);
        }
    }
}