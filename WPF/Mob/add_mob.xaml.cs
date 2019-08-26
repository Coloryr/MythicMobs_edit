using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Mob;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
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
            Obj_save.Mob.List List = new Obj_save.Mob.List();
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
                    panel.Children.Add(obj = new CREEPER());
                    break;
                case "ENDERMAN":
                    panel.Children.Add(obj = new ENDERMAN());
                    break;
                case "FALLING_BLOCKS":
                    panel.Children.Add(obj = new FALLING_BLOCKS());
                    break;
                case "HORSE":
                    panel.Children.Add(obj = new HORSE());
                    break;
                case "OCELOT":
                    panel.Children.Add(obj = new OCELOT());
                    break;
                case "PIG":
                    panel.Children.Add(obj = new PIG());
                    break;
                case "RABBIT":
                    panel.Children.Add(obj = new RABBIT());
                    break;
                case "SILVERFISH":
                    panel.Children.Add(obj = new SILVERFISH());
                    break;
                case "SNOWMAN":
                    panel.Children.Add(obj = new SNOWMAN());
                    break;
                case "PRIMED_TNT":
                    panel.Children.Add(obj = new PRIMED_TNT());
                    break;
                case "VILLAGER":
                    panel.Children.Add(obj = new VILLAGER());
                    break;
                case "ZOMBIE":
                    panel.Children.Add(obj = new ZOMBIE());
                    break;
                case "ZOMBIE_VILLAGER":
                    panel.Children.Add(obj = new ZOMBIE_VILLAGER());
                    break;
                case "PIG_ZOMBIE_VILLAGER":
                    panel.Children.Add(obj = new ZOMBIE_VILLAGER());
                    break;
                case "SKELETON_HORSE":
                    panel.Children.Add(obj = new HORSE());
                    break;
                case "ZOMBIE_HORSE":
                    panel.Children.Add(obj = new HORSE());
                    break;
                default:
                    panel.Children.Clear();
                    Mob.Options.Type = null;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Mob.Type)
            {
                case "ARMOR_STAND":
                    ARMOR_STAND ARMOR_STAND = (ARMOR_STAND)obj;
                    Mob.Options.Type = ARMOR_STAND.obj;
                    break;
                case "CHICKEN":
                    CHICKEN CHICKEN = (CHICKEN)obj;
                    Mob.Options.Type = CHICKEN.obj;
                    break;
                case "CREEPER":
                    CREEPER CREEPER = (CREEPER)obj;
                    Mob.Options.Type = CREEPER.obj;
                    break;
                case "ENDERMAN":
                    ENDERMAN ENDERMAN = (ENDERMAN)obj;
                    Mob.Options.Type = ENDERMAN.obj;
                    break;
                case "FALLING_BLOCKS":
                    FALLING_BLOCKS FALLING_BLOCKS = (FALLING_BLOCKS)obj;
                    Mob.Options.Type = FALLING_BLOCKS.obj;
                    break;
                case "HORSE":
                    HORSE HORSE = (HORSE)obj;
                    Mob.Options.Type = HORSE.obj;
                    break;
                case "OCELOT":
                    OCELOT OCELOT = (OCELOT)obj;
                    Mob.Options.Type = OCELOT.obj;
                    break;
                case "PIG":
                    PIG PIG = (PIG)obj;
                    Mob.Options.Type = PIG.obj;
                    break;
                case "RABBIT":
                    RABBIT RABBIT = (RABBIT)obj;
                    Mob.Options.Type = RABBIT.obj;
                    break;
                case "SILVERFISH":
                    SILVERFISH SILVERFISH = (SILVERFISH)obj;
                    Mob.Options.Type = SILVERFISH.obj;
                    break;
                case "SNOWMAN":
                    SNOWMAN SNOWMAN = (SNOWMAN)obj;
                    Mob.Options.Type = SNOWMAN.obj;
                    break;
                case "PRIMED_TNT":
                    PRIMED_TNT PRIMED_TNT = (PRIMED_TNT)obj;
                    Mob.Options.Type = PRIMED_TNT.obj;
                    break;
                case "VILLAGER":
                    VILLAGER VILLAGER = (VILLAGER)obj;
                    Mob.Options.Type = VILLAGER.obj;
                    break;
                case "ZOMBIE":
                    ZOMBIE ZOMBIE = (ZOMBIE)obj;
                    Mob.Options.Type = ZOMBIE.obj;
                    break;
                case "ZOMBIE_VILLAGER":
                    ZOMBIE_VILLAGER ZOMBIE_VILLAGER = (ZOMBIE_VILLAGER)obj;
                    Mob.Options.Type = ZOMBIE_VILLAGER.obj;
                    break;
                case "PIG_ZOMBIE_VILLAGER":
                    ZOMBIE_VILLAGER PIG_ZOMBIE_VILLAGER = (ZOMBIE_VILLAGER)obj;
                    Mob.Options.Type = PIG_ZOMBIE_VILLAGER.obj;
                    break;
                case "SKELETON_HORSE":
                    HORSE SKELETON_HORSE = (HORSE)obj;
                    Mob.Options.Type = SKELETON_HORSE.obj;
                    break;
                case "ZOMBIE_HORSE":
                    HORSE ZOMBIE_HORSE = (HORSE)obj;
                    Mob.Options.Type = ZOMBIE_HORSE.obj;
                    break;
                default:
                    Mob.Options.Type = null;
                    break;
            }
            Out.Text = string.Empty;
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(Mob);
            List<string> listLines = new List<string>();
            listLines.Add(MobName + ":");
            StreamReader reader = new StreamReader(new MemoryStream(Encoding.Default.GetBytes(yaml)));
            string line = reader.ReadLine();
            while (string.IsNullOrWhiteSpace(line) != true)
            {
                listLines.Add("  " + line);
                line = reader.ReadLine();
            }
            foreach (string a in listLines)
            {
                Out.Text += a + "\n";
            }
            reader.Close();
        }
    }
}
