using System.Windows;

namespace MythicMobs_edit.WPF.Mob.Other
{
    /// <summary>
    /// Message.xaml 的交互逻辑
    /// </summary>
    public partial class Message : Window
    {
        public Message(string a, string b = "")
        {
            InitializeComponent();
            show.Content = a;
            Title = b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
