using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class PRIMED_TNT : UserControl
    {
        public Obj_save.Mob.Mob_type.PRIMED_TNT obj { get; set; } = new Obj_save.Mob.Mob_type.PRIMED_TNT()
        {
            FuseTicks = 5,
            ExplosionYield = 1,
            Incendiary = false
        };
        public PRIMED_TNT()
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
