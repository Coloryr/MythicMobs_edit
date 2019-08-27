using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// COW.xaml 的交互逻辑
    /// </summary>
    public partial class COW : UserControl
    {
        public Obj_save.Mob.Mob_type.COW obj { get; set; } = new Obj_save.Mob.Mob_type.COW();
        public COW()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
