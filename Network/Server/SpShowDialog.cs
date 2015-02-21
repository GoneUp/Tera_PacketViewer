using System.Collections.Generic;
using System.IO;
using Data.Structures.Npc;
using Data.Structures.Quest;
using Data.Structures.Quest.Enums;
using Data.Structures.World;

namespace Network.Server
{
    public class SpShowDialog : ASendPacket
    {
        protected int DialogUid;
        protected int Stage;
        protected Npc Npc;
        protected List<DialogButton> Buttons;
        protected int DialogId;
        protected int Special1;
        protected int Special2;
        protected int Page;
        protected Quest Quest;
        protected QuestReward Reward;

        public SpShowDialog(Npc npc, int stage, List<DialogButton> buttons, int dialogId, int special1, int special2, int page, int dialogUid, Quest quest = null, QuestReward reward = null)
        {
            Npc = npc;
            Stage = stage;
            Buttons = buttons;
            DialogUid = dialogUid;
            DialogId = dialogId;
            Special1 = special1;
            Special2 = special2;
            Page = page;
            Quest = quest;
            Reward = reward;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) Buttons.Count); //Buttons count
            int buttonsShift = (int) writer.BaseStream.Position;
            WriteH(writer, 0); //First button shift

            WriteH(writer, (short) (Quest == null ? 0 : 1));
            int rewardShift = (int) writer.BaseStream.Position;
            WriteH(writer, 0);

            WriteUid(writer, Npc);
            WriteD(writer, Stage); //Stage?
            WriteD(writer, DialogId); //DialogId
            WriteD(writer, Special1);
            WriteD(writer, Special2);
            WriteD(writer, Page); //Page?
            WriteD(writer, DialogUid); //DialogUid
            WriteB(writer, new byte[5]);
            WriteD(writer, 1);
            WriteB(writer, new byte[7]);
            WriteB(writer, "FFFFFFFF");

            int i = 1;
            foreach (DialogButton dialogButton in Buttons)
            {
                writer.Seek(buttonsShift, SeekOrigin.Begin);
                WriteH(writer, (short) writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short) writer.BaseStream.Position);
                buttonsShift = (int) writer.BaseStream.Position;
                WriteH(writer, 0);

                WriteH(writer, (short) (writer.BaseStream.Position + 10));
                WriteD(writer, i++);
                WriteD(writer, dialogButton.Icon.GetHashCode());
                WriteS(writer, dialogButton.Text);
            }

            if (Quest != null)
            {
                int itemsShift = 0;

                writer.Seek(rewardShift, SeekOrigin.Begin);
                WriteH(writer, (short)writer.BaseStream.Length);
                writer.Seek(0, SeekOrigin.End);

                WriteH(writer, (short)writer.BaseStream.Position);
                WriteH(writer, 0);

                if (Reward != null && Reward.Items != null)
                {
                    WriteH(writer, (short) Reward.Items.Count);
                    itemsShift = (int) writer.BaseStream.Position;
                    WriteH(writer, 0);
                }
                else
                    WriteD(writer, 0);

                WriteD(writer, 0);
                WriteD(writer, Quest.QuestRewardType == QuestRewardType.Choice ? 1 : 3); //1 Selectable reward //2 Unspecified reward //3 All
                WriteD(writer, Quest.RewardExp);
                WriteD(writer, Quest.RewardMoney);
                WriteD(writer, 0);
                WriteD(writer, 0); //Polici points
                WriteD(writer, 0);
                WriteD(writer, 0); //Reputation levels [exp]
                WriteD(writer, 0); //Reputation

                if (Reward == null || Reward.Items == null)
                    return;

                for (int x = 0; x < Reward.Items.Count; x++)
                {
                    writer.Seek(itemsShift, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);

                    WriteH(writer, (short)writer.BaseStream.Position);
                    itemsShift = (int) writer.BaseStream.Position;
                    WriteH(writer, 0);

                    WriteD(writer, Reward.Items[x].Key);
                    WriteD(writer, Reward.Items[x].Value);
                }
            }
        }
    }
}