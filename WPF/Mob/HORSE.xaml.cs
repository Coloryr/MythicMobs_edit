using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class HORSE : UserControl
    {
        public Obj_save.Mob.Mob_type.HORSE obj { get; set; } = new Obj_save.Mob.Mob_type.HORSE()
        {
            HorseColor = "BLACK",
            HorseSaddled = false,
            HorseStyle = "BLACK_DOTS",
            HorseTamed = false,
            Age = 1,
            AgeLock = false,
            Tameable = false
        };
        public HORSE()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            HorseArmor.ItemsSource = List.HorseArmor;
            HorseColor.ItemsSource = List.HorseColor;
            HorseStyle.ItemsSource = List.HorseStyle;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HorseArmor.SelectedItem = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HorseColor.SelectedItem = obj.get_color_r();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HorseStyle.SelectedItem = obj.get_style_r();
        }
    }
}
