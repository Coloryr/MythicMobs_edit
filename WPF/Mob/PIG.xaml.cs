using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class PIG : UserControl
    {
        public Obj_save.Mob.Mob_type.PIG obj { get; set; } = new Obj_save.Mob.Mob_type.PIG();
        public PIG()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
