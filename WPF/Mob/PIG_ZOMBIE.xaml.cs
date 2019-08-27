using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// PIG_ZOMBIE.xaml 的交互逻辑
    /// </summary>
    public partial class PIG_ZOMBIE : UserControl
    {
        public Obj_save.Mob.Mob_type.PIG_ZOMBIE obj { get; set; } = new Obj_save.Mob.Mob_type.PIG_ZOMBIE()
        {
            Angry = false,
            ReinforcementsChance = 0
        };
        public PIG_ZOMBIE()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
