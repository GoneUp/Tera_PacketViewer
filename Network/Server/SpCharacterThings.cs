using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterThings : ASendPacket
    {
        protected Player Player;

        public SpCharacterThings(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteUid(writer, Player);

            WriteD(writer, Player.Inventory.GetItemId(1) ?? 0); //Item (hands)
            WriteD(writer, Player.Inventory.GetItemId(3) ?? 0); //Item (body)
            WriteD(writer, Player.Inventory.GetItemId(4) ?? 0); //Item (gloves)
            WriteD(writer, Player.Inventory.GetItemId(5) ?? 0); //Item (shoes)
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???

            WriteD(writer, Player.Inventory.GetItem(1) != null ? Player.Inventory.GetItem(1).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(3) != null ? Player.Inventory.GetItem(3).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(4) != null ? Player.Inventory.GetItem(4).Color : 0);
            WriteD(writer, Player.Inventory.GetItem(5) != null ? Player.Inventory.GetItem(5).Color : 0); WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???
            WriteD(writer, 0); //Item ???
        }
    }
}