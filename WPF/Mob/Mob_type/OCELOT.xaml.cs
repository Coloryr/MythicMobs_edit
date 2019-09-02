using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class OCELOT : UserControl
    {
        public Obj_save.Mob.Mob_type.OCELOT obj { get; set; } = new Obj_save.Mob.Mob_type.OCELOT()
        {
            type = "BLACK_CAT",
            Age = 1,
            AgeLock = false,
            Tameable = false
        };
        public OCELOT()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            Type.ItemsSource = List.OcelotType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type.SelectedItem = obj.get_type_r();
        }
    }
}
