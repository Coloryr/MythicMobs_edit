using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// SLIME.xaml 的交互逻辑
    /// </summary>
    public partial class SLIME : UserControl
    {
        public Obj_save.Mob.Mob_type.SLIME obj { get; set; } = new Obj_save.Mob.Mob_type.SLIME()
        {
            PreventSlimeSplit = false,
            Size = 1
        };
        public SLIME()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
