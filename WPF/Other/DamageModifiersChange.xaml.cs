using MythicMobs_edit.Obj_save.Mob;
using System.Windows;

namespace MythicMobs_edit.WPF.Other
{
    /// <summary>
    /// DamageModifiersChange.xaml 的交互逻辑
    /// </summary>
    public partial class DamageModifiersChange : Window
    {
        public DamageModifiers DamageModifiers { get; set; }
        public DamageModifiersChange(DamageModifiers DamageModifiers)
        {
            InitializeComponent();
            DataContext = this;
            this.DamageModifiers = DamageModifiers;
            List List = new List();
            Type.ItemsSource = List.DamageModifiers_All;
        }
        public DamageModifiers DamageModifiers_set()
        {
            ShowDialog();
            return DamageModifiers;
        }
    }
}
