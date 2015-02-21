using System.Collections.Generic;
using System.IO;
using Data.Structures.Craft;
using Utils;

namespace Network.Server
{
    public class SpCharacterRecipes : ASendPacket
    {
        protected List<Recipe> Recipes = new List<Recipe>();
        protected bool IsForCraftReset;

        /// <summary>
        /// Send when need to update recipes or reset craft process
        /// </summary>
        /// <param name="recipes">Can be null, when send for craft reset</param>
        /// <param name="isForCraftReset"> </param>
        public SpCharacterRecipes(List<Recipe> recipes, bool isForCraftReset = false)
        {
            Recipes = recipes;
            IsForCraftReset = isForCraftReset;
        }

        public override void Write(BinaryWriter writer)
        {
            if(IsForCraftReset)
            {
                WriteD(writer, 0);
                WriteC(writer, 1);
                WriteC(writer, 1);
                return;
            }

            WriteH(writer, (short) Recipes.Count);
            WriteD(writer, 0); // first recipe shift

            writer.Seek(6, SeekOrigin.Begin);
            WriteD(writer, (int) writer.BaseStream.Length);
            writer.Seek(0, SeekOrigin.End);

            for (int i = 0; i < Recipes.Count; i++)
            {
                WriteH(writer, (short)writer.BaseStream.Length);
                short recShift = (short) writer.BaseStream.Length;
                WriteH(writer, 0);

                WriteH(writer, (short) Recipes[i].NeededItems.Count);
                WriteH(writer, 0); //items start shift

                WriteD(writer, Recipes[i].RecipeId);
                WriteD(writer, Recipes[i].CraftStat.GetHashCode());
                WriteD(writer, 0); // O_o
                WriteD(writer, Recipes[i].ResultItem.Key); //itemid
                WriteD(writer, Recipes[i].ResultItem.Value); //counter
                WriteD(writer, Recipes[i].Level);
                WriteQ(writer, Funcs.GetRoundedUtc());
                WriteC(writer, 0);
                WriteD(writer, Recipes[i].NeededItems.Count);

                writer.Seek(recShift + 4, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                int counter = 1;
                foreach (KeyValuePair<int, int> itm in Recipes[i].NeededItems)
                {
                    WriteH(writer, (short) writer.BaseStream.Length);

                    short sh1 = (short) writer.BaseStream.Length;

                    WriteH(writer, 0);

                    WriteD(writer, itm.Key); //itemid
                    WriteD(writer, itm.Value); //counter

                    if (counter < Recipes[i].NeededItems.Count)
                    {
                        writer.Seek(sh1, SeekOrigin.Begin);
                        WriteH(writer, (short) writer.BaseStream.Length);
                        writer.Seek(0, SeekOrigin.End);
                    }
                    counter++;
                }

                if (i + 1 < Recipes.Count)
                {
                    writer.Seek(recShift, SeekOrigin.Begin);
                    WriteH(writer, (short)writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
            }
        }
    }
}
