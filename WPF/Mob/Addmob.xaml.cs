using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Mob;
using MythicMobs_edit.WPF.Mob.Effects_type;
using MythicMobs_edit.WPF.Mob.Other;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Effects;
using YamlDotNet.Serialization;

namespace MythicMobs_edit.WPF
{
    /// <summary>
    /// Addmob.xaml 的交互逻辑
    /// </summary>
    public partial class Addmob : Window
    {
        public string MobName { get; set; } = "newMob";
        public string Display { get; set; } = "Mob";
        public Dictionary<int, string> AIGoalSelectors { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> AITargetSelectors { get; set; } = new Dictionary<int, string>();
        public List<Drops> Drops_L { get; set; } = new List<Drops>();
        public List<Drops> DropsPerLevel_L { get; set; } = new List<Drops>();
        public List<DamageModifiers> DamageModifiers_L { get; set; } = new List<DamageModifiers>();
        public Equipment Equipment { get; set; } = new Equipment();
        public List<string> KillMessages_L { get; set; } = new List<string>();
        public string AI_Goal_S { get; set; } = "clear";
        public string AI_Goal_T { get; set; } = "clear";
        public string Drops_C { get; set; } = "exp";
        public string DropsPerLevel_C { get; set; } = "exp";
        public string DamageModifiers_C { get; set; } = "DROWNING";
        public List<Effects> Skills_effect { get; set; } = new List<Effects>();
        public Mob_obj Mob { get; set; } = new Mob_obj()
        {
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
            AITargetSelectors = new List<string>(),
            Drops = new List<string>(),
            DropsPerLevel = new List<string>(),
            DamageModifiers = new List<string>(),
            Equipment = new List<string>(),
            KillMessages = new List<string>(),
            LevelModifiers = new LevelModifiers(),
            Disguise = new Disguise(),
            Skills = new List<string>()
        };
        private UserControl obj;
        public Addmob(bool gs)
        {
            InitializeComponent();
            Startup();
            DataContext = this;
            BlurEffect BlurEffect = new BlurEffect();
            BlurEffect.Radius = gs == true ? 15 : 0;
            BG.Effect = BlurEffect;
            BG.Visibility = Visibility.Visible;
        }
        private void Startup()
        {
            Obj_save.Mob.List List = new Obj_save.Mob.List();
            Mob_Type.ItemsSource = List.Type_list;
            BossBar_Color.ItemsSource = List.BossBarColor;
            BossBar_Style.ItemsSource = List.BossBarStyle;
            AIGoalSelectors_S.ItemsSource = List.AI_Goal_All;
            AITargetSelectors_S.ItemsSource = List.AI_Target_All;
            Drops_S.ItemsSource = List.Drops_Type;
            DropsPerLevel_S.ItemsSource = List.Drops_Type;
            DamageModifiers_S.ItemsSource = List.DamageModifiers_All;
            Disguise_Type.ItemsSource = List.Disguise_Type;
            Skill_Effect_Type.ItemsSource = List.Skills_effect;
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        public bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
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
        private void Disguise_Type_r_Click(object sender, RoutedEventArgs e)
        {
            Disguise_Type.SelectedItem = Mob.Disguise.Type_r();
        }
        private void Disguise_Type_n_Click(object sender, RoutedEventArgs e)
        {
            Disguise_Type.SelectedItem = null;
        }
        private void Skill_Effect_Type_r_Click(object sender, RoutedEventArgs e)
        {
            Obj_save.Mob.List list = new Obj_save.Mob.List();
            Random random = new Random();
            Skill_Effect_Type.SelectedItem = list.Skills_effect[random.Next(list.Skills_effect.Count)];
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
            Mob.Display = Encoding.Default.GetString(Encoding.UTF8.GetBytes(Display));
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
                Mob.AIGoalSelectors.Add(a.Key + " " + Encoding.Default.GetString(Encoding.UTF8.GetBytes(a.Value)));
            }
            Mob.AITargetSelectors.Clear();
            foreach (KeyValuePair<int, string> a in AITargetSelectors)
            {
                Mob.AITargetSelectors.Add(a.Key + " " + Encoding.Default.GetString(Encoding.UTF8.GetBytes(a.Value)));
            }
            Mob.Drops.Clear();
            foreach (Drops a in Drops_L)
            {
                Mob.Drops.Add(Encoding.Default.GetString(Encoding.UTF8.GetBytes(a.Type)) + " " + a.amount + " " + string.Format("{0:F}", a.chance));
            }
            Mob.DropsPerLevel.Clear();
            foreach (Drops a in DropsPerLevel_L)
            {
                Mob.DropsPerLevel.Add(Encoding.Default.GetString(Encoding.UTF8.GetBytes(a.Type)) + " " + a.amount + " " + string.Format("{0:F}", a.chance));
            }
            Mob.DamageModifiers.Clear();
            foreach (DamageModifiers a in DamageModifiers_L)
            {
                Mob.DamageModifiers.Add(a.Type + " " + string.Format("{0:F}", a.set));
            }
            Mob.KillMessages.Clear();
            foreach (string a in KillMessages_L)
            {
                Mob.KillMessages.Add(Encoding.Default.GetString(Encoding.UTF8.GetBytes(a)));
            }
            Mob.Skills.Clear();
            foreach (Effects a in Skills_effect)
            {
                string b;
                if (a.Type != "sound")
                {
                    b = "effect:" + a.Type;
                }
                else
                {
                    b = "sound:";
                }
                switch (a.Type)
                    {
                        case "blockmask":
                            string c = "{";
                            Obj_save.Mob.Effects_type.BlockMask blockMask = (Obj_save.Mob.Effects_type.BlockMask)a.Option;
                            if (string.IsNullOrWhiteSpace(blockMask.material) == false)
                                c += "m:" + blockMask.material + ";";
                            if (blockMask.data != 0)
                                c += "dv:" + blockMask.data + ";";
                            if (blockMask.radius != 0)
                                c += "r:" + blockMask.radius + ";";
                            if (blockMask.noise != 0)
                                c += "n:" + blockMask.noise + ";";
                            if (blockMask.duration != 0)
                                c += "d:" + blockMask.duration + ";";
                            if (string.IsNullOrWhiteSpace(blockMask.shape) == false)
                                c += "s:" + blockMask.shape + ";";
                            c += "na:" + blockMask.noair + ";";
                            c += "s:" + blockMask.onlyair + ";";
                            c = c.Substring(0, c.Length - 1);
                            c += "}";
                            b += c + " ";
                            break;
                    }
                    if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false)
                    {
                        string c = a.Skill_Tag.Tag_Type;
                        if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false)
                        {
                            c += "{" + a.Skill_Tag.Tag_Option;
                            b += c;
                        }
                    }
                    if (a.Skill_Tag.Tag_Filters.Count != 0)
                    {
                        string d = "ignore=";
                        foreach (string f in a.Skill_Tag.Tag_Filters)
                        {
                            if (string.IsNullOrWhiteSpace(f) == false)
                            {
                                d += f + ",";
                            }
                        }
                        d = d.Substring(0, d.Length - 1);
                        if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false)
                        {
                            b += ";" + d;
                        }
                    }
                    b += "}";
                if (string.IsNullOrWhiteSpace(a.Triggers.Type) == false)
                {
                    string c = " ~" + a.Triggers.Type;
                    switch (a.Triggers.Type)
                    {
                        case "onDamaged":
                            if (string.IsNullOrWhiteSpace(a.Triggers.Option) == false && IsNumeric(a.Triggers.Option))
                            {
                                c += " " + a.Triggers.Option;
                            }
                            break;
                        case "onTimer":
                            if (string.IsNullOrWhiteSpace(a.Triggers.Option) == false && IsNumeric(a.Triggers.Option))
                            {
                                c += ":" + a.Triggers.Option;
                            }
                            break;
                        case "onSignal":
                            if (string.IsNullOrWhiteSpace(a.Triggers.Option) == false)
                            {
                                c += ":" + a.Triggers.Option;
                            }
                            break;
                    }
                    b += c;
                }
                if (string.IsNullOrWhiteSpace(b) == false)
                {
                    Mob.Skills.Add(b);
                }
            }

