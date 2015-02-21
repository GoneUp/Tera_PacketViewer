using System.IO;
using Data.Structures.Player;
using Data.Structures.World;

namespace Network.Server
{
    public class SpTradeWindow : ASendPacket
    {
        protected Player Player1;
        protected Player Player2;
        protected Storage Storage1;
        protected Storage Storage2;
        protected int UID;

        public SpTradeWindow(Player me, Player other, Storage mine, Storage their, int uid)
        {
            Player1 = me;
            Player2 = other;
            Storage1 = mine;
            Storage2 = their;
            UID = uid;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0); //my items start shift
            WriteH(writer, 0); //my items lenth
            WriteH(writer, 0); //other player items start shift
            WriteH(writer, 0); //other player items lenth

            WriteUid(writer, Player1);
            WriteUid(writer, Player2);

            WriteD(writer, UID);
            WriteD(writer, Storage1.Locked ? 1 : 0); // is my locked
            WriteQ(writer, Storage1.Money); // my money
            WriteD(writer, Storage2.Locked ? 1 : 0); // is thier locked
            WriteQ(writer, Storage2.Money); // their money

            short len = (short) writer.BaseStream.Length;

            writer.Seek(4, SeekOrigin.Begin);
            WriteH(writer, len);
            writer.Seek(0, SeekOrigin.End);

            lock (Storage1.ItemsLock)
            {
                foreach (StorageItem item in Storage1.Items.Values)
                {
                    WriteD(writer, 0);
                    WriteD(writer, item.ItemTemplate.Id);
                    WriteD(writer, item.Count);
                    WriteUid(writer, item);
                    WriteD(writer, 0);
                    WriteC(writer, 0);
                }
            }

            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short) (writer.BaseStream.Length - len));
            writer.Seek(0, SeekOrigin.End);

            len = (short) writer.BaseStream.Length;

            writer.Seek(8, SeekOrigin.Begin);
            WriteH(writer, len);
            writer.Seek(0, SeekOrigin.End);

            lock (Storage2.ItemsLock)
            {
                foreach (StorageItem item in Storage2.Items.Values)
                {
                    WriteD(writer, 0);
                    WriteD(writer, item.ItemTemplate.Id);
                    WriteD(writer, item.Count);
                    WriteUid(writer, item);
                    WriteD(writer, 0);
                    WriteC(writer, 0);
                }
            }

            writer.Seek(10, SeekOrigin.Begin);
            WriteH(writer, (short) (writer.BaseStream.Length - len));
            writer.Seek(0, SeekOrigin.End);
        }
    }
}