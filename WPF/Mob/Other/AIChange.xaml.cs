using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Use;
using System.ComponentModel;
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
            if (string.IsNullOrWhiteSpace(AI_.Type))
                new Message_Box("请输入类型");
            else
                Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AI_.Type))
            {
                new Message_Box("请输入类型");
                e.Cancel = true;
            }
        }
    }
}
