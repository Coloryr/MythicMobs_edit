using MythicMobs_edit.Obj_save.Mob;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
    }
}
