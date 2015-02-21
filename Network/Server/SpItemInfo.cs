using System.IO;

namespace Network.Server
{
    public class SpItemInfo : ASendPacket
    {
        protected int ItemId;
        protected long ItemUniqueId;
        protected string CreatorName;
        protected string SoulboundName;

        public SpItemInfo(int itemId, long itemUniqueId, string creatorName = "", string soulboundName = "")
        {
            ItemId = itemId;
            ItemUniqueId = itemUniqueId;
            CreatorName = creatorName;
            SoulboundName = soulboundName;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0);
            int creatorShift = (int) writer.BaseStream.Position;
            WriteH(writer, 0); //Creator name shift?
            int soulboundShift = (int) writer.BaseStream.Position;
            WriteH(writer, 0); //Soulbound name shift
            WriteH(writer, 19); //19
            WriteH(writer, 0);

            WriteQ(writer, ItemUniqueId); //ItemUniqueId
            WriteD(writer, ItemId); //ItemId
            WriteQ(writer, ItemUniqueId); //ItemUniqueId

            WriteD(writer, 0); //???
            WriteD(writer, 0);
            WriteD(writer, 0); //???

            WriteD(writer, 0);
            WriteD(writer, 1);
            WriteD(writer, 1); //Count
            WriteD(writer, 0); //Enchant level
            WriteD(writer, 0);
            WriteC(writer, 1); //Can't trade
            WriteD(writer, 0);
            WriteD(writer, 0); //EffectId
            WriteD(writer, 0); //EffectId on enchant +3
            WriteD(writer, 0); //EffectId on enchant +6
            WriteD(writer, 0); //EffectId on enchant +9
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteH(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0); //Requires Identification Scroll to remove
            WriteC(writer, 0); //Masterwork
            WriteD(writer, 0);


            WriteC(writer, 0); //Show "Stats Totals when Equipped"

            //"Stats Totals when Equipped"
            WriteD(writer, 0); //Attack
            WriteD(writer, 0); //Defence
            WriteD(writer, 0); //Knockdown
            WriteD(writer, 0); //Resist to knockdown
            WriteF(writer, 0); //Crit chanse (float)
            WriteF(writer, 0); //Crit resist (float)
            WriteF(writer, 0); //Crit power (float)
            WriteD(writer, 0); //Damage
            WriteD(writer, 0); //Balance
            WriteD(writer, 0); //Attack speed
            WriteD(writer, 0); //Movement
            WriteD(writer, 0); //Binding (float)
            WriteD(writer, 0); //Poison (float)
            WriteD(writer, 0); //Stun (float)

            WriteD(writer, 0); //Add attack
            WriteD(writer, 0); //Add defence
            WriteD(writer, 0); //Add knockdown
            WriteD(writer, 0); //Add resist to knockdown
            WriteD(writer, 0); //Add crit chanse (float)
            WriteD(writer, 0); //Add crit resist (float)
            WriteD(writer, 0); //Add crit power (float)
            WriteD(writer, 0); //Add damage
            WriteD(writer, 0); //Add Balance
            WriteD(writer, 0); //Add attack speed
            WriteD(writer, 0); //Add movement
            WriteD(writer, 0); //Add Binding (float)
            WriteD(writer, 0); //Add poison (float)
            WriteD(writer, 0); //Add stun (float)

            WriteD(writer, 0); //Min attack
            WriteD(writer, 0); //Add min attack

            WriteD(writer, 3);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 1); //Item level
            WriteD(writer, 0);

            writer.Seek(creatorShift, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, CreatorName); //Creator name

            writer.Seek(soulboundShift, SeekOrigin.Begin);
            WriteH(writer, (short) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            WriteS(writer, SoulboundName); //Soulbound name
        }
    }
}