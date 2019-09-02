using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// BABY_ZOMBIE.xaml 的交互逻辑
    /// </summary>
    public partial class BABY_ZOMBIE : UserControl
    {
        public Obj_save.Mob.Mob_type.BABY_ZOMBIE obj { get; set; } = new Obj_save.Mob.Mob_type.BABY_ZOMBIE()
        {
            ReinforcementsChance = 0
        };
        public BABY_ZOMBIE()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
