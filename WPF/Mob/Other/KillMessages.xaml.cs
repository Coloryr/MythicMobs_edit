using System.Windows;

namespace MythicMobs_edit.WPF.Mob.Other
{
    /// <summary>
    /// KillMessages.xaml 的交互逻辑
    /// </summary>
    public partial class KillMessages : Window
    {
        public string KillMessages_ { get; set; } = "";
        public KillMessages(string KillMessages)
        {
            InitializeComponent();
            DataContext = this;
            KillMessages_ = KillMessages;
            Message.Text = KillMessages;
        }
        public string KillMessages_set()
        {
            ShowDialog();
            KillMessages_ = Message.Text.Replace("&amp;", "&");
            return KillMessages_;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&1";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&2";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&3";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&4";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&5";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&6";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&7";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&8";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&9";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&0";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&r";
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&a";
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&b";
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&c";
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&d";
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&e";
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&f";
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&o";
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&l";
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&n";
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&m";
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "&k";
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Message.Text = KillMessages_ += "<target.name>";
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
