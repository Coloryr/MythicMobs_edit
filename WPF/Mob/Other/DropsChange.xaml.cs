using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Use;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob.Other
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
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Drops.Type))
                new Message_Box("请选择类型");
            else
                Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Drops.Type))
            {
                new Message_Box("请选择类型");
                e.Cancel = true;
            }
        }
    }
}
