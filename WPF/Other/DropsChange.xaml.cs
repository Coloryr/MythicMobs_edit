using MythicMobs_edit.Obj_save.Mob;
using System.Windows;

namespace MythicMobs_edit.WPF.Other
{
    /// <summary>
    /// DropsChange.xaml 的交互逻辑
    /// </summary>
    public partial class DropsChange : Window
    {
        public Drops Drops { get; set; } = new Drops();
        public DropsChange(Drops Drops)
        {
            InitializeComponent();
            DataContext = this;
            this.Drops = Drops;
        }
        public Drops Drops_set()
        {
            ShowDialog();
            return Drops;
        }
    }
}
