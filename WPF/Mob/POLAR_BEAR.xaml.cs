using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// POLAR_BEAR.xaml 的交互逻辑
    /// </summary>
    public partial class POLAR_BEAR : UserControl
    {
        public Obj_save.Mob.Mob_type.POLAR_BEAR obj { get; set; } = new Obj_save.Mob.Mob_type.POLAR_BEAR()
        {
            Age = 1,
            AgeLock = false
        };
        public POLAR_BEAR()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
