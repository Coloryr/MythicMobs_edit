using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// WOLF.xaml 的交互逻辑
    /// </summary>
    public partial class WOLF : UserControl
    {
        public Obj_save.Mob.Mob_type.WOLF obj { get; set; } = new Obj_save.Mob.Mob_type.WOLF()
        {
            Age = 1,
            AgeLock = false,
            Tameable = false,
            Angry = false
        };
        public WOLF()
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
