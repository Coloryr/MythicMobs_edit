using System.Windows.Controls;
using static MythicMobs_edit.Obj_save.Mob.Mob_type.ARMOR_STAND;

namespace MythicMobs_edit.WPF.Mob
{
    /// <summary>
    /// ARMOR_STAND.xaml 的交互逻辑
    /// </summary>
    public partial class ARMOR_STAND : UserControl
    {
        public Obj_save.Mob.Mob_type.ARMOR_STAND obj { get; set; } = new Obj_save.Mob.Mob_type.ARMOR_STAND()
        {
            HasArms = false,
            HasGravity = true,
            Invisible = false,
            Small = false,
            Pose = new Pose_()
            {
                Head = "0,0,0",
                Body = "0,0,0",
                LeftArm = "0,0,0",
                RightArm = "0,0,0",
                LeftLeg = "0,0,0",
                RightLeg = "0,0,0"
            }
        };
        public ARMOR_STAND()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
