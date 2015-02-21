using System.IO;
using Data.Structures.Npc;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpUpdateExp : ASendPacket
    {
        protected Player Player;
        protected long Added;
        protected Npc Npc;

        public SpUpdateExp(Player player, long added, Npc npc = null)
        {
            Player = player;
            Added = added;
            Npc = npc;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, Added);
            WriteQ(writer, Player.Exp);
            WriteQ(writer, Player.GetExpShown());
            WriteQ(writer, Player.GetExpNeed());
            WriteUid(writer, Npc);

            /*new EXP params like death penalty or something else*/

            WriteQ(writer, 0);
            WriteD(writer, 0);
            WriteB(writer, "461600000000803F00000000");
        }
    }
}