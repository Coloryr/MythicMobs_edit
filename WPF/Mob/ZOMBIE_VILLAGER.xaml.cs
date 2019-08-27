using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class ZOMBIE_VILLAGER : UserControl
    {
        public Obj_save.Mob.Mob_type.ZOMBIE_VILLAGER obj { get; set; } = new Obj_save.Mob.Mob_type.ZOMBIE_VILLAGER()
        {
            Profession = "BLACKSMITH",
            ReinforcementsChance = 0
        };
        public ZOMBIE_VILLAGER()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            Type.ItemsSource = List.VillagerType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type.SelectedItem = obj.get_type_r();
        }
    }
}
