using System.Collections.Generic;

namespace MythicMobs_edit.Obj_save.Mob
{
    public class Skill_Tag
    {
        /// <summary>
        /// 目标类型
        /// </summary>
        public string Tag_Type { get; set; }
        /// <summary>
        /// 目标参数
        /// </summary>
        public string Tag_Option { get; set; }
        /// <summary>
        /// 目标过滤器
        /// </summary>
        public List<string> Tag_Filters { get; set; } = new List<string>();
    }
}
