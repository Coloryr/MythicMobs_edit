using MythicMobs_edit.WPF;
using System.Windows;

namespace MythicMobs_edit
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Addmob().Show();
            this.Close();
        }
    }
}
