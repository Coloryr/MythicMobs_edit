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

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class ARMOR_STAND : UserControl
    {
        public Obj_save.Mob.Mob_type.ARMOR_STAND obj { get; set; } = new Obj_save.Mob.Mob_type.ARMOR_STAND();
        public ARMOR_STAND()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
