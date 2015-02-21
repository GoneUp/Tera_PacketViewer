using System.IO;
using Data.Enums.Gather;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterInspect : ASendPacket
    {
        protected Player Player;

        public SpCharacterInspect(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 5);
            WriteH(writer, 0); // Items shift
            
            WriteD(writer, 0);

            WriteH(writer, 0); // Name shift
            WriteH(writer, 0); // Name end
            // Unk shifts
            WriteH(writer, 0); // Name end + 2
            WriteH(writer, 0); // Name end + 4

            WriteD(writer, Player.PlayerData.SexRaceClass);
            WriteUid(writer, Player);

            WriteQ(writer, 0x6f3);
            WriteD(writer, 0x46);

            WriteH(writer, (short)Player.Level);
            WriteGatherStats(writer, Player);

            WriteH(writer, 2);
            WriteH(writer, 0x40d1);
            WriteD(writer, 0);
            WriteH(writer, 0);

            // Experience
            WriteQ(writer, Player.GetExpShown());
            WriteQ(writer, Player.GetExpNeed());

            WriteD(writer, 0);
            WriteD(writer, 0x90b202);
            WriteD(writer, 0x501403);
            WriteD(writer, 0xa0f3a0);

            WriteD(writer, 0x4533);
            WriteD(writer, 0);
            WriteD(writer, 0);

            WriteStats(writer, Player);

            WriteH(writer, 3);
            WriteD(writer, 0x76);
            WriteD(writer, 0x78);

            // Levels
            WriteD(writer, 1); // Item level
            WriteD(writer, 1); // Inventory level

            WriteB(writer, new byte[14]);

            // Name
            writer.Seek(12, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); // Name shift
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, Player.PlayerData.Name);

            writer.Seek(14, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); // Name end
            writer.Seek(0, SeekOrigin.End);

            WriteH(writer, 0);
            writer.Seek(16, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); // Unk1 shift
            writer.Seek(0, SeekOrigin.End);

            WriteH(writer, 0);
            writer.Seek(18, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); // Unk2 shift
            writer.Seek(0, SeekOrigin.End);

            WriteH(writer, 0);
            writer.Seek(6, SeekOrigin.Begin);
            WriteH(writer, (short)writer.BaseStream.Length); // Items shift
            writer.Seek(0, SeekOrigin.End);

            short lastShift = -1;
            lock(Player.Inventory.ItemsLock)
                for (int i = 0; i < 20; i++)
                    if (Player.Inventory.Items.ContainsKey(i))
                    {
                        // this shift
                        WriteH(writer, (short)writer.BaseStream.Length);
                        lastShift = (short)writer.BaseStream.Length;
                        // next item shift
                        WriteH(writer, 0);

                        WriteD(writer, Player.Inventory.Items[i].ItemId);

                        WriteUid(writer, Player.Inventory.Items[i]);

                        WriteD(writer, 0x6f3);
                        WriteD(writer, 0);

                        WriteD(writer, i);
                        WriteD(writer, 0);
                        WriteD(writer, Player.Inventory.Items[i].ItemTemplate.Level);
                        WriteB(writer, new byte[94]);

                        writer.Seek(lastShift, SeekOrigin.Begin);
                        WriteH(writer, (short)writer.BaseStream.Length);
                        writer.Seek(0, SeekOrigin.End);
                    }

            if (lastShift == -1)
                return;

            writer.Seek(lastShift, SeekOrigin.Begin);
            WriteH(writer, 0);
            writer.Seek(0, SeekOrigin.End);
        }
    }
}
