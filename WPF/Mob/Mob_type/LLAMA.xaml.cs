using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// LLAMA.xaml 的交互逻辑
    /// </summary>
    public partial class LLAMA : UserControl
    {
        public Obj_save.Mob.Mob_type.LLAMA obj { get; set; } = new Obj_save.Mob.Mob_type.LLAMA()
        {
            Age = 1,
            AgeLock = false
        };
        public LLAMA()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
