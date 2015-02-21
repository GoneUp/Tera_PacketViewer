using System.Collections.Generic;
using Data.Structures.Quest;
using Utils;

namespace Data.Structures.World
{
    public class Dialog
    {
        public int Uid = (int) Funcs.GetCurrentMilliseconds();

        public Player.Player Player;
        public Npc.Npc Target;

        public int Special; //Type or 0
        public int DialogId; //NpcId or QuestId
        public int Stage = 1;

        public List<DialogButton> Buttons;
        public List<QuestReward> Rewards;

        public Dialog(Player.Player player, Npc.Npc target, int special, int dialogId, int stage = 1)
        {
            Player = player;
            Target = target;
            Special = special;
            DialogId = dialogId;
            Stage = stage;

            Buttons = new List<DialogButton>();
            Rewards = new List<QuestReward>();
        }

        public void Reset(int special, int dialogId, int stage = 1)
        {
            Special = special;
            DialogId = dialogId;
            Stage = stage;

            Buttons = new List<DialogButton>();
            Rewards = new List<QuestReward>();
        }

        public void Release()
        {
            Player = null;
            Target = null;
            Buttons = null;
            Rewards = null;
        }
    }
}