namespace MythicMobs_edit.Obj_save.Mob.Mob_type
{
    class ARMOR_STAND
    {
        /// <summary>
        /// 盔甲架是否有手臂
        /// </summary>
        public bool HasArms { get; set; }
        /// <summary>
        /// 盔甲架是否被重力影响
        /// </summary>
        public bool HasGravity { get; set; }
        /// <summary>
        /// 盔甲架是否隐形
        /// </summary>
        public bool Invisible { get; set; }
        /// <summary>
        /// 盔甲架佩戴在身体的物品
        /// </summary>
        public string ItemBody { get; set; }
        /// <summary>
        /// 盔甲架佩戴在脚部的物品
        /// </summary>
        public string ItemFeet { get; set; }
        /// <summary>
        /// 盔甲架佩戴在手上的物品
        /// </summary>
        public string ItemHand { get; set; }
        /// <summary>
        /// 盔甲架佩戴在头部的物品
        /// </summary>
        public string ItemHead { get; set; }
        /// <summary>
        /// 盔甲架佩戴在腿部的物品
        /// </summary>
        public string ItemLegs { get; set; }
        /// <summary>
        /// 盔甲架是否为标记
        /// </summary>
        public bool Marker { get; set; }
        /// <summary>
        /// 是否是小盔甲架
        /// </summary>
        public bool Small { get; set; }
        /// <summary>
        /// 盔甲架动作坐标
        /// </summary>
        public Pose Pose_save { get; set; } = new Pose();
        public class Pose
        {
            public Pose_3D Head = new Pose_3D(0, 0, 0);
            public Pose_3D Body = new Pose_3D(0, 0, 0);
            public Pose_3D LeftArm = new Pose_3D(0, 0, 0);
            public Pose_3D RightArm = new Pose_3D(0, 0, 0);
            public Pose_3D LeftLeg = new Pose_3D(0, 0, 0);
            public Pose_3D RightLeg = new Pose_3D(0, 0, 0);
        }
        public class Pose_3D
        {
            public Pose_3D(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }
        }
    }
}
