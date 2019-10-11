using MythicMobs_edit.Obj_save.Item;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Item
{
    /// <summary>
    /// Attributes.xaml 的交互逻辑
    /// </summary>
    public partial class Attributes : Window
    {
        public Attributes_obj obj { get; set; } = new Attributes_obj();
        public Attributes(string a)
        {
            InitializeComponent();
            DataContext = this;
            Title += a;
            obj.Name = a;
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        public Attributes_obj obj_get()
        {
            ShowDialog();
            return obj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
