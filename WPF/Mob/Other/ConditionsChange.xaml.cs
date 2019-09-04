using MythicMobs_edit.Obj_save.Mob;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob.Other
{
    /// <summary>
    /// ConditionsChange.xaml 的交互逻辑
    /// </summary>
    public partial class ConditionsChange : Window
    {
        public Conditions Conditions { get; set; }
        private bool isload = true; 
        public ConditionsChange(Conditions Conditions)
        {
            InitializeComponent();
            this.Conditions = Conditions;
            List list = new List();
            Conditions_Type.ItemsSource = list.Conditions;
            DataContext = this;
        }
        public Conditions get_Conditions_()
        {
            ShowDialog();
            return Conditions;
        }
        private void Conditions_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isload == true)
            {
                isload = false;
                return;
            }
            switch (Conditions_Type.SelectedItem)
            {
                case "altitude":
                    Conditions.Option = "{h=0} true";
                    break;
                case "biome":
                    Conditions.Option = " DESERT,DESERT_HILLS";
                    break;
                case "blocktype":
                    Conditions.Option = " DIRT,STONE,GRASS true";
                    break;
                case "blocking":
                    Conditions.Option = "{} true";
                    break;
                case "crouching":
                    Conditions.Option = "{location1=x,y,z; location2=x,y,z; world=world}";
                    break;
                case "dawn":
                    Conditions.Option = "{} true";
                    break;
                case "day":
                    Conditions.Option = "{} true";
                    break;
                case "distance":
                    Conditions.Option = "{d=<2}";
                    break;
                case "distancefromspawn":
                    Conditions.Option = "{distance=[ranged_value]} true";
                    break;
                case "dusk":
                    Conditions.Option = "{} true";
                    break;
                case "entitytype":
                    Conditions.Option = "{type=[entity]} true";
                    break;
                case "fallspeed":
                    Conditions.Option = "{speed=[number/number range]}";
                    break;
                case "fieldofview":
                    Conditions.Option = "{angle=90;rotation=#} true";
                    break;
                case "gliding":
                    Conditions.Option = "{} true";
                    break;
                case "globalscore":
                    Conditions.Option = "{objective=#;value=#} true";
                    break;
                case "hasaura":
                    Conditions.Option = "{name=#} firedebuff true";
                    break;
                case "hasaurastacks":
                    Conditions.Option = "{auraName=#;stacks=#} firedebuff true";
                    break;
                case "hascurrency":
                    Conditions.Option = "{amount=#} true";
                    break;
                case "hasinventoryspace":
                    Conditions.Option = "{} true";
                    break;
                case "hasowner":
                    Conditions.Option = "{} true";
                    break;
                case "hasparent":
                    Conditions.Option = "{} true";
                    break;
                case "haspotioneffect":
                    Conditions.Option = "{type=[potion type];level=[level];duration=[duration start] to [duration end]} true";
                    break;
                case "hastag":
                    Conditions.Option = "{tag=[tag name]} true";
                    break;
                case "haspermission":
                    Conditions.Option = "{permission=#} true";
                    break;
                case "health":
                    Conditions.Option = "{amount=#} true";
                    break;
                case "height":
                    Conditions.Option = " [number_range] true";
                    break;
                case "heightabove":
                    Conditions.Option = "{height=[number]} true";
                    break;
                case "heightbelow":
                    Conditions.Option = "{height=[number]} true";
                    break;
                case "holding":
                    Conditions.Option = "{material=[itemname]} true";
                    break;
                case "inblock":
                    Conditions.Option = "{block=[material_type]} true";
                    break;
                case "incombat":
                    Conditions.Option = "{} true";
                    break;
                case "inside":
                    Conditions.Option = "{} true";
                    break;
                case "itemrecharging":
                    Conditions.Option = "{} true";
                    break;
                case "lastdamagecause":
                    Conditions.Option = "{damagecause=#} true";
                    break;
                case "lastsignal":
                    Conditions.Option = "{signal=[signal]} true";
                    break;
                case "level":
                    Conditions.Option = "{level=[number_range]} true";
                    break;
                case "lightlevel":
                    Conditions.Option = "{l=[ranged_value]} true";
                    break;
                case "lineofsight":
                    Conditions.Option = "{} true";
                    break;
                case "lunarphase":
                    Conditions.Option = "{p=[days]} true";
                    break;
                case "mobsinchunk":
                    Conditions.Option = "{a=[ranged_value]} true";
                    break;
                case "mobsinworld":
                    Conditions.Option = "{amount=[ranged_value]} true";
                    break;
                case "mounted":
                    Conditions.Option = "{} true";
                    break;
                case "moving":
                    Conditions.Option = "{} true";
                    break;
                case "mythicmobtype":
                    Conditions.Option = "{t=mythicmobinternalnames} true";
                    break;
                case "night":
                    Conditions.Option = "{} true";
                    break;
                case "notinregion":
                    Conditions.Option = "{region=WORLDGUARD_REGION_NAME} true";
                    break;
                case "offgcd":
                    Conditions.Option = "{} true";
                    break;
                case "onblock":
                    Conditions.Option = "{b=LAVA;m=[material_type]} true";
                    break;
                case "onground":
                    Conditions.Option = "{} true";
                    break;
                case "outside":
                    Conditions.Option = "{[true/false]} true";
                    break;
                case "owner":
                    Conditions.Option = " true";
                    break;
                case "ownerisonline":
                    Conditions.Option = "{} true";
                    break;
                case "pitch":
                    Conditions.Option = "{} true";
                    break;
                case "playerkills":
                    Conditions.Option = "{kills=[number] true";
                    break;
                case "playernotwithin":
                    Conditions.Option = "{d=[distance]} true";
                    break;
                case "playerwithin":
                    Conditions.Option = "{d=[distance]} true";
                    break;
                case "raining":
                    Conditions.Option = "{} true";
                    break;
                case "region":
                    Conditions.Option = "{r=[region_name]} true";
                    break;
                case "score":
                    Conditions.Option = "{objective=[objective name];entry=[entry];value=[value]} true";
                    break;
                case "stance":
                    Conditions.Option = "{s=[string]} true";
                    break;
                case "stringequals":
                    Conditions.Option = "{val1=\"yes!\"; val2=\"yes!\"} true";
                    break;
                case "sunny":
                    Conditions.Option = "{} true";
                    break;
                case "targetinlineofsight":
                    Conditions.Option = "{} true";
                    break;
                case "targetnotinlineofsight":
                    Conditions.Option = "{} true";
                    break;
                case "targetwithin":
                    Conditions.Option = "{d=[value]} true";
                    break;
                case "targetnotwithin":
                    Conditions.Option = "{d=[value]} true";
                    break;
                case "targets":
                    Conditions.Option = "{} true";
                    break;
                case "thundering":
                    Conditions.Option = "{} true";
                    break;
                case "variableInRange":
                    Conditions.Option = "{var=target.fear;value=>20} cancel";
                    break;
                case "variableisset":
                    Conditions.Option = " target.dazed true";
                    break;
                case "varEquals":
                    Conditions.Option = "{var=global.poison_storm;value=\"yes\"}";
                    break;
                case "wearing":
                    Conditions.Option = "{armorslot=#;material=#;checklore=#} true";
                    break;
                case "world":
                    Conditions.Option = "{} true";
                    break;
                case "worldtime":
                    Conditions.Option = "{time=[number_range]} true";
                    break;
                case "yaw":
                    Conditions.Option = "{yaw=[number_range]} true";
                    break;
                default:
                    break;
            }
            Conditions_Text.Text = Conditions.Option;
        }
        private void Conditions_Type_r_Click(object sender, RoutedEventArgs e)
        {
            List list = new List();
            Random random = new Random();
            Conditions_Type.SelectedItem = list.Conditions[random.Next(list.Conditions.Count)];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
