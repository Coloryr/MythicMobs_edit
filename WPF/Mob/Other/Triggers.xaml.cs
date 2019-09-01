using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MythicMobs_edit.WPF.Mob.Other
{
    /// <summary>
    /// Triggers.xaml 的交互逻辑
    /// </summary>
    public partial class Triggers : UserControl
    {
        public Triggers()
        {
            InitializeComponent();
            DataContext = this;
            Obj_save.Mob.List list = new Obj_save.Mob.List();
            Type.ItemsSource = list.Skill_Triggers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Obj_save.Mob.List list = new Obj_save.Mob.List();
            Random random = new Random();
            Type.SelectedItem = list.Skill_Triggers[random.Next(list.Skill_Triggers.Count)];
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Type.SelectedItem == null)
                return;
            switch (Type.SelectedItem)
            {
                case "onDamaged":
                    Option.Text = "0.1";
                    break;
                case "onTimer":
                    Option.Text = "100";
                    break;
                case "onSignal":
                    Option.Text = "[signal]";
                    break;
                default:
                    Option.Text = "";
                    break;
            }
        }
    }
}
