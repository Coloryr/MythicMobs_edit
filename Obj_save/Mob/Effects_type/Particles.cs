namespace MythicMobs_edit.Obj_save.Mob.Effects_type
{
    public class Particles
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string particle { get; set; } = "reddust";
        /// <summary>
        /// 材料
        /// </summary>
        public string material { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int amount { get; set; } = 10;
        /// <summary>
        /// 水平距离
        /// </summary>
        public int hSpread { get; set; } = 0;
        /// <summary>
        /// 垂直距离
        /// </summary>
        public int vSpread { get; set; } = 0;
        /// <summary>
        /// 粒子速度
        /// </summary>
        public int speed { get; set; } = 0;
        /// <summary>
        /// Y轴偏移
        /// </summary>
        public int yOffset { get; set; } = 0;
        /// <summary>
        /// 可见距离
        /// </summary>
        public int viewDistance { get; set; } = 0;
        /// <summary>
        /// 粒子颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 跟随源
        /// </summary>
        public bool fromorigin { get; set; } = false;
    }
}
