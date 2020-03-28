using MahApps.Metro.Controls;
using MythicMobs_edit.Obj_save.Mob;
using MythicMobs_edit.WPF.Mob.Effects_type;
using MythicMobs_edit.WPF.Mob.Mechanic_type;
using MythicMobs_edit.WPF.Mob.Mob_type;
using MythicMobs_edit.WPF.Mob.Other;
using MythicMobs_edit.WPF.Use;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Effects;
using YamlDotNet.Serialization;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// Addmob.xaml 的交互逻辑
    /// </summary>
    public partial class Addmob : Window
    {
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        internal enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19
        }

        internal enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);
            var accent = new AccentPolicy();
            var accentStructSize = Marshal.SizeOf(accent);
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }
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
        public List<Mechanic> Skills_mechanic { get; set; } = new List<Mechanic>();
        public List<Conditions> Conditions_L { get; set; } = new List<Conditions>();
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
            Disguise = new Obj_save.Mob.Disguise(),
            Skills = new List<string>(),
            Conditions = new List<string>()
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
            BG.Visibility = Visibility.Hidden;
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
            Skill_Mechanic_Type.ItemsSource = List.Skill_Mechanic;
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
        private void Skill_Mechanic_Type_r(object sender, RoutedEventArgs e)
        {
            Obj_save.Mob.List list = new Obj_save.Mob.List();
            Random random = new Random();
            Skill_Mechanic_Type.SelectedItem = list.Skill_Mechanic[random.Next(list.Skill_Mechanic.Count)];
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
        private void Disguise_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)Disguise_Type.SelectedItem == "player")
                skin.IsEnabled = true;
            else
                skin.IsEnabled = false;
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
                        string blockmask = "{";
                        Obj_save.Mob.Effects_type.BlockMask blockMask = (Obj_save.Mob.Effects_type.BlockMask)a.Option;
                        if (string.IsNullOrWhiteSpace(blockMask.material) == false)
                            blockmask += "m:" + blockMask.material + ";";
                        if (blockMask.data != 0)
                            blockmask += "dv:" + blockMask.data + ";";
                        if (blockMask.radius != 0)
                            blockmask += "r:" + blockMask.radius + ";";
                        if (blockMask.noise != 0)
                            blockmask += "n:" + blockMask.noise + ";";
                        if (blockMask.duration != 0)
                            blockmask += "d:" + blockMask.duration + ";";
                        if (string.IsNullOrWhiteSpace(blockMask.shape) == false)
                            blockmask += "s:" + blockMask.shape + ";";
                        blockmask += "na:" + blockMask.noair + ";";
                        blockmask += "s:" + blockMask.onlyair + ";";
                        blockmask += "}";
                        b += blockmask + " ";
                        break;
                    case "enderbeam":
                        string enderbeam = "{";
                        Obj_save.Mob.Effects_type.EnderBeam EnderBeam = (Obj_save.Mob.Effects_type.EnderBeam)a.Option;
                        enderbeam += "d:" + EnderBeam.duration + ";";
                        enderbeam += "y:" + EnderBeam.yoffset + ";";
                        enderbeam += "}";
                        b += enderbeam + " ";
                        break;
                    case "firework":
                        string firework = "{";
                        Obj_save.Mob.Effects_type.Firework Firework = (Obj_save.Mob.Effects_type.Firework)a.Option;
                        firework += "t:" + Firework.type + ";";
                        firework += "d:" + Firework.duration + ";";
                        firework += "f:" + Firework.flicker + ";";
                        firework += "tr:" + Firework.trail + ";";
                        if (string.IsNullOrWhiteSpace(Firework.colors) == false)
                            firework += "c:" + Firework.colors + ";";
                        if (string.IsNullOrWhiteSpace(Firework.fadecolors) == false)
                            firework += "fc:" + Firework.fadecolors + ";";
                        firework += "}";
                        b += firework + " ";
                        break;
                    case "geyser":
                        string geyser = "{";
                        Obj_save.Mob.Effects_type.Geyser Geyser = (Obj_save.Mob.Effects_type.Geyser)a.Option;
                        geyser += "t:" + Geyser.Type + ";";
                        geyser += "h:" + Geyser.height + ";";
                        geyser += "s:" + Geyser.speed + ";";
                        geyser += "}";
                        b += geyser + " ";
                        break;
                    case "itemspray":
                        string itemspray = "{";
                        Obj_save.Mob.Effects_type.ItemSpraycs ItemSpraycs = (Obj_save.Mob.Effects_type.ItemSpraycs)a.Option;
                        itemspray += "i:" + ItemSpraycs.item + ";";
                        itemspray += "a:" + ItemSpraycs.amount + ";";
                        itemspray += "d:" + ItemSpraycs.duration + ";";
                        itemspray += "r:" + ItemSpraycs.radius + ";";
                        itemspray += "v:" + ItemSpraycs.velocity + ";";
                        itemspray += "vv:" + ItemSpraycs.yVelocity + ";";
                        itemspray += "yo:" + ItemSpraycs.yOffset + ";";
                        itemspray += "ap:" + ItemSpraycs.allowpickup + ";";
                        itemspray += "}";
                        b += itemspray + " ";
                        break;
                    case "lightning":
                        string lightning = "{";
                        Obj_save.Mob.Effects_type.Lightning Lightning = (Obj_save.Mob.Effects_type.Lightning)a.Option;
                        lightning += "l:" + Lightning.localized + ";";
                        lightning += "r:" + Lightning.localizedradius + ";";
                        lightning += "}";
                        b += lightning + " ";
                        break;
                    case "particles":
                        string particles = "{";
                        Obj_save.Mob.Effects_type.Particles Particles = (Obj_save.Mob.Effects_type.Particles)a.Option;
                        particles += "p:" + Particles.particle + ";";
                        if (string.IsNullOrWhiteSpace(Particles.material) == false)
                            particles += "m:" + Particles.material + ";";
                        particles += "a:" + Particles.amount + ";";
                        particles += "hs:" + Particles.hSpread + ";";
                        particles += "vs:" + Particles.vSpread + ";";
                        particles += "s:" + Particles.speed + ";";
                        particles += "y:" + Particles.yOffset + ";";
                        particles += "vd:" + Particles.viewDistance + ";";
                        particles += "c:" + Particles.color + ";";
                        particles += "fo:" + Particles.fromorigin + ";";
                        particles += "}";
                        b += particles + " ";
                        break;
                    case "particlebox":
                        string particlebox = "{";
                        Obj_save.Mob.Effects_type.ParticleBox ParticleBox = (Obj_save.Mob.Effects_type.ParticleBox)a.Option;
                        particlebox += "p:" + ParticleBox.particle + ";";
                        if (string.IsNullOrWhiteSpace(ParticleBox.material) == false)
                            particlebox += "m:" + ParticleBox.material + ";";
                        particlebox += "a:" + ParticleBox.amount + ";";
                        particlebox += "hs:" + ParticleBox.hSpread + ";";
                        particlebox += "vs:" + ParticleBox.vSpread + ";";
                        particlebox += "s:" + ParticleBox.speed + ";";
                        particlebox += "y:" + ParticleBox.yOffset + ";";
                        particlebox += "vd:" + ParticleBox.viewDistance + ";";
                        particlebox += "c:" + ParticleBox.color + ";";
                        particlebox += "fo:" + ParticleBox.fromorigin + ";";
                        particlebox += "r:" + ParticleBox.radius + ";";
                        particlebox += "}";
                        b += particlebox + " ";
                        break;
                    case "particleline":
                        string particleline = "{";
                        Obj_save.Mob.Effects_type.ParticleLine ParticleLine = (Obj_save.Mob.Effects_type.ParticleLine)a.Option;
                        particleline += "p:" + ParticleLine.particle + ";";
                        if (string.IsNullOrWhiteSpace(ParticleLine.material) == false)
                            particleline += "m:" + ParticleLine.material + ";";
                        particleline += "a:" + ParticleLine.amount + ";";
                        particleline += "hs:" + ParticleLine.hSpread + ";";
                        particleline += "vs:" + ParticleLine.vSpread + ";";
                        particleline += "s:" + ParticleLine.speed + ";";
                        particleline += "y:" + ParticleLine.yOffset + ";";
                        particleline += "vd:" + ParticleLine.viewDistance + ";";
                        particleline += "c:" + ParticleLine.color + ";";
                        particleline += "fo:" + ParticleLine.fromorigin + ";";
                        particleline += "db:" + ParticleLine.distanceBetween + ";";
                        particleline += "ys:" + ParticleLine.yStartOffset + ";";
                        particleline += "}";
                        b += particleline + " ";
                        break;
                    case "particlering":
                        string particlering = "{";
                        Obj_save.Mob.Effects_type.ParticleRing ParticleRing = (Obj_save.Mob.Effects_type.ParticleRing)a.Option;
                        particlering += "p:" + ParticleRing.particle + ";";
                        if (string.IsNullOrWhiteSpace(ParticleRing.material) == false)
                            particlering += "m:" + ParticleRing.material + ";";
                        particlering += "a:" + ParticleRing.amount + ";";
                        particlering += "hs:" + ParticleRing.hSpread + ";";
                        particlering += "vs:" + ParticleRing.vSpread + ";";
                        particlering += "s:" + ParticleRing.speed + ";";
                        particlering += "y:" + ParticleRing.yOffset + ";";
                        particlering += "vd:" + ParticleRing.viewDistance + ";";
                        particlering += "c:" + ParticleRing.color + ";";
                        particlering += "fo:" + ParticleRing.fromorigin + ";";
                        particlering += "}";
                        b += particlering + " ";
                        break;
                    case "particlesphere":
                        string particlesphere = "{";
                        Obj_save.Mob.Effects_type.ParticleSphere ParticleSphere = (Obj_save.Mob.Effects_type.ParticleSphere)a.Option;
                        particlesphere += "p:" + ParticleSphere.particle + ";";
                        if (string.IsNullOrWhiteSpace(ParticleSphere.material) == false)
                            particlesphere += "m:" + ParticleSphere.material + ";";
                        particlesphere += "a:" + ParticleSphere.amount + ";";
                        particlesphere += "hs:" + ParticleSphere.hSpread + ";";
                        particlesphere += "vs:" + ParticleSphere.vSpread + ";";
                        particlesphere += "s:" + ParticleSphere.speed + ";";
                        particlesphere += "y:" + ParticleSphere.yOffset + ";";
                        particlesphere += "vd:" + ParticleSphere.viewDistance + ";";
                        particlesphere += "c:" + ParticleSphere.color + ";";
                        particlesphere += "fo:" + ParticleSphere.fromorigin + ";";
                        particlesphere += "r:" + ParticleSphere.radius + ";";
                        particlesphere += "}";
                        b += particlesphere + " ";
                        break;
                    case "particletornado":
                        string particletornado = "{";
                        Obj_save.Mob.Effects_type.ParticleTornado ParticleTornado = (Obj_save.Mob.Effects_type.ParticleTornado)a.Option;
                        particletornado += "p:" + ParticleTornado.particle + ";";
                        if (string.IsNullOrWhiteSpace(ParticleTornado.material) == false)
                            particletornado += "m:" + ParticleTornado.material + ";";
                        particletornado += "a:" + ParticleTornado.amount + ";";
                        particletornado += "hs:" + ParticleTornado.hSpread + ";";
                        particletornado += "vs:" + ParticleTornado.vSpread + ";";
                        particletornado += "s:" + ParticleTornado.speed + ";";
                        particletornado += "y:" + ParticleTornado.yOffset + ";";
                        particletornado += "vd:" + ParticleTornado.viewDistance + ";";
                        particletornado += "c:" + ParticleTornado.color + ";";
                        particletornado += "fo:" + ParticleTornado.fromorigin + ";";
                        particletornado += "mr:" + ParticleTornado.maxradius + ";";
                        particletornado += "yo:" + ParticleTornado.yoffset + ";";
                        particletornado += "h:" + ParticleTornado.height + ";";
                        particletornado += "i:" + ParticleTornado.interval + ";";
                        particletornado += "d:" + ParticleTornado.duration + ";";
                        particletornado += "rs:" + ParticleTornado.rotationspeed + ";";
                        particletornado += "sh:" + ParticleTornado.sliceheight + ";";
                        particletornado += "cp:" + ParticleTornado.cloudparticle + ";";
                        particletornado += "cs:" + ParticleTornado.cloudsize + ";";
                        particletornado += "ca:" + ParticleTornado.cloudamount + ";";
                        particletornado += "chs:" + ParticleTornado.cloudhspread + ";";
                        particletornado += "cvs:" + ParticleTornado.cloudvspread + ";";
                        particletornado += "cps:" + ParticleTornado.cloudpspeed + ";";
                        particletornado += "cyo:" + ParticleTornado.cloudyoffset + ";";
                        particletornado += "}";
                        b += particletornado + " ";
                        break;
                    case "smoke":
                        string smoke = "{";
                        Obj_save.Mob.Effects_type.Smoke Smoke = (Obj_save.Mob.Effects_type.Smoke)a.Option;
                        smoke += "d:" + Smoke.direction + ";";
                        smoke += "}";
                        b += smoke + " ";
                        break;
                    case "smokeswirl":
                        string smokeswirl = "{";
                        Obj_save.Mob.Effects_type.SmokeSwirl SmokeSwirl = (Obj_save.Mob.Effects_type.SmokeSwirl)a.Option;
                        smokeswirl += "d:" + SmokeSwirl.duration + ";";
                        smokeswirl += "i:" + SmokeSwirl.interval + ";";
                        smokeswirl += "}";
                        b += smokeswirl + " ";
                        break;
                    case "sound":
                        string sound = "{";
                        Obj_save.Mob.Effects_type.Sound Sound = (Obj_save.Mob.Effects_type.Sound)a.Option;
                        sound += "s:" + Sound.sound + ";";
                        sound += "p:" + Sound.pitch + ";";
                        sound += "v:" + Sound.volume + ";";
                        sound += "}";
                        b += sound + " ";
                        break;
                    case "spin":
                        string spin = "{";
                        Obj_save.Mob.Effects_type.Spin Spin = (Obj_save.Mob.Effects_type.Spin)a.Option;
                        spin += "d:" + Spin.duration + ";";
                        spin += "v:" + Spin.velocity + ";";
                        spin += "}";
                        b += spin + " ";
                        break;
                    case "glow":
                        string glow = "{";
                        Obj_save.Mob.Effects_type.Glow Glow = (Obj_save.Mob.Effects_type.Glow)a.Option;
                        glow += "c:" + Glow.color + ";";
                        glow += "d:" + Glow.duration + ";";
                        glow += "}";
                        b += glow + " ";
                        break;
                    default:
                        b += " ";
                        break;
                }
                
                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Type) == false)
                {
                    string c = a.Skill_Tag.Tag_Type;
                    b += c;
                }
                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false || a.Skill_Tag.Tag_Filters.Count != 0)
                {
                    b += "{";
                }
                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false)
                {
                    b += a.Skill_Tag.Tag_Option;
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
                    else
                        b += d;
                }
                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false || a.Skill_Tag.Tag_Filters.Count != 0)
                {
                    b += "}";
                }
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
            foreach (Mechanic a in Skills_mechanic)
            {
                string b = a.Type;
                switch (a.Type)
                {
                    case "activatespawner":
                        string activatespawner = "{";
                        Obj_save.Mob.Mechanic_type.ActivateSpawner ActivateSpawner = (Obj_save.Mob.Mechanic_type.ActivateSpawner)a.Option;
                        activatespawner += "spawner=" + ActivateSpawner.spawners;
                        activatespawner += "}";
                        b += activatespawner + " ";
                        break;
                    case "arrowvolley":
                        string arrowvolley = "{";
                        Obj_save.Mob.Mechanic_type.ArrowVolley ArrowVolley = (Obj_save.Mob.Mechanic_type.ArrowVolley)a.Option;
                        arrowvolley += "a=" + ArrowVolley.amount + ";";
                        arrowvolley += "s=" + ArrowVolley.spread + ";";
                        arrowvolley += "v=" + ArrowVolley.velocity + ";";
                        arrowvolley += "f=" + ArrowVolley.fireTicks + ";";
                        arrowvolley += "rd=" + ArrowVolley.removeDelay;
                        arrowvolley += "}";
                        b += arrowvolley + " ";
                        break;
                    case "command":
                        string command = "{";
                        Obj_save.Mob.Mechanic_type.Command Command = (Obj_save.Mob.Mechanic_type.Command)a.Option;
                        command += "c=\"" + Command.command + "\";";
                        command += "ac=" + Command.asCaster + ";";
                        command += "op=" + Command.asOp;
                        command += "}";
                        b += command + " ";
                        break;
                    case "consume":
                        string consume = "{";
                        Obj_save.Mob.Mechanic_type.Consume Consume = (Obj_save.Mob.Mechanic_type.Consume)a.Option;
                        consume += "d=" + Consume.damage + ";";
                        consume += "h=" + Consume.heal + ";";
                        consume += "pk=" + Consume.preventknockback + ";";
                        consume += "pi=" + Consume.preventimmunity + ";";
                        consume += "i=" + Consume.ignorearmor;
                        consume += "}";
                        b += consume + " ";
                        break;
                    case "disguise":
                        string disguise = "{";
                        Obj_save.Mob.Mechanic_type.Disguise Disguise = (Obj_save.Mob.Mechanic_type.Disguise)a.Option;
                        disguise += "type=" + Disguise.Type;
                        if (string.IsNullOrWhiteSpace(Disguise.player) == false)
                        {
                            disguise += ";player=" + Disguise.player;
                        }
                        if (string.IsNullOrWhiteSpace(Disguise.skin) == false)
                        {
                            disguise += ";skin=" + Disguise.skin;
                        }
                        disguise += "}";
                        b += disguise + " ";
                        break;
                    case "currencygive":
                        string currencygive = "{";
                        Obj_save.Mob.Mechanic_type.CurrencyGive CurrencyGive = (Obj_save.Mob.Mechanic_type.CurrencyGive)a.Option;
                        currencygive += "amount=" + CurrencyGive.amount;
                        currencygive += "}";
                        b += currencygive + " ";
                        break;
                    case "currencytake":
                        string currencytake = "{";
                        Obj_save.Mob.Mechanic_type.CurrencyTake CurrencyTake = (Obj_save.Mob.Mechanic_type.CurrencyTake)a.Option;
                        currencytake += "amount=" + CurrencyTake.amount;
                        currencytake += "}";
                        b += currencytake + " ";
                        break;
                    case "damage":
                        string damage = "{";
                        Obj_save.Mob.Mechanic_type.Damage Damage = (Obj_save.Mob.Mechanic_type.Damage)a.Option;
                        damage += "amount=" + Damage.amount + ";";
                        damage += "ia=" + Damage.ignoreArmor + ";";
                        damage += "pk=" + Damage.preventknockback + ";";
                        damage += "pi=" + Damage.preventimmunity;
                        damage += "}";
                        b += damage + " ";
                        break;
                    case "basedamage":
                        string basedamage = "{";
                        Obj_save.Mob.Mechanic_type.BaseDamage BaseDamage = (Obj_save.Mob.Mechanic_type.BaseDamage)a.Option;
                        basedamage += "m=" + BaseDamage.multiplier + ";";
                        basedamage += "ia=" + BaseDamage.ignoreArmor + ";";
                        basedamage += "pk=" + BaseDamage.preventknockback + ";";
                        basedamage += "pi=" + BaseDamage.preventimmunity;
                        basedamage += "}";
                        b += basedamage + " ";
                        break;
                    case "percentDamage":
                        string percentDamage = "{";
                        Obj_save.Mob.Mechanic_type.PercentDamage PercentDamage = (Obj_save.Mob.Mechanic_type.PercentDamage)a.Option;
                        percentDamage += "p=" + PercentDamage.percent + ";";
                        percentDamage += "c=" + PercentDamage.current;
                        percentDamage += "}";
                        b += percentDamage + " ";
                        break;
                    case "equip":
                        string equip = "{";
                        Obj_save.Mob.Mechanic_type.Equip Equip = (Obj_save.Mob.Mechanic_type.Equip)a.Option;
                        equip += "i=" + Equip.item;
                        equip += "}";
                        b += equip + " ";
                        break;
                    case "explosion":
                        string explosion = "{";
                        Obj_save.Mob.Mechanic_type.Explosion Explosion = (Obj_save.Mob.Mechanic_type.Explosion)a.Option;
                        explosion += "y=" + Explosion.yield + ";";
                        explosion += "bd=" + Explosion.blockdamage + ";";
                        explosion += "f=" + Explosion.fire;
                        explosion += "}";
                        b += explosion + " ";
                        break;
                    case "feed":
                        string feed = "{";
                        Obj_save.Mob.Mechanic_type.Feed Feed = (Obj_save.Mob.Mechanic_type.Feed)a.Option;
                        feed += "a=" + Feed.amount + ";";
                        feed += "s=" + Feed.saturation + ";";
                        feed += "o=" + Feed.overfeed;
                        feed += "}";
                        b += feed + " ";
                        break;
                    case "forcepull":
                        string forcepull = "{";
                        Obj_save.Mob.Mechanic_type.ForcePull ForcePull = (Obj_save.Mob.Mechanic_type.ForcePull)a.Option;
                        forcepull += "s=" + ForcePull.spread + ";";
                        forcepull += "vs=" + ForcePull.vspread;
                        forcepull += "}";
                        b += forcepull + " ";
                        break;
                    case "heal":
                        string heal = "{";
                        Obj_save.Mob.Mechanic_type.Heal Heal = (Obj_save.Mob.Mechanic_type.Heal)a.Option;
                        heal += "a=" + Heal.amount + ";";
                        heal += "oh=" + Heal.overheal;
                        heal += "}";
                        b += heal + " ";
                        break;
                    case "healpercent":
                        string healpercent = "{";
                        Obj_save.Mob.Mechanic_type.HealPercent HealPercent = (Obj_save.Mob.Mechanic_type.HealPercent)a.Option;
                        healpercent += "m=" + HealPercent.multiplier + ";";
                        healpercent += "overheal=" + HealPercent.overheal;
                        healpercent += "}";
                        b += healpercent + " ";
                        break;
                    case "ignite":
                        string ignite = "{";
                        Obj_save.Mob.Mechanic_type.Ignite Ignite = (Obj_save.Mob.Mechanic_type.Ignite)a.Option;
                        ignite += "ticks=" + Ignite.ticks;
                        ignite += "}";
                        b += ignite + " ";
                        break;
                    case "jsonmessage":
                        string jsonmessage = "{";
                        Obj_save.Mob.Mechanic_type.JSONMessage JSONMessage = (Obj_save.Mob.Mechanic_type.JSONMessage)a.Option;
                        jsonmessage += "m=" + JSONMessage.message;
                        jsonmessage += "}";
                        b += jsonmessage + " ";
                        break;
                    case "jump":
                        string jump = "{";
                        Obj_save.Mob.Mechanic_type.Jump Jump = (Obj_save.Mob.Mechanic_type.Jump)a.Option;
                        jump += "v=" + Jump.velocity;
                        jump += "}";
                        b += jump + " ";
                        break;
                    case "leap":
                        string leap = "{";
                        Obj_save.Mob.Mechanic_type.Leap Leap = (Obj_save.Mob.Mechanic_type.Leap)a.Option;
                        leap += "v=" + Leap.velocity + ";";
                        leap += "noise=" + Leap.noise;
                        leap += "}";
                        b += leap + " ";
                        break;
                    case "lightning":
                        string lightning = "{";
                        Obj_save.Mob.Mechanic_type.Lightning Lightning = (Obj_save.Mob.Mechanic_type.Lightning)a.Option;
                        lightning += "d=" + Lightning.damage;
                        lightning += "}";
                        b += lightning + " ";
                        break;
                    case "look":
                        string look = "{";
                        Obj_save.Mob.Mechanic_type.Look Look = (Obj_save.Mob.Mechanic_type.Look)a.Option;
                        look += "headOnly=" + Look.headOnly + ";";
                        look += "immediately=" + Look.immediately;
                        look += "}";
                        b += look + " ";
                        break;
                    case "message":
                        string message = "{";
                        Obj_save.Mob.Mechanic_type.Message Message = (Obj_save.Mob.Mechanic_type.Message)a.Option;
                        message += "m=" + Message.message;
                        message += "}";
                        b += message + " ";
                        break;
                    case "modifyglobalscore":
                        string modifyglobalscore = "{";
                        Obj_save.Mob.Mechanic_type.ModifyGlobalScore ModifyGlobalScore = (Obj_save.Mob.Mechanic_type.ModifyGlobalScore)a.Option;
                        modifyglobalscore += "o=" + ModifyGlobalScore.objective + ";";
                        modifyglobalscore += "a=" + ModifyGlobalScore.action + ";";
                        modifyglobalscore += "v=" + ModifyGlobalScore.value;
                        modifyglobalscore += "}";
                        b += modifyglobalscore + " ";
                        break;
                    case "modifytargetscore":
                        string modifytargetscore = "{";
                        Obj_save.Mob.Mechanic_type.ModifyTargetScore ModifyTargetScore = (Obj_save.Mob.Mechanic_type.ModifyTargetScore)a.Option;
                        modifytargetscore += "o=" + ModifyTargetScore.objective + ";";
                        modifytargetscore += "a=" + ModifyTargetScore.action + ";";
                        modifytargetscore += "v=" + ModifyTargetScore.value;
                        modifytargetscore += "}";
                        b += modifytargetscore + " ";
                        break;
                    case "modifyscore":
                        string modifyscore = "{";
                        Obj_save.Mob.Mechanic_type.ModifyScore ModifyScore = (Obj_save.Mob.Mechanic_type.ModifyScore)a.Option;
                        modifyscore += "o=" + ModifyScore.objective + ";";
                        modifyscore += "a=" + ModifyScore.action + ";";
                        modifyscore += "v=" + ModifyScore.value + ";";
                        modifyscore += "n=" + ModifyScore.name;
                        modifyscore += "}";
                        b += modifyscore + " ";
                        break;
                    case "mount":
                        string mount = "{";
                        Obj_save.Mob.Mechanic_type.Mount Mount = (Obj_save.Mob.Mechanic_type.Mount)a.Option;
                        mount += "t=" + Mount.type;
                        mount += "}";
                        b += mount + " ";
                        break;
                    case "potion":
                        string potion = "{";
                        Obj_save.Mob.Mechanic_type.Potion Potion = (Obj_save.Mob.Mechanic_type.Potion)a.Option;
                        potion += "t=" + Potion.type + ";";
                        potion += "d=" + Potion.duration + ";";
                        potion += "l=" + Potion.level + ";";
                        potion += "force=" + Potion.force + ";";
                        potion += "hasParticles=" + Potion.hasParticles + ";";
                        potion += "hasIcon=" + Potion.hasIcon;
                        potion += "}";
                        b += potion + " ";
                        break;
                    case "prison":
                        string prison = "{";
                        Obj_save.Mob.Mechanic_type.Prison Prison = (Obj_save.Mob.Mechanic_type.Prison)a.Option;
                        prison += "m=" + Prison.material + ";";
                        prison += "d=" + Prison.duration + ";";
                        prison += "b=" + Prison.breakable;
                        prison += "}";
                        b += prison + " ";
                        break;
                    case "pull":
                        string pull = "{";
                        Obj_save.Mob.Mechanic_type.Pull Pull = (Obj_save.Mob.Mechanic_type.Pull)a.Option;
                        pull += "v=" + Pull.velocity + ";";
                        pull += "to=" + Pull.toOrigin;
                        pull += "}";
                        b += pull + " ";
                        break;
                    case "pushbutton":
                        string pushbutton = "{";
                        Obj_save.Mob.Mechanic_type.PushButton PushButton = (Obj_save.Mob.Mechanic_type.PushButton)a.Option;
                        pushbutton += "x=" + PushButton.x + ";";
                        pushbutton += "y=" + PushButton.y + ";";
                        pushbutton += "z=" + PushButton.z;
                        pushbutton += "}";
                        b += pushbutton + " ";
                        break;
                    case "rally":
                        string rally = "{";
                        Obj_save.Mob.Mechanic_type.Rally Rally = (Obj_save.Mob.Mechanic_type.Rally)a.Option;
                        rally += "t=" + Rally.types + ";";
                        rally += "r=" + Rally.radius + ";";
                        rally += "vr=" + Rally.vradius + ";";
                        rally += "hr=" + Rally.hradius + ";";
                        rally += "ot=" + Rally.overwritetarget;
                        rally += "}";
                        b += rally + " ";
                        break;
                    case "randommessage":
                        string randommessage = "{m=";
                        Obj_save.Mob.Mechanic_type.RandomMessage RandomMessage = (Obj_save.Mob.Mechanic_type.RandomMessage)a.Option;
                        foreach (string f in RandomMessage.message)
                        {
                            if (string.IsNullOrWhiteSpace(f) == false)
                            {
                                randommessage += f + ",";
                            }
                        }
                        randommessage = randommessage.Substring(0, randommessage.Length - 1);
                        randommessage += "}";
                        b += randommessage + " ";
                        break;
                    case "remove":
                        string remove = "{";
                        Obj_save.Mob.Mechanic_type.Remove Remove = (Obj_save.Mob.Mechanic_type.Remove)a.Option;
                        remove += "delay=" + Remove.delay;
                        remove += "}";
                        b += remove + " ";
                        break;
                    case "runaigoalselector":
                        string runaigoalselector = "{";
                        Obj_save.Mob.Mechanic_type.RunAIGoalSelector RunAIGoalSelector = (Obj_save.Mob.Mechanic_type.RunAIGoalSelector)a.Option;
                        runaigoalselector += "goal=" + RunAIGoalSelector.goal;
                        runaigoalselector += "}";
                        b += runaigoalselector + " ";
                        break;
                    case "runaitargetselector":
                        string runaitargetselector = "{";
                        Obj_save.Mob.Mechanic_type.RunAITargetSelector RunAITargetSelector = (Obj_save.Mob.Mechanic_type.RunAITargetSelector)a.Option;
                        runaitargetselector += "goal=" + RunAITargetSelector.goal;
                        runaitargetselector += "}";
                        b += runaitargetselector + " ";
                        break;
                    case "actionmessage":
                        string actionmessage = "{";
                        Obj_save.Mob.Mechanic_type.ActionMessage ActionMessage = (Obj_save.Mob.Mechanic_type.ActionMessage)a.Option;
                        actionmessage += "m=" + ActionMessage.message;
                        actionmessage += "}";
                        b += actionmessage + " ";
                        break;
                    case "sendtitle":
                        string sendtitle = "{";
                        Obj_save.Mob.Mechanic_type.SendTitle SendTitle = (Obj_save.Mob.Mechanic_type.SendTitle)a.Option;
                        sendtitle += "t=" + SendTitle.title + ";";
                        sendtitle += "st=" + SendTitle.subtitle + ";";
                        sendtitle += "d=" + SendTitle.duration + ";";
                        sendtitle += "fi=" + SendTitle.fadeIn + ";";
                        sendtitle += "fo=" + SendTitle.fadeOut;
                        sendtitle += "}";
                        b += sendtitle + " ";
                        break;
                    case "setblock":
                        string setblock = "{";
                        Obj_save.Mob.Mechanic_type.SetBlockType SetBlockType = (Obj_save.Mob.Mechanic_type.SetBlockType)a.Option;
                        setblock += "m=" + SetBlockType.material + ";";
                        setblock += "md=" + SetBlockType.data;
                        setblock += "}";
                        b += setblock + " ";
                        break;
                    case "setgliding":
                        string setgliding = "{";
                        Obj_save.Mob.Mechanic_type.SetGliding SetGliding = (Obj_save.Mob.Mechanic_type.SetGliding)a.Option;
                        setgliding += "g=" + SetGliding.gliding;
                        setgliding += "}";
                        b += setgliding + " ";
                        break;
                    case "setglobalscore":
                        string setglobalscore = "{";
                        Obj_save.Mob.Mechanic_type.SetGlobalScore SetGlobalScore = (Obj_save.Mob.Mechanic_type.SetGlobalScore)a.Option;
                        setglobalscore += "o=" + SetGlobalScore.objective + ";";
                        setglobalscore += "v=" + SetGlobalScore.value;
                        setglobalscore += "}";
                        b += setglobalscore + " ";
                        break;
                    case "setlevel":
                        string setlevel = "{";
                        Obj_save.Mob.Mechanic_type.SetLevel SetLevel = (Obj_save.Mob.Mechanic_type.SetLevel)a.Option;
                        setlevel += "a=" + SetLevel.action + ";";
                        setlevel += "l=" + SetLevel.level;
                        setlevel += "}";
                        b += setlevel + " ";
                        break;
                    case "setmobscore":
                        string setmobscore = "{";
                        Obj_save.Mob.Mechanic_type.SetMobScore SetMobScore = (Obj_save.Mob.Mechanic_type.SetMobScore)a.Option;
                        setmobscore += "o=" + SetMobScore.objective + ";";
                        setmobscore += "v=" + SetMobScore.value;
                        setmobscore += "}";
                        b += setmobscore + " ";
                        break;
                    case "settargetscore":
                        string settargetscore = "{";
                        Obj_save.Mob.Mechanic_type.SetTargetScore SetTargetScore = (Obj_save.Mob.Mechanic_type.SetTargetScore)a.Option;
                        settargetscore += "o=" + SetTargetScore.objective + ";";
                        settargetscore += "v=" + SetTargetScore.value;
                        settargetscore += "}";
                        b += settargetscore + " ";
                        break;
                    case "setscore":
                        string setscore = "{";
                        Obj_save.Mob.Mechanic_type.SetScore SetScore = (Obj_save.Mob.Mechanic_type.SetScore)a.Option;
                        setscore += "o=" + SetScore.objective + ";";
                        setscore += "v=" + SetScore.value;
                        setscore += "}";
                        b += setscore + " ";
                        break;
                    case "setstance":
                        Obj_save.Mob.Mechanic_type.SetStance SetStance = (Obj_save.Mob.Mechanic_type.SetStance)a.Option;
                        if (string.IsNullOrWhiteSpace(SetStance.stance) == false)
                        {
                            string setstance = "{";
                            setstance += "stance=" + SetStance.stance;
                            setstance += "}";
                            b += setstance + " ";
                        }
                        break;
                    case "shootfireball":
                        string shootfireball = "{";
                        Obj_save.Mob.Mechanic_type.ShootFireball ShootFireball = (Obj_save.Mob.Mechanic_type.ShootFireball)a.Option;
                        shootfireball += "y=" + ShootFireball.yield + ";";
                        shootfireball += "v=" + ShootFireball.velocity + ";";
                        shootfireball += "i=" + ShootFireball.incendiary + ";";
                        shootfireball += "ft=" + ShootFireball.fireTicks + ";";
                        shootfireball += "small=" + ShootFireball.smallfireball + ";";
                        shootfireball += "ps=" + ShootFireball.playsound;
                        shootfireball += "}";
                        b += shootfireball + " ";
                        break;
                    case "shootpotion":
                        string shootpotion = "{";
                        Obj_save.Mob.Mechanic_type.ShootPotion ShootPotion = (Obj_save.Mob.Mechanic_type.ShootPotion)a.Option;
                        shootpotion += "t=" + ShootPotion.type + ";";
                        shootpotion += "d=" + ShootPotion.duration + ";";
                        shootpotion += "l=" + ShootPotion.level + ";";
                        shootpotion += "v=" + ShootPotion.velocity + ";";
                        shootpotion += "p=" + ShootPotion.hasParticles + ";";
                        shootpotion += "i=" + ShootPotion.hasIcon; 
                        shootpotion += "}";
                        b += shootpotion + " ";
                        break;
                    case "shootskull":
                        string shootskull = "{";
                        Obj_save.Mob.Mechanic_type.ShootSkull ShootSkull = (Obj_save.Mob.Mechanic_type.ShootSkull)a.Option;
                        shootskull += "y=" + ShootSkull.yield + ";";
                        shootskull += "v=" + ShootSkull.v + ";";
                        shootskull += "ps=" + ShootSkull.playsound;
                        shootskull += "}";
                        b += shootskull + " ";
                        break;
                    case "signal":
                        string signal = "{";
                        Obj_save.Mob.Mechanic_type.Signal Signal = (Obj_save.Mob.Mechanic_type.Signal)a.Option;
                        signal += "s=" + Signal.signal;
                        signal += "}";
                        b += signal + " ";
                        break;
                    case "spring":
                        string spring = "{";
                        Obj_save.Mob.Mechanic_type.Spring Spring = (Obj_save.Mob.Mechanic_type.Spring)a.Option;
                        spring += "t=" + Spring.type + ";";
                        spring += "d=" + Spring.duration;
                        spring += "}";
                        b += spring + " ";
                        break;
                    case "summon":
                        string summon = "{";
                        Obj_save.Mob.Mechanic_type.Summon Summon = (Obj_save.Mob.Mechanic_type.Summon)a.Option;
                        summon += "t=" + Summon.type + ";";
                        summon += "a=" + Summon.amount + ";";
                        summon += "r=" + Summon.radius + ";";
                        summon += "yr=" + Summon.yRadius + ";";
                        summon += "yu=" + Summon.yRadiusUpOnly + ";";
                        summon += "os=" + Summon.onSurface + ";";
                        summon += "ctt=" + Summon.copyThreatTable + ";";
                        summon += "itt=" + Summon.inheritThreatTable;
                        summon += "}";
                        b += summon + " ";
                        break;
                    case "addtag":
                        string addtag = "{";
                        Obj_save.Mob.Mechanic_type.AddTag AddTag = (Obj_save.Mob.Mechanic_type.AddTag)a.Option;
                        addtag += "t=" + AddTag.tag;
                        addtag += "}";
                        b += addtag + " ";
                        break;
                    case "removetag":
                        string removetag = "{";
                        Obj_save.Mob.Mechanic_type.RemoveTag RemoveTag = (Obj_save.Mob.Mechanic_type.RemoveTag)a.Option;
                        removetag += "t=" + RemoveTag.tag;
                        removetag += "}";
                        b += removetag + " ";
                        break;
                    case "teleport":
                        string teleport = "{";
                        Obj_save.Mob.Mechanic_type.Teleport Teleport = (Obj_save.Mob.Mechanic_type.Teleport)a.Option;
                        teleport += "sh=" + Teleport.spreadh + ";";
                        teleport += "sv=" + Teleport.spreadv;
                        teleport += "}";
                        b += teleport + " ";
                        break;
                    case "teleportto":
                        string teleportto = "{";
                        Obj_save.Mob.Mechanic_type.TeleportTo TeleportTo = (Obj_save.Mob.Mechanic_type.TeleportTo)a.Option;
                        teleportto += "l=" + TeleportTo.location + ";";
                        teleportto += "w=" + TeleportTo.world + ";";
                        teleportto += "y=" + TeleportTo.yaw + ";";
                        teleportto += "p=" + TeleportTo.pitch;
                        teleportto += "}";
                        b += teleportto + " ";
                        break;
                    case "threat":
                        string threat = "{";
                        Obj_save.Mob.Mechanic_type.Threat Threat = (Obj_save.Mob.Mechanic_type.Threat)a.Option;
                        threat += "a=" + Threat.amount;
                        threat += "}";
                        b += threat + " ";
                        break;
                    case "throw":
                        string throw_ = "{";
                        Obj_save.Mob.Mechanic_type.Throw Throw = (Obj_save.Mob.Mechanic_type.Throw)a.Option;
                        throw_ += "y=" + Throw.velocity + ";";
                        throw_ += "a=" + Throw.velocityY;
                        throw_ += "}";
                        b += throw_ + " ";
                        break;
                    case "togglelever":
                        string togglelever = "{";
                        Obj_save.Mob.Mechanic_type.ToggleLever ToggleLever = (Obj_save.Mob.Mechanic_type.ToggleLever)a.Option;
                        togglelever += "d=" + ToggleLever.duration + ";";
                        togglelever += "x=" + ToggleLever.x + ";";
                        togglelever += "y=" + ToggleLever.y + ";";
                        togglelever += "z=" + ToggleLever.z;
                        togglelever += "}";
                        b += togglelever + " ";
                        break;
                    case "velocity":
                        string velocity = "{";
                        Obj_save.Mob.Mechanic_type.Velocity Velocity = (Obj_save.Mob.Mechanic_type.Velocity)a.Option;
                        velocity += "m=" + Velocity.mode + ";";
                        velocity += "x=" + Velocity.velocityx + ";";
                        velocity += "y=" + Velocity.velocityy + ";";
                        velocity += "z=" + Velocity.velocityz;
                        velocity += "}";
                        b += velocity + " ";
                        break;
                    case "weather":
                        string weather = "{";
                        Obj_save.Mob.Mechanic_type.Weather Weather = (Obj_save.Mob.Mechanic_type.Weather)a.Option;
                        weather += "type=" + Weather.type + ";";
                        weather += "duration=" + Weather.duration;
                        weather += "}";
                        b += weather + " ";
                        break;
                    case "skill":
                        string skill = "{";
                        Obj_save.Mob.Mechanic_type.Skill Skill = (Obj_save.Mob.Mechanic_type.Skill)a.Option;
                        skill += "s=" + Skill.skill + ";";
                        skill += "sync=" + Skill.forcesync;
                        skill += "}";
                        b += skill + " ";
                        break;
                    case "Aura":
                        string Aura_ = "{";
                        Obj_save.Mob.Mechanic_type.Aura Aura = (Obj_save.Mob.Mechanic_type.Aura)a.Option;
                        Aura_ += "auraName=" + Aura.auraName + ";";
                        Aura_ += "oS=" + Aura.onStart + ";";
                        Aura_ += "oT=" + Aura.onTick + ";";
                        Aura_ += "oE=" + Aura.onEnd + ";";
                        Aura_ += "c=" + Aura.Charges + ";";
                        Aura_ += "d=" + Aura.Duration + ";";
                        Aura_ += "i=" + Aura.Interval + ";";
                        Aura_ += "maxStacks=" + Aura.maxStacks + ";";
                        Aura_ += "refreshDuration=" + Aura.refreshDuration + ";";
                        Aura_ += "mergeSameCaster=" + Aura.mergeSameCaster + ";";
                        Aura_ += "mergeAll=" + Aura.mergeAll + ";";
                        Aura_ += "cogd=" + Aura.CancelOnGiveDamage + ";";
                        Aura_ += "cotd=" + Aura.CancelOnTakeDamage + ";";
                        Aura_ += "cod=" + Aura.CancelOnDeath + ";";
                        Aura_ += "cot=" + Aura.CancelOnTeleport + ";";
                        Aura_ += "cocw=" + Aura.CancelOnChangeWorld + ";";
                        Aura_ += "cosu=" + Aura.CancelOnSkillUse + ";";
                        Aura_ += "coq=" + Aura.CancelOnQuit;
                        Aura_ += "}";
                        b += Aura_ + " ";
                        break;
                    case "CancelEvent":
                        string CancelEvent_ = "{";
                        Obj_save.Mob.Mechanic_type.CancelEvent CancelEvent = (Obj_save.Mob.Mechanic_type.CancelEvent)a.Option;
                        CancelEvent_ += "s=" + CancelEvent.s + ";";
                        CancelEvent_ += "sync=" + CancelEvent.sync;
                        CancelEvent_ += "}";
                        b += CancelEvent_ + " ";
                        break;
                    default:
                        b += " ";
                        break;
                }

                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Type) == false)
                {
                    string c = a.Skill_Tag.Tag_Type;
                    b += c;
                }
                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false || a.Skill_Tag.Tag_Filters.Count != 0)
                {
                    b += "{";
                }
                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false)
                {
                    b += a.Skill_Tag.Tag_Option;
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
                    else
                        b += d;
                }
                if (string.IsNullOrWhiteSpace(a.Skill_Tag.Tag_Option) == false || a.Skill_Tag.Tag_Filters.Count != 0)
                {
                    b += "}";
                }
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
            Mob.Conditions.Clear();
            foreach (Conditions a in Conditions_L)
            {
                if (string.IsNullOrWhiteSpace(a.Type) == false)
                {
                    string b = a.Type;
                    if (string.IsNullOrWhiteSpace(a.Option) == false)
                        b += a.Option;
                    Mob.Conditions.Add(b);
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
            bool isskill = false;
            while (string.IsNullOrWhiteSpace(line) != true)
            {
                if (line.IndexOf("Skills:") != -1)
                {
                    isskill = true;
                }
                if (isskill == true)
                    listLines.Add(("  " + line).Replace("'", ""));
                else
                    listLines.Add(("  " + line));
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
            string KillMessages = new MessageEdit("击杀", true).KillMessages_set();
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
            Effects = Chose_Effects((string)Skill_Effect_Type.SelectedItem, Effects);
            if (Effects != null)
            {
                Skills_effect.Add(Effects);
                SkillEffect_T.Items.Add(Effects);
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (Skill_Mechanic_Type.SelectedItem == null)
                return;
            Mechanic Mechanic = new Mechanic()
            {
                Type = (string)Skill_Mechanic_Type.SelectedItem,
                Skill_Tag = new Obj_save.Mob.Skill_Tag()
                {
                    Tag_Filters = new List<string>()
                }
            };
            Mechanic = Chose_Mechanic((string)Skill_Mechanic_Type.SelectedItem, Mechanic);
            if (Mechanic != null)
            {
                Skills_mechanic.Add(Mechanic);
                SkillMechanics_T.Items.Add(Mechanic);
            }
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Conditions Conditions = new Conditions()
            {
                Type = "altitude",
                Option = "{h=0} true"
            };
            Conditions = new ConditionsChange(Conditions).get_Conditions_();
            Conditions_T.Items.Add(Conditions);
            Conditions_L.Add(Conditions);
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
        private void refash_SkillMechanic()
        {
            SkillMechanics_T.Items.Clear();
            foreach (Mechanic a in Skills_mechanic)
            {
                SkillMechanics_T.Items.Add(a);
            }
        }
        private void refash_Conditions()
        {
            Conditions_T.Items.Clear();
            foreach (Conditions a in Conditions_L)
            {
                Conditions_T.Items.Add(a);
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
                string KillMessages = new MessageEdit((string)KillMessages_T.SelectedItem, true).KillMessages_set();
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
            Effects Effects = (Effects)SkillEffect_T.SelectedItem;
            Skills_effect.Remove(Effects);
            Effects = Chose_Effects(Effects.Type, Effects);
            Skills_effect.Add(Effects);
            refash_SkillEffect();
        }
        private void DelectSkillMechanicEvent(object sender, RoutedEventArgs e)
        {
            if (SkillMechanics_T.SelectedItem == null)
                return;
            Skills_mechanic.Remove((Mechanic)SkillMechanics_T.SelectedItem);
            refash_SkillMechanic();
        }
        private void ChangeSkillMechanicEvent(object sender, RoutedEventArgs e)
        {
            if (SkillMechanics_T.SelectedItem == null)
                return;
            Mechanic Mechanic = (Mechanic)SkillMechanics_T.SelectedItem;
            Skills_mechanic.Remove(Mechanic);
            Mechanic = Chose_Mechanic(Mechanic.Type, Mechanic);
            Skills_mechanic.Add(Mechanic);
            refash_SkillMechanic();
        }
        private void DelectConditionsEvent(object sender, RoutedEventArgs e)
        {
            if (Conditions_T.SelectedItem == null)
                return;
            Conditions_L.Remove((Conditions)Conditions_T.SelectedItem);
            refash_Conditions();
        }
        private void ChangeConditionsEvent(object sender, RoutedEventArgs e)
        {
            if (Conditions_T.SelectedItem == null)
                return;
            Conditions Conditions = (Conditions)Conditions_T.SelectedItem;
            Conditions_L.Remove(Conditions);
            Conditions = new ConditionsChange(Conditions).get_Conditions_();
            Conditions_L.Add(Conditions);
            refash_Conditions();
        }
        private Mechanic Chose_Mechanic(string type, Mechanic Mechanic)
        {
            switch (type)
            {
                case "activatespawner":
                    return new ActivateSpawner(Mechanic).get_Mechanic_();
                case "arrowvolley":
                    return new ArrowVolley(Mechanic).get_Mechanic_();
                case "command":
                    return new Command(Mechanic).get_Mechanic_();
                case "consume":
                    return new Consume(Mechanic).get_Mechanic_();
                case "disguise":
                    return new Mob.Mechanic_type.Disguise(Mechanic).get_Mechanic_();
                case "undisguise":
                    return new Undisguise(Mechanic).get_Mechanic_();
                case "dismount":
                    return new Dismount(Mechanic).get_Mechanic_();
                case "currencygive":
                    return new CurrencyGive(Mechanic).get_Mechanic_();
                case "currencytake":
                    return new CurrencyTake(Mechanic).get_Mechanic_();
                case "damage":
                    return new Damage(Mechanic).get_Mechanic_();
                case "basedamage":
                    return new BaseDamage(Mechanic).get_Mechanic_();
                case "percentDamage":
                    return new PercentDamage(Mechanic).get_Mechanic_();
                case "decapitate":
                    return new Decapitate(Mechanic).get_Mechanic_();
                case "doppleganger":
                    return new Doppleganger(Mechanic).get_Mechanic_();
                case "ejectpassenger":
                    return new EjectPassenger(Mechanic).get_Mechanic_();
                case "equip":
                    return new Equip(Mechanic).get_Mechanic_();
                case "explosion":
                    return new Mob.Mechanic_type.Explosion(Mechanic).get_Mechanic_();
                case "feed":
                    return new Feed(Mechanic).get_Mechanic_();
                case "forcepull":
                    return new ForcePull(Mechanic).get_Mechanic_();
                case "heal":
                    return new Heal(Mechanic).get_Mechanic_();
                case "healpercent":
                    return new HealPercent(Mechanic).get_Mechanic_();
                case "ignite":
                    return new Ignite(Mechanic).get_Mechanic_();
                case "jsonmessage":
                    return new JSONMessage(Mechanic).get_Mechanic_();
                case "jump":
                    return new JSONMessage(Mechanic).get_Mechanic_();
                case "leap":
                    return new Leap(Mechanic).get_Mechanic_();
                case "lightning":
                    return new Mob.Mechanic_type.Lightning(Mechanic).get_Mechanic_();
                case "look":
                    return new Look(Mechanic).get_Mechanic_();
                case "message":
                    return new Mob.Mechanic_type.Message(Mechanic).get_Mechanic_();
                case "modifyglobalscore":
                    return new ModifyGlobalScore(Mechanic).get_Mechanic_();
                case "modifytargetscore":
                    return new ModifyTargetScore(Mechanic).get_Mechanic_();
                case "modifyscore":
                    return new ModifyScore(Mechanic).get_Mechanic_();
                case "mount":
                    return new Mount(Mechanic).get_Mechanic_();
                case "mounttarget":
                    return new MountTarget(Mechanic).get_Mechanic_();
                case "potion":
                    return new Potion(Mechanic).get_Mechanic_();
                case "prison":
                    return new Prison(Mechanic).get_Mechanic_();
                case "pull":
                    return new Pull(Mechanic).get_Mechanic_();
                case "pushbutton":
                    return new PushButton(Mechanic).get_Mechanic_();
                case "rally":
                    return new Rally(Mechanic).get_Mechanic_();
                case "randommessage":
                    return new RandomMessage(Mechanic).get_Mechanic_();
                case "remount":
                    return new Remount(Mechanic).get_Mechanic_();
                case "remove":
                    return new Remove(Mechanic).get_Mechanic_();
                case "runaigoalselector":
                    return new RunAIGoalSelector(Mechanic).get_Mechanic_();
                case "runaitargetselector":
                    return new RunAITargetSelector(Mechanic).get_Mechanic_();
                case "actionmessage":
                    return new ActionMessage(Mechanic).get_Mechanic_();
                case "sendtitle":
                    return new SendTitle(Mechanic).get_Mechanic_();
                case "setblock":
                    return new SetBlockType(Mechanic).get_Mechanic_();
                case "setgliding":
                    return new SetGliding(Mechanic).get_Mechanic_();
                case "setglobalscore":
                    return new SetGlobalScore(Mechanic).get_Mechanic_();
                case "setlevel":
                    return new SetLevel(Mechanic).get_Mechanic_();
                case "setmobscore":
                    return new SetMobScore(Mechanic).get_Mechanic_();
                case "setowner":
                    return new SetOwner(Mechanic).get_Mechanic_();
                case "settargetscore":
                    return new SetOwner(Mechanic).get_Mechanic_();
                case "setscore":
                    return new SetScore(Mechanic).get_Mechanic_();
                case "setstance":
                    return new SetStance(Mechanic).get_Mechanic_();
                case "shootfireball":
                    return new ShootFireball(Mechanic).get_Mechanic_();
                case "shootpotion":
                    return new ShootPotion(Mechanic).get_Mechanic_();
                case "shootskull":
                    return new ShootSkull(Mechanic).get_Mechanic_();
                case "signal":
                    return new Signal(Mechanic).get_Mechanic_();
                case "spring":
                    return new Spring(Mechanic).get_Mechanic_();
                case "suicide":
                    return new Suicide(Mechanic).get_Mechanic_();
                case "summon":
                    return new Summon(Mechanic).get_Mechanic_();
                case "addtag":
                    return new AddTag(Mechanic).get_Mechanic_();
                case "removetag":
                    return new RemoveTag(Mechanic).get_Mechanic_();
                case "teleport":
                    return new Teleport(Mechanic).get_Mechanic_();
                case "teleportto":
                    return new TeleportTo(Mechanic).get_Mechanic_();
                case "threat":
                    return new Threat(Mechanic).get_Mechanic_();
                case "throw":
                    return new Throw(Mechanic).get_Mechanic_();
                case "togglelever":
                    return new ToggleLever(Mechanic).get_Mechanic_();
                case "velocity":
                    return new ToggleLever(Mechanic).get_Mechanic_();
                case "weather":
                    return new Weather(Mechanic).get_Mechanic_();
                case "skill":
                    return new Skill(Mechanic).get_Mechanic_();
                case "Aura":
                    return new Aura(Mechanic).get_Mechanic_();
                case "CancelEvent":
                    return new CancelEvent(Mechanic).get_Mechanic_();
                default:
                    return Mechanic;
            }
        }
        private Effects Chose_Effects(string type, Effects Effects)
        {
            switch (type)
            {
                case "blockmask":
                    return new BlockMask(Effects).get_Effects_();
                case "ender":
                    return new Ender(Effects).get_Effects_();
                case "enderbeam":
                    return new EnderBeam(Effects).get_Effects_();
                case "explosion":
                    return new Mob.Effects_type.Explosion(Effects).get_Effects_();
                case "firework":
                    return new Firework(Effects).get_Effects_();
                case "flames":
                    return new Flames(Effects).get_Effects_();
                case "geyser":
                    return new Geyser(Effects).get_Effects_();
                case "itemspray":
                    return new ItemSpraycs(Effects).get_Effects_();
                case "lightning":
                    return new Mob.Effects_type.Lightning(Effects).get_Effects_();
                case "particles":
                    return new Particles(Effects).get_Effects_();
                case "particlebox":
                    return new ParticleBox(Effects).get_Effects_();
                case "particleline":
                    return new ParticleLine(Effects).get_Effects_();
                case "particlering":
                    return new ParticleRing(Effects).get_Effects_();
                case "particlesphere":
                    return new ParticleSphere(Effects).get_Effects_();
                case "particletornado":
                    return new ParticleTornado(Effects).get_Effects_();
                case "smoke":
                    return new Smoke(Effects).get_Effects_();
                case "smokeswirl":
                    return new SmokeSwirl(Effects).get_Effects_();
                case "sound":
                    return new Sound(Effects).get_Effects_();
                case "spin":
                    return new Spin(Effects).get_Effects_();
                case "glow":
                    return new Effects_type.Glow(Effects).get_Effects_();
                default:
                    return Effects;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();
        }
    }
}
