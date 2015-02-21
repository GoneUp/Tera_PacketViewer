using System.IO;
using Data.Enums;
using Data.Structures.Npc;

namespace Network.Server
{
    public class SpNpcIcon : ASendPacket //len 17
    {
        protected Npc Npc;
        protected QuestStatusIcon Icon;
        protected byte Status; // 0x00, 0x01 or something else %)

        public SpNpcIcon(Npc npc, QuestStatusIcon icon, byte status)
        {
            Npc = npc;
            Icon = icon;
            Status = status;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Npc);
            WriteD(writer, Icon.GetHashCode());
            WriteC(writer, Status);
        }
    }
}