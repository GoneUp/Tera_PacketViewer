using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpSkillList : ASendPacket
    {
        protected Player Player;

        public SpSkillList(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Player.Skills.Count);
            WriteH(writer, 8);

            short shift = 8;
            int counter = 1;
            foreach (var skill in Player.Skills)
            {
                WriteH(writer, shift);
                shift += 9;
                WriteH(writer, (short) (counter++ != Player.Skills.Count ? shift : 0));
                WriteD(writer, skill);

                WriteC(writer,
                       (byte)
                       (!global::Data.Data.UserSkills[Player.TemplateId].ContainsKey(skill) ||
                        global::Data.Data.UserSkills[Player.TemplateId][skill].IsActive
                            ? 1
                            : 0));
            }
            //B089 0700 0800 0800 1100 74270000 01 1100 1A00 C4EA0000 01 1A00 2300 C4A28900 01 2300 2C00 12270000002C003500644B00000035003E00654B0000003E000000664B000000
        }
    }
}