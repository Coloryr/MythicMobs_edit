using MythicMobs_edit.WPF.Item;
using MythicMobs_edit.WPF.Mob;
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

        private void Add_mob(object sender, RoutedEventArgs e)
        {
            new Addmob(gs.IsChecked == true ? true : false).Show();
            this.Close();
        }
        private void Add_item(object sender, RoutedEventArgs e)
        {
            new AddItem(gs.IsChecked == true ? true : false).Show();
            this.Close();
        }
    }
}
