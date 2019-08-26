using Microsoft.JScript;
using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Mob;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace MythicMobs_edit.WPF
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class add_mob : Window
    {
        public string MobName { get; set; } = "newMob";
        public Mob_obj Mob { get; set; } = new Mob_obj();
        private UserControl obj;
        public add_mob()
        {
            InitializeComponent();
            Startup();
        }
        private void Startup()
        {
            DataContext = this;
            Obj_save.Mob.Mob_type.List List = new Obj_save.Mob.Mob_type.List();
            Mob_Type.ItemsSource = List.Type_list;
            BossBar_Color.ItemsSource = List.BossBarColor;
            BossBar_Style.ItemsSource = List.BossBarStyle;
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

        private void Mob_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            panel.Children.Clear();
            Mob.Type = Mob_Type.SelectedItem.ToString();
            switch (Mob.Type)
            {
                case "ARMOR_STAND":
                    panel.Children.Add(obj = new ARMOR_STAND());
                    break;
                case "CHICKEN":
                    panel.Children.Add(obj = new CHICKEN());
                    break;
                case "CREEPER":
                    panel.Children.Add(new CREEPER());
                    break;
                case "ENDERMAN":
                    panel.Children.Add(new ENDERMAN());
                    break;
                case "FALLING_BLOCKS":
                    panel.Children.Add(new FALLING_BLOCKS());
                    break;
                case "HORSE":
                    panel.Children.Add(new HORSE());
                    break;
                case "OCELOT":
                    panel.Children.Add(new OCELOT());
                    break;
                case "PIG":
                    panel.Children.Add(new PIG());
                    break;
                case "RABBIT":
                    panel.Children.Add(new RABBIT());
                    break;
                case "SILVERFISH":
                    panel.Children.Add(new SILVERFISH());
                    break;
                case "SNOWMAN":
                    panel.Children.Add(new SNOWMAN());
                    break;
                case "PRIMED_TNT":
                    panel.Children.Add(new PRIMED_TNT());
                    break;
                case "VILLAGER":
                    panel.Children.Add(new VILLAGER());
                    break;
                case "ZOMBIE":
                    panel.Children.Add(new ZOMBIE());
                    break;
                case "ZOMBIE_VILLAGER":
                    panel.Children.Add(new ZOMBIE_VILLAGER());
                    break;
                default:
                    panel.Children.Clear();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Mob.Type)
            {
                case "ARMOR_STAND":
                    ARMOR_STAND a = (ARMOR_STAND)obj;
                    Mob.Options.Type = a.obj;
                    break;
                case "CHICKEN":
                    panel.Children.Add(obj = new CHICKEN());
                    break;
                case "CREEPER":
                    panel.Children.Add(new CREEPER());
                    break;
                case "ENDERMAN":
                    panel.Children.Add(new ENDERMAN());
                    break;
                case "FALLING_BLOCKS":
                    panel.Children.Add(new FALLING_BLOCKS());
                    break;
                case "HORSE":
                    panel.Children.Add(new HORSE());
                    break;
                case "OCELOT":
                    panel.Children.Add(new OCELOT());
                    break;
                case "PIG":
                    panel.Children.Add(new PIG());
                    break;
                case "RABBIT":
                    panel.Children.Add(new RABBIT());
                    break;
                case "SILVERFISH":
                    panel.Children.Add(new SILVERFISH());
                    break;
                case "SNOWMAN":
                    panel.Children.Add(new SNOWMAN());
                    break;
                case "PRIMED_TNT":
                    panel.Children.Add(new PRIMED_TNT());
                    break;
                case "VILLAGER":
                    panel.Children.Add(new VILLAGER());
                    break;
                case "ZOMBIE":
                    panel.Children.Add(new ZOMBIE());
                    break;
                case "ZOMBIE_VILLAGER":
                    panel.Children.Add(new ZOMBIE_VILLAGER());
                    break;
                default:
                    panel.Children.Clear();
                    break;
            }
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(Mob);
            Out.Text = yaml;
        }
    }
}
