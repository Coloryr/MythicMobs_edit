using System.Windows;
using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// SHEEP.xaml 的交互逻辑
    /// </summary>
    public partial class SHEEP : UserControl
    {
        public Obj_save.Mob.Mob_type.SHEEP obj { get; set; } = new Obj_save.Mob.Mob_type.SHEEP()
        {
            Age = 1,
            AgeLock = false,
            Color = "WHILE"
        };
        public SHEEP()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            Color.ItemsSource = List.WoolColor;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Color.SelectedItem = obj.get_color_r();
        }
    }
}
