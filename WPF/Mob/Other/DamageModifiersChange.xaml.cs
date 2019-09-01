using MythicMobs_edit.Obj_save.Mob;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob.Other
{
    /// <summary>
    /// DamageModifiersChange.xaml 的交互逻辑
    /// </summary>
    public partial class DamageModifiersChange : Window
    {
        public DamageModifiers DamageModifiers { get; set; }
        public DamageModifiersChange(DamageModifiers DamageModifiers)
        {
            InitializeComponent();
            DataContext = this;
            this.DamageModifiers = DamageModifiers;
            List List = new List();
            Type.ItemsSource = List.DamageModifiers_All;
        }
        public DamageModifiers DamageModifiers_set()
        {
            ShowDialog();
            return DamageModifiers;
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
