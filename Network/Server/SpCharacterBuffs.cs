using System.IO;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Network.Server
{
    public class SpCharacterBuffs : ASendPacket
    {
        protected Player Player;

        public SpCharacterBuffs(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
       //0773 0500 1600 0100000000000000 3C000000 0000 1600 2200 00000000 00000000 2200 2E00 FFFFFFFF 00000000 2E00 3A00 FFFFFFFF 00000000 3A00 4600 FFFFFFFF 00000000 4600 0000 FFFFFFFF 00000000
            //WriteH(writer, (short)Player.Effects.Count); //effects counter?
            //WriteH(writer, 0); //first abnormal shift
            //WriteQ(writer, 1);//???
            //WriteD(writer, 60); //???
            //WriteH(writer, 0);
            ////WriteD(writer, Skill.Id);
            //WriteB(writer, "FFFFFF7F"); //???
            //WriteC(writer, 0x01);
        }
    }
}