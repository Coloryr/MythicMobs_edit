﻿using System.Windows;
using System.Windows.Controls;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// BABY_PIG_ZOMBIE_VILLAGER.xaml 的交互逻辑
    /// </summary>
    public partial class BABY_PIG_ZOMBIE_VILLAGER : UserControl
    {
        public Obj_save.Mob.Mob_type.BABY_PIG_ZOMBIE_VILLAGER obj { get; set; } = new Obj_save.Mob.Mob_type.BABY_PIG_ZOMBIE_VILLAGER()
        {
            Profession = "BLACKSMITH",
            Angry = false,
            ReinforcementsChance = 0
        };
        public BABY_PIG_ZOMBIE_VILLAGER()
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
