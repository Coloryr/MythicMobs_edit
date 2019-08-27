using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class CREEPER : UserControl
    {
        public Obj_save.Mob.Mob_type.CREEPER obj { get; set; } = new Obj_save.Mob.Mob_type.CREEPER()
        {
            ExplosionRadius = 10,
            FuseTicks = 5,
            SuperCharged = false,
            PreventSuicide = false
        };
        public CREEPER()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
    }
}
