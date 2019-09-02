using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// MUSHROOM_COW.xaml 的交互逻辑
    /// </summary>
    public partial class MUSHROOM_COW : UserControl
    {
        public Obj_save.Mob.Mob_type.MUSHROOM_COW obj { get; set; } = new Obj_save.Mob.Mob_type.MUSHROOM_COW()
        {
            Age = 1,
            AgeLock = false
        };
        public MUSHROOM_COW()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
