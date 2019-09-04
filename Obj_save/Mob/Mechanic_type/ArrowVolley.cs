namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class ArrowVolley
    {
        /// <summary>
        /// 数量
        /// </summary>
        public int amount { get; set; } = 20;
        /// <summary>
        /// 面积
        /// </summary>
        public int spread { get; set; } = 45;
        /// <summary>
        /// 速度
        /// </summary>
        public int velocity { get; set; } = 20;
        /// <summary>
        /// 燃烧tick
        /// </summary>
        public int fireTicks { get; set; } = 0;
        /// <summary>
        /// 清理延迟
        /// </summary>
        public int removeDelay { get; set; } = 200;
    }
}
