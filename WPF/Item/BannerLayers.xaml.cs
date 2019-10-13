using MythicMobs_edit.Obj_save.Item;
using MythicMobs_edit.WPF.Use;
using System.ComponentModel;
using System.Windows;

namespace MythicMobs_edit.WPF.Item
{
    /// <summary>
    /// BannerLayers.xaml 的交互逻辑
    /// </summary>
    public partial class BannerLayers : Window
    {
        public BannerLayers_obj obj { get; set; }
        public BannerLayers(BannerLayers_obj obj)
        {
            InitializeComponent();
            DataContext = this;
            this.obj = obj;
            List list = new List();
            List_C.ItemsSource = list.Color;
            List_P.ItemsSource = list.BannerLayers;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(obj.color) || string.IsNullOrWhiteSpace(obj.pattern))
                new Message_Box("请选择属性");
            else
                Close();
        }
        public BannerLayers_obj obj_get()
        {
            ShowDialog();
            return obj;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(obj.color) || string.IsNullOrWhiteSpace(obj.pattern))
            {
                new Message_Box("请选择属性");
                e.Cancel = true;
            }
        }
    }
}
