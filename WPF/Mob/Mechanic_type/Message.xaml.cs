﻿using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Use;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob.Mechanic_type
{
    /// <summary>
    /// Message.xaml 的交互逻辑
    /// </summary>
    public partial class Message : Window
    {
        public Mechanic Mechanic { get; set; }
        public Message(Mechanic Mechanic)
        {
            InitializeComponent();
            this.Mechanic = Mechanic;
            if (!(this.Mechanic.Option is Obj_save.Mob.Mechanic_type.Message))
            {
                this.Mechanic.Option = new Obj_save.Mob.Mechanic_type.Message();
            }
            Type.Type.SelectedItem = this.Mechanic.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Mechanic.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Mechanic.Skill_Tag.Tag_Filters;
            Triggers_.Option.Text = Mechanic.Triggers.Option;
            Triggers_.Type.SelectedItem = Mechanic.Triggers.Type;
            DataContext = this;
            Type.refash_SkillTag();
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
            return Mechanic;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Obj_save.Mob.Mechanic_type.Message Message = (Obj_save.Mob.Mechanic_type.Message)Mechanic.Option;
            Message.message = new MessageEdit(Message.message, false).KillMessages_set();
            Text_.Text = Message.message;
        }
    }
}
