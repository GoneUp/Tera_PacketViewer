using Data.Enums;

namespace Data.Structures.World
{
    public class DialogButton
    {
        public DialogIcon Icon;
        public string Text;

        public DialogButton(DialogIcon icon, string text)
        {
            Icon = icon;
            Text = text;
        }

        public DialogButton(DialogIcon icon, DialogNpcString dialogNpcString)
        {
            Icon = icon;
            Text = "@npc:" + dialogNpcString.GetHashCode();
        }

        public DialogButton(DialogIcon icon, DialogQuestString dialogQuestString)
        {
            Icon = icon;
            Text = "@quest:" + dialogQuestString.GetHashCode();
        }
    }
}