using MythicMobs_edit.Obj_save.Mob;
using System;
using System.Windows;

namespace MythicMobs_edit.WPF.Mob.Mechanic_type
{
    /// <summary>
    /// Disguise.xaml 的交互逻辑
    /// </summary>
    public partial class Disguise : Window
    {
        public Mechanic Mechanic { get; set; }
        public Disguise(Mechanic Mechanic)
        {
            InitializeComponent();
            this.Mechanic = Mechanic;
            if (!(this.Mechanic.Option is Obj_save.Mob.Mechanic_type.Disguise))
            {
                this.Mechanic.Option = new Obj_save.Mob.Mechanic_type.Disguise();
            }
            Type.Type.SelectedItem = this.Mechanic.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Mechanic.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Mechanic.Skill_Tag.Tag_Filters;
            Triggers_.Option.Text = Mechanic.Triggers.Option;
            Triggers_.Type.SelectedItem = Mechanic.Triggers.Type;
            DataContext = this;
            List List = new List();
            Disguise_Type.ItemsSource = List.Disguise_Type;
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

        private void Disguise_Type_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((string)Disguise_Type.SelectedItem == "player")
            {
                player_t.IsEnabled = true;
                skin_t.IsEnabled = true;
            }
            else
            {
                player_t.IsEnabled = false;
                skin_t.IsEnabled = false;
            }
        }

        private void Disguise_Type_r_Click(object sender, RoutedEventArgs e)
        {
            List List = new List();
            Random random = new Random();
            Disguise_Type.SelectedItem = List.Disguise_Type[random.Next(List.Disguise_Type.Count)];
        }
    }
}
