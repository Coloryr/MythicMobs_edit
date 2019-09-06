using MythicMobs_edit.Obj_save.Mob;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob.Mechanic_type
{
    /// <summary>
    /// Spring.xaml 的交互逻辑
    /// </summary>
    public partial class Spring : Window
    {
        public Mechanic Mechanic { get; set; }
        public Spring(Mechanic Mechanic)
        {
            InitializeComponent();
            this.Mechanic = Mechanic;
            if (!(this.Mechanic.Option is Obj_save.Mob.Mechanic_type.Spring))
            {
                this.Mechanic.Option = new Obj_save.Mob.Mechanic_type.Spring();
            }
            Type.Type.SelectedItem = this.Mechanic.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Mechanic.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Mechanic.Skill_Tag.Tag_Filters;
            Triggers_.Option.Text = Mechanic.Triggers.Option;
            Triggers_.Type.SelectedItem = Mechanic.Triggers.Type;
            DataContext = this;
            Type_.SelectedItem = new List<string>()
            {
                "water", "lava"
            };
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
    }
}