            if (string.IsNullOrWhiteSpace(Equipment.Hand) == false)
                Mob.Equipment.Add(Equipment.Hand + ":0");
            if (string.IsNullOrWhiteSpace(Equipment.Boots) == false)
                Mob.Equipment.Add(Equipment.Boots + ":1");
            if (string.IsNullOrWhiteSpace(Equipment.Leggings) == false)
                Mob.Equipment.Add(Equipment.Leggings + ":2");
            if (string.IsNullOrWhiteSpace(Equipment.Chestplate) == false)
                Mob.Equipment.Add(Equipment.Chestplate + ":3");
            if (string.IsNullOrWhiteSpace(Equipment.Helmet) == false)
                Mob.Equipment.Add(Equipment.Helmet + ":4");
            if (string.IsNullOrWhiteSpace(Equipment.Assistant) == false)
                Mob.Equipment.Add(Equipment.Assistant + ":5");
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
        private void Return(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AIGoalSelectors_S.SelectedItem != null)
            {
                AI AI = new AIChange(new AI
                {
                    Number = AIGoalSelectors.Count,
                    Type = AI_Goal_S
                }).return_AI();
                AIGoalSelectors.Add(AI.Number, AI.Type);
                AI_G.Items.Add(AI);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (AITargetSelectors_S.SelectedItem != null)
            {
                AI AI = new AIChange(new AI
                {
                    Number = AITargetSelectors.Count - 1,
                    Type = AI_Goal_T
                }).return_AI();
                AITargetSelectors.Add(AI.Number, AI.Type);
                AI_T.Items.Add(AI);
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Drops_S.SelectedItem != null)
            {
                Drops Drops = new DropsChange(new Drops() { Type = Drops_C}).Drops_set();
                Drops_L.Add(Drops);
                Drops_T.Items.Add(Drops);
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (DropsPerLevel_S.SelectedItem != null)
            {
                Drops Drops = new DropsChange(new Drops() { Type = DropsPerLevel_C }).Drops_set();
                DropsPerLevel_L.Add(Drops);
                DropsPerLevel_T.Items.Add(Drops);
            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (DamageModifiers_S.SelectedItem != null)
            {
                DamageModifiers DamageModifiers = new DamageModifiersChange(new DamageModifiers() { Type = DamageModifiers_C }).DamageModifiers_set();
                DamageModifiers_L.Add(DamageModifiers);
                DamageModifiers_T.Items.Add(DamageModifiers);
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string KillMessages = new KillMessages("击杀").KillMessages_set();
            KillMessages_L.Add(KillMessages);
            KillMessages_T.Items.Add(KillMessages);
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (Skill_Effect_Type.SelectedItem == null)
                return;
            Effects Effects = new Effects()
            {
                Type = (string)Skill_Effect_Type.SelectedItem,
                Skill_Tag = new Obj_save.Mob.Skill_Tag()
                {
                    Tag_Type = "@Self",
                    Tag_Filters = new List<string>()
                }
            };
            switch (Skill_Effect_Type.SelectedItem)
            {
                case "blockmask":
                    Effects = new BlockMask(Effects).get_Effects_();
                    break;
                default:

                    break;
            }
            if (Effects != null)
            {
                Skills_effect.Add(Effects);
                SkillEffect_T.Items.Add(Effects);
            }
        }

        private void refash_AI_G()
        {
            AI_G.Items.Clear();
            foreach (KeyValuePair<int, string> a in AIGoalSelectors.ToArray())
            {
                AI_G.Items.Add(new AI
                {
                    Number = a.Key,
                    Type = a.Value
                });
            }
        }
        private void refash_AI_T()
        {
            AI_T.Items.Clear();
            foreach (KeyValuePair<int, string> a in AITargetSelectors.ToArray())
            {
                AI_T.Items.Add(new AI
                {
                    Number = a.Key,
                    Type = a.Value
                });
            }
        }
        private void refash_Drops()
        {
            Drops_T.Items.Clear();
            foreach (Drops a in Drops_L)
            {
                Drops_T.Items.Add(a);
            }
        }
        private void refash_DropsPerLevel()
        {
            DropsPerLevel_T.Items.Clear();
            foreach (Drops a in DropsPerLevel_L)
            {
                DropsPerLevel_T.Items.Add(a);
            }
        }
        private void refash_DamageModifiers()
        {
            DamageModifiers_T.Items.Clear();
            foreach (DamageModifiers a in DamageModifiers_L)
            {
                DamageModifiers_T.Items.Add(a);
            }
        }
        private void refash_KillMessages()
        {
            KillMessages_T.Items.Clear();
            foreach (string a in KillMessages_L)
            {
                KillMessages_T.Items.Add(a);
            }
        }
        private void refash_SkillEffect()
        {
            SkillEffect_T.Items.Clear();
            foreach (Effects a in Skills_effect)
            {
                SkillEffect_T.Items.Add(a);
            }
        }

        private void DelectAI_GEvent(object sender, RoutedEventArgs e)
        {
            if (AI_G.SelectedItem == null)
                return;
            int num = AI_G.SelectedIndex;
            AI_G.Items.Remove(AI_G.SelectedItem);
            AIGoalSelectors.Remove(num);
            foreach (KeyValuePair<int, string> a in AIGoalSelectors.ToArray())
            {
                if (a.Key > num)
                {
                    AIGoalSelectors.Add(a.Key - 1, a.Value);
                    AIGoalSelectors.Remove(a.Key);
                }
            }
            refash_AI_G();
        }
        private void ChangeAI_GEvent(object sender, RoutedEventArgs e)
        {
            if (AI_G.SelectedItem == null)
                return;
            AI AI = new AIChange(new AI
            {
                Number = AI_G.SelectedIndex,
                Type = AIGoalSelectors[AI_G.SelectedIndex]
            }).return_AI();
            if (AI.Type == AIGoalSelectors[AI_G.SelectedIndex] && AI.Number == AI_G.SelectedIndex)
                return;
            else if (AIGoalSelectors.ContainsKey(AI.Number))
            {
                Dictionary<int, string> temp = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string> i in AIGoalSelectors.ToArray())
                {
                    if (i.Key >= AI.Number && i.Value != AI.Type)
                    {
                        temp.Add(i.Key, i.Value);
                        AIGoalSelectors.Remove(i.Key);
                    }
                }
                AIGoalSelectors.Remove(AI_G.SelectedIndex);
                AIGoalSelectors.Add(AI.Number, AI.Type);
                foreach (KeyValuePair<int, string> i in temp)
                {
                    AIGoalSelectors.Add(AIGoalSelectors.Count, i.Value);
                }
                AIGoalSelectors = AIGoalSelectors.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
                refash_AI_G();
                return;
            }
            AIGoalSelectors.Remove(AI_G.SelectedIndex);
            if (AI.Number >= AIGoalSelectors.Count)
                AIGoalSelectors.Add(AIGoalSelectors.Count, AI.Type);
            else
                AIGoalSelectors.Add(AI.Number, AI.Type);
            refash_AI_G();
        }

        private void DelectAI_TEvent(object sender, RoutedEventArgs e)
        {
            if (AI_T.SelectedItem == null)
                return;
            int num = AI_T.SelectedIndex;
            AI_T.Items.Remove(AI_T.SelectedItem);
            AITargetSelectors.Remove(num);
            foreach (KeyValuePair<int, string> a in AITargetSelectors.ToArray())
            {
                if (a.Key > num)
                {
                    AITargetSelectors.Add(a.Key - 1, a.Value);
                    AITargetSelectors.Remove(a.Key);
                }
            }
            refash_AI_T();
        }
        private void ChangeAI_TEvent(object sender, RoutedEventArgs e)
        {
            if (AI_T.SelectedItem == null)
                return;
            AI AI = new AIChange(new AI()
            {
                Number = AI_T.SelectedIndex,
                Type = AITargetSelectors[AI_T.SelectedIndex]
            }).return_AI();
            if (AI.Type == AITargetSelectors[AI_T.SelectedIndex] && AI.Number == AI_T.SelectedIndex)
                return;
            else if (AITargetSelectors.ContainsKey(AI.Number))
            {
                Dictionary<int, string> temp = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string> i in AITargetSelectors.ToArray())
                {
                    if (i.Key >= AI.Number && i.Value != AI.Type)
                    {
                        temp.Add(i.Key, i.Value);
                        AITargetSelectors.Remove(i.Key);
                    }
                }
                AITargetSelectors.Remove(AI_T.SelectedIndex);
                AITargetSelectors.Add(AI.Number, AI.Type);
                foreach (KeyValuePair<int, string> i in temp)
                {
                    AITargetSelectors.Add(AITargetSelectors.Count, i.Value);
                }
                AITargetSelectors = AITargetSelectors.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
                refash_AI_T();
                return;
            }
            AITargetSelectors.Remove(AI_T.SelectedIndex);
            AI_T.Items.Remove(AI_T.SelectedItem);
            if (AI.Number >= AITargetSelectors.Count)
                AITargetSelectors.Add(AITargetSelectors.Count, AI.Type);
            else
                AITargetSelectors.Add(AI.Number, AI.Type);
        }
        private void DelectDropsEvent(object sender, RoutedEventArgs e)
        {
            if (Drops_T.SelectedItem == null)
                return;
            Drops a = (Drops)Drops_T.SelectedItem;
            Drops_L.Remove(a);
            refash_Drops();
        }
        private void ChangeDropsEvent(object sender, RoutedEventArgs e)
        {
            if (Drops_T.SelectedItem != null)
            {
                Drops_L.Remove((Drops)Drops_T.SelectedItem);
                Drops Drops = new DropsChange((Drops)Drops_T.SelectedItem).Drops_set();
                Drops_L.Add(Drops);
                refash_Drops();
            }
        }
        private void DelectDropsPerLevelEvent(object sender, RoutedEventArgs e)
        {
            if (DropsPerLevel_T.SelectedItem == null)
                return;
            Drops a = (Drops)DropsPerLevel_T.SelectedItem;
            DropsPerLevel_L.Remove(a);
            refash_DropsPerLevel();
        }
        private void ChangeDropsPerLevelEvent(object sender, RoutedEventArgs e)
        {
            if (DropsPerLevel_T.SelectedItem != null)
            {
                DropsPerLevel_L.Remove((Drops)DropsPerLevel_T.SelectedItem);
                Drops Drops = new DropsChange((Drops)DropsPerLevel_T.SelectedItem).Drops_set();
                DropsPerLevel_L.Add(Drops);
                refash_DropsPerLevel();
            }
        }
        private void DelectDamageModifiersEvent(object sender, RoutedEventArgs e)
        {
            if (DamageModifiers_T.SelectedItem == null)
                return;
            DamageModifiers a = (DamageModifiers)DamageModifiers_T.SelectedItem;
            DamageModifiers_L.Remove(a);
            refash_DamageModifiers();
        }
        private void ChangeDamageModifiersEvent(object sender, RoutedEventArgs e)
        {
            if (DropsPerLevel_T.SelectedItem != null)
            {
                DropsPerLevel_L.Remove((Drops)DropsPerLevel_T.SelectedItem);
                Drops Drops = new DropsChange((Drops)DropsPerLevel_T.SelectedItem).Drops_set();
                DropsPerLevel_L.Add(Drops);
                refash_DamageModifiers();
            }
        }
        private void DelectKillMessagesEvent(object sender, RoutedEventArgs e)
        {
            if (KillMessages_T.SelectedItem == null)
                return;
            string a = (string)KillMessages_T.SelectedItem;
            KillMessages_L.Remove(a);
            refash_KillMessages();
        }
        private void ChangeKillMessagesEvent(object sender, RoutedEventArgs e)
        {
            if (KillMessages_T.SelectedItem != null)
            {
                KillMessages_L.Remove((string)KillMessages_T.SelectedItem);
                string KillMessages = new KillMessages((string)KillMessages_T.SelectedItem).KillMessages_set();
                KillMessages_L.Add(KillMessages);
                refash_KillMessages();
            }
        }
        private void DelectSkillEffectEvent(object sender, RoutedEventArgs e)
        {
            if (SkillEffect_T.SelectedItem == null)
                return;
            Skills_effect.Remove((Effects)SkillEffect_T.SelectedItem);
            refash_SkillEffect();
        }
        private void ChangeSkillEffectEvent(object sender, RoutedEventArgs e)
        {
            if (SkillEffect_T.SelectedItem == null)
                return;
            Effects effects = (Effects)SkillEffect_T.SelectedItem;
            Skills_effect.Remove(effects);
            switch (effects.Type)
            {
                case "blockmask":
                    effects = new BlockMask(effects).get_Effects_();
                    break;
                default:

                    break;
            }
            Skills_effect.Add(effects);
            refash_SkillEffect();
        }
    }
}
