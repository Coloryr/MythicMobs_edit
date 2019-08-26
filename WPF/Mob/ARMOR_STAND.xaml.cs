using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class ARMOR_STAND : UserControl
    {
        public Obj_save.Mob.Mob_type.ARMOR_STAND obj { get; set; } = new Obj_save.Mob.Mob_type.ARMOR_STAND();
        public ARMOR_STAND()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
