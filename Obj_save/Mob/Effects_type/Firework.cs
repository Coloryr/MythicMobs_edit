namespace MythicMobs_edit.Obj_save.Mob.Effects_type
{
    public class Firework
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; } = 0;
        /// <summary>
        /// 时间
        /// </summary>
        public int duration { get; set; } = 0;
        /// <summary>
        /// 闪烁
        /// </summary>
        public bool flicker { get; set; } = false;
        /// <summary>
        /// 痕迹
        /// </summary>
        public bool trail { get; set; } = false;
        /// <summary>
        /// 颜色
        /// </summary>
        public string colors { get; set; }
        /// <summary>
        /// 痕迹颜色
        /// </summary>
        public string fadecolors { get; set; }
    }
}
