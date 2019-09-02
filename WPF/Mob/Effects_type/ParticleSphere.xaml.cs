using MythicMobs_edit.Obj_save.Mob;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MythicMobs_edit.WPF.Mob.Effects_type
{
    /// <summary>
    /// ParticleSphere.xaml 的交互逻辑
    /// </summary>
    public partial class ParticleSphere : Window
    {
        public Effects Effects { get; set; }
        public ParticleSphere(Effects Effects)
        {
            InitializeComponent();
            this.Effects = Effects;
            if (!(this.Effects.Option is Obj_save.Mob.Effects_type.ParticleSphere))
            {
                this.Effects.Option = new Obj_save.Mob.Effects_type.ParticleSphere();
            }
            Type.Type.SelectedItem = this.Effects.Skill_Tag.Tag_Type;
            Type.Option.Text = this.Effects.Skill_Tag.Tag_Option;
            Type.Skill_Tag_ = Effects.Skill_Tag.Tag_Filters;
            Triggers_.Option.Text = Effects.Triggers.Option;
            Triggers_.Type.SelectedItem = Effects.Triggers.Type;
            DataContext = this;
            Type_F.ItemsSource = new List<string>()
            {
                "barrier", "block_crack", "bubble", "bubble_column","bubble_pop","cloud",
                "crit", "crit_magic", "current_down", "damage_indicator", "dolphin", "dragon_breath",
                "drip_lava", "drip_water", "enchantment_table", "end_rod", "explosion_normal",
                "explosion_huge", "explosion_large", "falling_dust", "fireworks_spark", "flame",
                "footstep", "heart", "item_crack", "lava", "mob_appearance", "nautilus", "note",
                "portal", "redstone", "slime", "smoke_large", "smoke_normal", "snowball", "snow_shovel",
                "spell", "spell_instant", "spell_mob", "spell_mob_ambient", "spell_witch", "splash",
                "squid_ink", "suspended", "suspended_depth", "sweep_attack", "town_aura", "villager_angry",
                "villager_happy", "wake"
            };
            Type.refash_SkillTag();
        }
        private void TextCompositionEventArgs(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");

            e.Handled = re.IsMatch(e.Text);
        }
        public Effects get_Effects_()
        {
            ShowDialog();
            Effects.Skill_Tag.Tag_Type = (string)Type.Type.SelectedItem;
            Effects.Skill_Tag.Tag_Option = Type.Option.Text;
            Effects.Skill_Tag.Tag_Filters = Type.Skill_Tag_;
            Effects.Triggers.Type = (string)Triggers_.Type.SelectedItem;
            Effects.Triggers.Option = Triggers_.Option.Text;
            return Effects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
