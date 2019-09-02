using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// BABY_PIG_ZOMBIE.xaml 的交互逻辑
    /// </summary>
    public partial class BABY_PIG_ZOMBIE : UserControl
    {
        public Obj_save.Mob.Mob_type.BABY_PIG_ZOMBIE obj { get; set; } = new Obj_save.Mob.Mob_type.BABY_PIG_ZOMBIE()
        {
            ReinforcementsChance = 0,
            Angry = false
        };
        public BABY_PIG_ZOMBIE()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
