namespace MythicMobs_edit.Obj_save.Mob
{
    public class Effects
    {
        /// <summary>
        /// 粒子效果类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 粒子效果选项
        /// </summary>
        public object Option { get; set; }
        /// <summary>
        /// 目标
        /// </summary>
        public Skill_Tag Skill_Tag { get; set; } = new Skill_Tag();
        /// <summary>
        /// 触发
        /// </summary>
        public Triggers Triggers { get; set; } = new Triggers();
    }
}
