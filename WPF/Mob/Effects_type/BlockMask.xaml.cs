using MythicMobs_edit.Obj_save.Mob;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob.Effects_type
{
    /// <summary>
    /// BlockMask.xaml 的交互逻辑
    /// </summary>
    public partial class BlockMask : Window
    {
        public Effects Effects { get; set; }
        public BlockMask(Effects Effects)
        {
            InitializeComponent();
            this.Effects = Effects;
            if (!(this.Effects.Option is Obj_save.Mob.Effects_type.BlockMask))
            {
                this.Effects.Option = new Obj_save.Mob.Effects_type.BlockMask();
            }
            Type.Type.SelectedItem = this.Effects.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Effects.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Effects.Skill_Tag.Tag_Filters;
            DataContext = this;
            Type.refash_SkillTag();
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        public Effects get_Effects_()
        {
            ShowDialog();
            Effects.Skill_Tag.Tag_Type = (string)Type.Type.SelectedItem;
            Effects.Skill_Tag.Tag_Option = Type.Option.Text;
            Effects.Skill_Tag.Tag_Filters = Type.Skill_Tag_;
            return Effects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
