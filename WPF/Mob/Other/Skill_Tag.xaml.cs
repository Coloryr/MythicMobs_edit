using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Other
{
    /// <summary>
    /// Skill_Tag.xaml 的交互逻辑
    /// </summary>
    public partial class Skill_Tag : UserControl
    {
        public List<string> Skill_Tag_ { get; set; }
        public Skill_Tag()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List list = new Obj_save.Mob.List();
            Type.ItemsSource = list.Skill_Tag;
            Filters.ItemsSource = list.Skill_Tag_no;
        }
        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Type.SelectedItem == null)
                return;
            switch (Type.SelectedItem)
            {
                case "@LivingEntitiesInRadius":
                    Option.Text = "r=#";
                    break;
                case "@PlayersInRadius":
                    Option.Text = "r=#";
                    break;
                case "@MobsInRadius":
                    Option.Text = "r=#;types=X,X,X";
                    break;
                case "@EntitiesInRadius":
                    Option.Text = "r=#;types=X,X,X";
                    break;
                case "@PlayersInRing":
                    Option.Text = "min=#;max=#";
                    break;
                case "@PlayersNearOrigin":
                    Option.Text = "r=#";
                    break;
                case "@MobsNearOrigin":
                    Option.Text = "r=R;t=T";
                    break;
                case "@EntitiesNearOrigin":
                    Option.Text = "r=#";
                    break;
                case "@Location":
                    Option.Text = "c=x,y,z";
                    break;
                case "@Spawner":
                    Option.Text = "s=[string]";
                    break;
                case "@RLNTE":
                    Option.Text = "amount=#;radius=#;spacing=#;minradius=#;";
                    break;
                case "@PlayerLocationsInRadius":
                    Option.Text = "r=#";
                    break;
                case "@Ring":
                    Option.Text = "radius=#;points=#";
                    break;
                case "@Cone":
                    Option.Text = "angle=#;points=#;range=#;rotation=#;";
                    break;
                case "@EntitiesInCone":
                    Option.Text = "angle=#;range=#;rotation=#;";
                    break;
                case "@Line":
                    Option.Text = "radius=#;fromorigin=true/false";
                    break;
                case "@EntitiesInLine":
                    Option.Text = "radius=#;fromorigin=true/false";
                    break;
                default:
                    Option.Text = "";
                    break;
            }
        }
        public void refash_SkillTag()
        {
            SkillTag_T.Items.Clear();
            foreach (string a in Skill_Tag_)
            {
                SkillTag_T.Items.Add(a);
            }
        }
        private void DelectSkillTagEvent(object sender, RoutedEventArgs e)
        {
            if (SkillTag_T.SelectedItem == null)
                return;
            Skill_Tag_.Remove((string)SkillTag_T.SelectedItem);
            refash_SkillTag();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Filters.SelectedItem == null)
                return;
            Skill_Tag_.Add((string)Filters.SelectedItem);
            SkillTag_T.Items.Add((string)Filters.SelectedItem);
        }
    }
}
