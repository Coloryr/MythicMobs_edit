namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class Summon
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; } = "SKELETON";
        /// <summary>
        /// 类型
        /// </summary>
        public int amount { get; set; } = 1;
        /// <summary>
        /// 类型
        /// </summary>
        public int radius { get; set; } = 0;
        /// <summary>
        /// 类型
        /// </summary>
        public int yRadius { get; set; } = 0;
        /// <summary>
        /// 类型
        /// </summary>
        public bool yRadiusUpOnly { get; set; } = false;
        /// <summary>
        /// 类型
        /// </summary>
        public bool onSurface { get; set; } = true;
        /// <summary>
        /// 类型
        /// </summary>
        public bool copyThreatTable { get; set; } = false;
        /// <summary>
        /// 类型
        /// </summary>
        public bool inheritThreatTable { get; set; } = false;
    }
}
