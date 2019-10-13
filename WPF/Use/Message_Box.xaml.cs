using System.Windows;

namespace MythicMobs_edit.WPF.Use
{
    /// <summary>
    /// Message.xaml 的交互逻辑
    /// </summary>
    public partial class Message_Box : Window
    {
        public Message_Box(string a, string b = "")
        {
            InitializeComponent();
            show.Content = a;
            Title = b;
            ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
