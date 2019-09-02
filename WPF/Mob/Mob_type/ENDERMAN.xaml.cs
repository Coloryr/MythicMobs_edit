using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class ENDERMAN : UserControl
    {
        public Obj_save.Mob.Mob_type.ENDERMAN obj { get; set; } = new Obj_save.Mob.Mob_type.ENDERMAN()
        {
            PreventTeleport = false
        };
        public ENDERMAN()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
