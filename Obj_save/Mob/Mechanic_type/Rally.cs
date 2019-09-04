namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class Rally
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string types { get; set; } = "NONE";
        /// <summary>
        /// 半径
        /// </summary>
        public int radius { get; set; } = 10;
        /// <summary>
        /// 水平距离
        /// </summary>
        public int vradius { get; set; } = 10;
        /// <summary>
        /// 垂直距离
        /// </summary>
        public int hradius { get; set; } = 10;
        /// <summary>
        /// 复写目标
        /// </summary>
        public bool overwritetarget { get; set; } = true;
    }
}
