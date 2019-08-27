using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// MAGMA_CUBE.xaml 的交互逻辑
    /// </summary>
    public partial class MAGMA_CUBE : UserControl
    {
        public Obj_save.Mob.Mob_type.MAGMA_CUBE obj { get; set; } = new Obj_save.Mob.Mob_type.MAGMA_CUBE();
        public MAGMA_CUBE()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
