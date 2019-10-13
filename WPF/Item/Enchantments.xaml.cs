using MythicMobs_edit.Obj_save.Item;
using MythicMobs_edit.WPF.Use;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Item
{
    /// <summary>
    /// Enchantments.xaml 的交互逻辑
    /// </summary>
    public partial class Enchantments : Window
    {
        public Enchantments_obj obj { get; set; }
        public Enchantments(Enchantments_obj obj)
        {
            InitializeComponent();
            this.obj = obj;
            DataContext = this;
        }

        public Enchantments_obj obj_get()
        {
            ShowDialog();
            return obj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(obj.ID))
            {
                new Message_Box("请输入附魔名称");
            }
            else
                Close();
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(obj.ID))
            {
                new Message_Box("请输入附魔名称");
                e.Cancel = true;
            }
        }
    }
}
