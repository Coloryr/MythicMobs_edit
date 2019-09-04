using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Mob.Other;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob.Mechanic_type
{
    /// <summary>
    /// RandomMessage.xaml 的交互逻辑
    /// </summary>
    public partial class RandomMessage : Window
    {
        public Mechanic Mechanic { get; set; }
        private List<string> Messages = new List<string>();
        public RandomMessage(Mechanic Mechanic)
        {
            InitializeComponent();
            this.Mechanic = Mechanic;
            if (!(this.Mechanic.Option is Obj_save.Mob.Mechanic_type.RandomMessage))
            {
                this.Mechanic.Option = new Obj_save.Mob.Mechanic_type.RandomMessage();
            }
            Type.Type.SelectedItem = this.Mechanic.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Mechanic.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Mechanic.Skill_Tag.Tag_Filters;
            Triggers_.Option.Text = Mechanic.Triggers.Option;
            Triggers_.Type.SelectedItem = Mechanic.Triggers.Type;
            Messages = ((Obj_save.Mob.Mechanic_type.RandomMessage)Mechanic.Option).message;
            DataContext = this;
            Type.refash_SkillTag();
            refash_Messages();
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        public Mechanic get_Mechanic_()
        {
            ShowDialog();
            Mechanic.Skill_Tag.Tag_Type = (string)Type.Type.SelectedItem;
            Mechanic.Skill_Tag.Tag_Option = Type.Option.Text;
            Mechanic.Skill_Tag.Tag_Filters = Type.Skill_Tag_;
            Mechanic.Triggers.Type = (string)Triggers_.Type.SelectedItem;
            Mechanic.Triggers.Option = Triggers_.Option.Text;
            ((Obj_save.Mob.Mechanic_type.RandomMessage)Mechanic.Option).message = Messages;
            return Mechanic;
        }

        public void refash_Messages()
        {
            Message_T.Items.Clear();
            foreach (string a in Messages)
            {
                if (string.IsNullOrWhiteSpace(a) == false)
                    Message_T.Items.Add(a);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string a = new KillMessages("message", false).KillMessages_set();
            if (string.IsNullOrWhiteSpace(a) == false)
            {
                Message_T.Items.Add(a);
                Messages.Add(a);
            }
        }
        private void DelectMessageEvent(object sender, RoutedEventArgs e)
        {
            if (Message_T.SelectedItem == null)
                return;
            Messages.Remove((string)Message_T.SelectedItem);
            refash_Messages();
        }
        private void ChangeMessageEvent(object sender, RoutedEventArgs e)
        {
            if (Message_T.SelectedItem == null)
                return;
            string message = (string)Message_T.SelectedItem;
            Messages.Remove(message);
            message = new KillMessages(message, false).KillMessages_set();
            Messages.Add(message);
            refash_Messages();
        }
    }
}
