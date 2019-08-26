using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class RABBIT : UserControl
    {
        public Obj_save.Mob.Mob_type.RABBIT obj { get; set; } = new Obj_save.Mob.Mob_type.RABBIT();
        public RABBIT()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            Type.ItemsSource = List.RabbitType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type.SelectedItem = obj.get_type_r();
        }
    }
}
