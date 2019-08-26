using MythicMobs_edit.Obj_save.Mob;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MythicMobs_edit.WPF
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class add_mob : Window
    {
        public Mob Mob { get; set; } = new Mob();
        public add_mob()
        {
            InitializeComponent();
            Startup();
        }
        private void Startup()
        {
            DataContext = this;
            Mob_Type.ItemsSource = Mob.Type_list;
            BossBar_Color.ItemsSource = Mob.BossBar.Color;
            BossBar_Style.ItemsSource = Mob.BossBar.Style;
        }

        private bool is_number(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > 127)
                    return false;
                else
                    return true;
            }
            return false;
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (BossBar_Enabled.IsChecked == true)
            {
                BossBar_Title.IsEnabled = true;
                BossBar_Range.IsEnabled = true;
                BossBar_Color.IsEnabled = true;
                BossBar_Style.IsEnabled = true;
                BossBar_CreateFog.IsEnabled = true;
                BossBar_DarkenSky.IsEnabled = true;
                BossBar_PlayMusic.IsEnabled = true;
                BossBar_Color_r.IsEnabled = true;
                BossBar_Style_r.IsEnabled = true;
            }
            else
            {
                BossBar_Title.IsEnabled = false;
                BossBar_Range.IsEnabled = false;
                BossBar_Color.IsEnabled = false;
                BossBar_Style.IsEnabled = false;
                BossBar_CreateFog.IsEnabled = false;
                BossBar_DarkenSky.IsEnabled = false;
                BossBar_PlayMusic.IsEnabled = false;
                BossBar_Color_r.IsEnabled = false;
                BossBar_Style_r.IsEnabled = false;
            }
        }

        private void BossBar_Color_r_Click(object sender, RoutedEventArgs e)
        {
            BossBar_Color.SelectedItem = Mob.BossBar.get_color_r();
        }

        private void BossBar_Style_r_Click(object sender, RoutedEventArgs e)
        {
            BossBar_Style.SelectedItem = Mob.BossBar.get_style_r();
        }
    }
}
