using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class SNOWMAN : UserControl
    {
        public Obj_save.Mob.Mob_type.SNOWMAN obj { get; set; } = new Obj_save.Mob.Mob_type.SNOWMAN()
        {
            PreventSnowFormation = false
        };
        public SNOWMAN()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
