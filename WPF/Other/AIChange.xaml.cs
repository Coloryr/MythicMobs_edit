using MythicMobs_edit.Obj_save.Mob;
using System.Windows;

namespace MythicMobs_edit.WPF.Other
{
    /// <summary>
    /// AIChange.xaml 的交互逻辑
    /// </summary>
    public partial class AIChange : Window
    {
        public int a { get; set; }
        public string b { get; set; }
        public AIChange(AI a)
        {
            InitializeComponent();
            this.a = a.a;
            b = a.b;
            DataContext = this;
        }
        public AI return_AI()
        {
            ShowDialog();
            return new AI()
            {
                a = this.a,
                b = this.b
            };
        }
    }
}
