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
            Type.ItemsSource = Mob.Type_list;
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

        }
    }
}
