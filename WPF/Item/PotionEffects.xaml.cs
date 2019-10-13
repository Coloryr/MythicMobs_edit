using MythicMobs_edit.Obj_save.Item;
using MythicMobs_edit.WPF.Use;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Item
{
    /// <summary>
    /// PotionEffects.xaml 的交互逻辑
    /// </summary>
    public partial class PotionEffects : Window
    {
        public PotionEffects_obj obj { get; set; }
        public PotionEffects(PotionEffects_obj obj)
        {
            InitializeComponent();
            DataContext = this;
            this.obj = obj;
            List_E.ItemsSource = new List().PotionEffects;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(obj.type))
            {
                new Message_Box("请选择药水效果");
            }
            else
                Close();
        }
        public PotionEffects_obj obj_get()
        {
            ShowDialog();
            return obj;
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(obj.type))
            {
                new Message_Box("请选择粒子效果");
                e.Cancel = true;
            }
        }
    }
}
