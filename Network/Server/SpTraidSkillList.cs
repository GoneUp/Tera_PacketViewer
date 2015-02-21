using System.Collections.Generic;
using System.IO;
using Data.Structures.Player;
using Data.Structures.SkillEngine;

namespace Network.Server
{
    public class SpTraidSkillList : ASendPacket
    {
        protected Player Player;
        protected List<UserSkill> SkillList;

        public SpTraidSkillList(Player player, List<UserSkill> skillList)
        {
            Player = player;
            SkillList = skillList;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) SkillList.Count);
            short nextShift = (short)writer.BaseStream.Position;
            WriteH(writer, 0);

            for (int i = 0; i < SkillList.Count; i++)
            {
                writer.Seek(nextShift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) writer.BaseStream.Length); //now shift
                nextShift = (short) writer.BaseStream.Position;
                WriteH(writer, 0); //next shift

                WriteH(writer, (short) (SkillList[i].PrevSkillId != 0 ? 1 : 0));
                short prevSkillShift = (short)writer.BaseStream.Position;
                WriteH(writer, 0);

                WriteD(writer, 0); //Unk

                WriteD(writer, SkillList[i].SkillId);
                WriteC(writer, 1); // IsActive
                WriteD(writer, SkillList[i].Cost);
                WriteD(writer, SkillList[i].Level);
                WriteC(writer, (byte) (Player.GetLevel() >= SkillList[i].Level ? 1 : 0));

                if (SkillList[i].PrevSkillId != 0)
                {
                    writer.Seek(prevSkillShift, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);

                    WriteH(writer, (short) writer.BaseStream.Length);
                    WriteH(writer, 0); //next shift

                    WriteD(writer, SkillList[i].PrevSkillId);
                    WriteC(writer, 1); //IsActive
                }
            }
        }
    }
}