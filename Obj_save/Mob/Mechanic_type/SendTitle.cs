namespace MythicMobs_edit.Obj_save.Mob.Mechanic_type
{
    public class SendTitle
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; } = "NONE";
        /// <summary>
        /// 副标题
        /// </summary>
        public string subtitle { get; set; } = "NONE";
        /// <summary>
        /// 显示时间
        /// </summary>
        public int duration { get; set; } = 1;
        /// <summary>
        /// 进入时间
        /// </summary>
        public int fadeIn { get; set; } = 1;
        /// <summary>
        /// 移除时间
        /// </summary>
        public int fadeOut { get; set; } = 1;
    }
}
