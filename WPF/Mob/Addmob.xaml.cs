using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Mob;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Addmob.xaml 的交互逻辑
    /// </summary>
    public partial class Addmob : Window
    {
        public string MobName { get; set; } = "newMob";
        public Dictionary<int, string> AIGoalSelectors { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> AITargetSelectors { get; set; } = new Dictionary<int, string>();
        public string AI_Goal_S { get; set; } = "clear";
        public Mob_obj Mob { get; set; } = new Mob_obj()
        {
            Display = "Mob",
            Type = "ARMOR_STAND",
            Health = 20,
            Damage = 5,
            Armor = 1,
            BossBar = new BossBar()
            {
                Enabled = false,
                Title = "BOSS",
                Range = 40
            },
            Options = new Options()
            {
                AlwaysShowName = false,
                AttackSpeed = 10,
                FollowRange = 20,
                Collidable = true,
                Despawn = true,
                Glowing = false,
                Invincible = false,
                KnockbackResistance = 0,
                MovementSpeed = 0.2d,
                NoDamageTicks = 10,
                NoGravity = false,
                Persistent = false,
                PreventItemPickup = true,
                PreventLeashing = true,
                PreventMobKillDrops = false,
                PreventOtherDrops = false,
                PreventRandomEquipment = false,
                PreventRenaming = true,
                RepeatAllSkills = false,
                ShowHealth = false
            },
            Modules = new Modules()
            {
                ThreatTable = false,
                ImmunityTable = false
            },
            AIGoalSelectors = new List<string>(),
            AITargetSelectors = new List<string>()
        };
        private UserControl obj;
        public Addmob()
        {
            InitializeComponent();
            Startup();
            DataContext = this;
        }
        private void Startup()
        {
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            Mob_Type.ItemsSource = List.Type_list;
            BossBar_Color.ItemsSource = List.BossBarColor;
            BossBar_Style.ItemsSource = List.BossBarStyle;
            AIGoalSelectors_S.ItemsSource = List.AI_Goal_All;
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }

        private void CheckBox_Check(object sender, RoutedEventArgs e)
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
                case "BABY_PIG_ZOMBIE":
                    panel.Children.Add(obj = new BABY_PIG_ZOMBIE());
                    break;
                case "BABY_ZOMBIE":
                    panel.Children.Add(obj = new BABY_ZOMBIE());
                    break;
                case "BABY_PIG_ZOMBIE_VILLAGER":
                    panel.Children.Add(obj = new BABY_PIG_ZOMBIE_VILLAGER());
                    break;
                case "BABY_ZOMBIE_VILLAGER":
                    panel.Children.Add(obj = new BABY_ZOMBIE_VILLAGER());
                    break;
                case "CHICKEN":
                    panel.Children.Add(obj = new CHICKEN());
                    break;
                case "COW":
                    panel.Children.Add(obj = new COW());
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
                case "LLAMA":
                    panel.Children.Add(obj = new LLAMA());
                    break;
                case "MAGMA_CUBE":
                    panel.Children.Add(obj = new MAGMA_CUBE());
                    break;
                case "MUSHROOM_COW":
                    panel.Children.Add(obj = new MUSHROOM_COW());
                    break;
                case "OCELOT":
                    panel.Children.Add(obj = new OCELOT());
                    break;
                case "PIG":
                    panel.Children.Add(obj = new PIG());
                    break;
                case "PIG_ZOMBIE":
                    panel.Children.Add(obj = new PIG_ZOMBIE());
                    break;
                case "PIG_ZOMBIE_VILLAGER":
                    panel.Children.Add(obj = new PIG_ZOMBIE_VILLAGER());
                    break;
                case "POLAR_BEAR":
                    panel.Children.Add(obj = new POLAR_BEAR());
                    break;
                case "RABBIT":
                    panel.Children.Add(obj = new RABBIT());
                    break;
                case "SHEEP":
                    panel.Children.Add(obj = new SHEEP());
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
                case "WOLF":
                    panel.Children.Add(obj = new WOLF());
                    break;
                case "ZOMBIE":
                    panel.Children.Add(obj = new ZOMBIE());
                    break;
                case "ZOMBIE_VILLAGER":
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
                case "BABY_PIG_ZOMBIE":
                    BABY_PIG_ZOMBIE BABY_PIG_ZOMBIE = (BABY_PIG_ZOMBIE)obj;
                    Mob.Options.Type = BABY_PIG_ZOMBIE.obj;
                    break;
                case "BABY_ZOMBIE":
                    BABY_ZOMBIE BABY_ZOMBIE = (BABY_ZOMBIE)obj;
                    Mob.Options.Type = BABY_ZOMBIE.obj;
                    break;
                case "BABY_PIG_ZOMBIE_VILLAGER":
                    BABY_PIG_ZOMBIE_VILLAGER BABY_PIG_ZOMBIE_VILLAGER = (BABY_PIG_ZOMBIE_VILLAGER)obj;
                    Mob.Options.Type = BABY_PIG_ZOMBIE_VILLAGER.obj;
                    break;
                case "BABY_ZOMBIE_VILLAGER":
                    BABY_ZOMBIE_VILLAGER BABY_ZOMBIE_VILLAGER = (BABY_ZOMBIE_VILLAGER)obj;
                    Mob.Options.Type = BABY_ZOMBIE_VILLAGER.obj;
                    break;
                case "CHICKEN":
                    CHICKEN CHICKEN = (CHICKEN)obj;
                    Mob.Options.Type = CHICKEN.obj;
                    break;
                case "COW":
                    COW COW = (COW)obj;
                    Mob.Options.Type = COW.obj;
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
                case "LLAMA":
                    LLAMA LLAMA = (LLAMA)obj;
                    Mob.Options.Type = LLAMA.obj;
                    break;
                case "MAGMA_CUBE":
                    MAGMA_CUBE MAGMA_CUBE = (MAGMA_CUBE)obj;
                    Mob.Options.Type = MAGMA_CUBE.obj;
                    break;
                case "MUSHROOM_COW":
                    MUSHROOM_COW MUSHROOM_COW = (MUSHROOM_COW)obj;
                    Mob.Options.Type = MUSHROOM_COW.obj;
                    break;
                case "OCELOT":
                    OCELOT OCELOT = (OCELOT)obj;
                    Mob.Options.Type = OCELOT.obj;
                    break;
                case "PIG":
                    PIG PIG = (PIG)obj;
                    Mob.Options.Type = PIG.obj;
                    break;
                case "PIG_ZOMBIE":
                    PIG_ZOMBIE PIG_ZOMBIE = (PIG_ZOMBIE)obj;
                    Mob.Options.Type = PIG_ZOMBIE.obj;
                    break;
                case "PIG_ZOMBIE_VILLAGER":
                    PIG_ZOMBIE_VILLAGER PIG_ZOMBIE_VILLAGER = (PIG_ZOMBIE_VILLAGER)obj;
                    Mob.Options.Type = PIG_ZOMBIE_VILLAGER.obj;
                    break;
                case "POLAR_BEAR":
                    POLAR_BEAR POLAR_BEAR = (POLAR_BEAR)obj;
                    Mob.Options.Type = POLAR_BEAR.obj;
                    break;
                case "RABBIT":
                    RABBIT RABBIT = (RABBIT)obj;
                    Mob.Options.Type = RABBIT.obj;
                    break;
                case "SHEEP":
                    SHEEP SHEEP = (SHEEP)obj;
                    Mob.Options.Type = SHEEP.obj;
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
                case "WOLF":
                    WOLF WOLF = (WOLF)obj;
                    Mob.Options.Type = WOLF.obj;
                    break;
                case "ZOMBIE":
                    ZOMBIE ZOMBIE = (ZOMBIE)obj;
                    Mob.Options.Type = ZOMBIE.obj;
                    break;
                case "ZOMBIE_VILLAGER":
                    ZOMBIE_VILLAGER ZOMBIE_VILLAGER = (ZOMBIE_VILLAGER)obj;
                    Mob.Options.Type = ZOMBIE_VILLAGER.obj;
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
            Mob.AIGoalSelectors.Clear();
            foreach (KeyValuePair<int, string> a in AIGoalSelectors)
            {
                Mob.AIGoalSelectors.Add(a.Key + " " + a.Value);
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AIGoalSelectors_S.SelectedItem != null)
            {
                AIGoalSelectors.Add(AIGoalSelectors.Count, AI_Goal_S);
                AI.Items.Add(new
                {
                    a = AIGoalSelectors.Count - 1,
                    b = AI_Goal_S
                });
            }
        }

        private void DelectAIEvent(object sender, RoutedEventArgs e)
        {
            if (AI.SelectedItem == null)
                return;
            int num = AI.SelectedIndex; //选中的listview的行
            AI.Items.Remove(AI.SelectedItem);
            AIGoalSelectors.Remove(num);
            foreach (KeyValuePair<int, string> a in AIGoalSelectors.ToArray())
            {
                if (a.Key > num)
                {
                    AIGoalSelectors.Add(a.Key - 1, a.Value);
                    AIGoalSelectors.Remove(a.Key);
                }
            }
            AI.Items.Clear();
            foreach (KeyValuePair<int, string> a in AIGoalSelectors.ToArray())
            {
                AI.Items.Add(new
                {
                    a = a.Key,
                    b = a.Value
                });
            }
            foreach (KeyValuePair<int, string> a in AIGoalSelectors.ToArray())
            {
                AI.Items.Add(new
                {
                    a = a.Key,
                    b = a.Value
                });
            }
        }
        private void ChangeAIEvent(object sender, RoutedEventArgs e)
        {
            if (AI.SelectedItem == null)
                return;
            AIChange change = new AIChange(new AI()
            {
                a = AI.SelectedIndex,
                b = AIGoalSelectors[AI.SelectedIndex]
            });
            AI a = change.return_AI();
            if (AIGoalSelectors.ContainsKey(a.a))
            {
                
            }
        }
    }
}
