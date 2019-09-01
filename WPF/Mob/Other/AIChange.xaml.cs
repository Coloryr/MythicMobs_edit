using MythicMobs_edit.Obj_save.Mob;
using System.Windows;

namespace MythicMobs_edit.WPF.Mob.Other
{
    /// <summary>
    /// AIChange.xaml 的交互逻辑
    /// </summary>
    public partial class AIChange : Window
    {
        public AI AI_ { get; set; } = new AI();
        public AIChange(AI AI)
        {
            InitializeComponent();
            DataContext = this;
            AI_ = AI;
        }
        public AI return_AI()
        {
            ShowDialog();
            return AI_;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
