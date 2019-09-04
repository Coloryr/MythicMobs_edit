using MythicMobs_edit.Obj_save.Mob;
using System.Windows;

namespace MythicMobs_edit.WPF.Mob.Mechanic_type
{
    /// <summary>
    /// Doppleganger.xaml 的交互逻辑
    /// </summary>
    public partial class Doppleganger : Window
    {
        public Mechanic Mechanic { get; set; }
        public Doppleganger(Mechanic Mechanic)
        {
            InitializeComponent();
            this.Mechanic = Mechanic;
            Type.Type.SelectedItem = this.Mechanic.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Mechanic.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Mechanic.Skill_Tag.Tag_Filters;
            Triggers_.Option.Text = Mechanic.Triggers.Option;
            Triggers_.Type.SelectedItem = Mechanic.Triggers.Type;
            DataContext = this;
            Type.refash_SkillTag();
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
