using System.Windows.Controls;
using System.Windows.Documents;

namespace MythicMobs_edit.WPF.Mob.Mob_type
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class VILLAGER : UserControl
    {
        public Obj_save.Mob.Mob_type.VILLAGER obj { get; set; } = new Obj_save.Mob.Mob_type.VILLAGER()
        {
            VillagerType = "BLACKSMITH"
        };
        public VILLAGER()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            Type.ItemsSource = List.VillagerType;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Type.SelectedItem = obj.get_type_r();
        }
    }
}
