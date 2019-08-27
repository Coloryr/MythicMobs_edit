using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// LLAMA.xaml 的交互逻辑
    /// </summary>
    public partial class LLAMA : UserControl
    {
        public Obj_save.Mob.Mob_type.LLAMA obj { get; set; } = new Obj_save.Mob.Mob_type.LLAMA();
        public LLAMA()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
